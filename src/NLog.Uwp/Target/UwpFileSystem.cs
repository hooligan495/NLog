using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace NLog.Targets
{
    /// <summary>
    /// Wrap the .net Native file management so that we can open and close files.
    /// UWP supports returning a "managed" Stream (Windows.Storage) as a File.IO.Stream type
    /// </summary>
    public class UapFileSystem : IFileSystem
    {
        /// <summary>
        /// Delete specified file using the Windows.Storage API
        /// </summary>
        /// <param name="name">File name to be deleted</param>
        public void DeleteFile(string name)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Open a file using the Windows.Storage API and return a .net Runtime IO stream
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Stream> FileWriterStream(string name)
        {
            StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(name);

            StorageFile newFile = await folder.CreateFileAsync(name);
            var streamNewFile = await newFile.OpenAsync(FileAccessMode.ReadWrite);

            return streamNewFile.AsStreamForWrite();
        }

        /// <summary>
        /// lookup all the filenames in a directory and return the list
        /// </summary>
        /// <returns></returns>
        public List<string> LookupFileNames()
        {
            throw new System.NotImplementedException();
        }
    }
}