using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

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
        public Stream OpenFileStream(string name)
        {
            StorageFolder folder = StorageFolder.GetFolderFromPathAsync(name).GetResults();

            StorageFile newFile =  folder.CreateFileAsync(name).GetResults();
            IRandomAccessStream streamNewFile = newFile.OpenAsync(FileAccessMode.ReadWrite).GetResults();

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