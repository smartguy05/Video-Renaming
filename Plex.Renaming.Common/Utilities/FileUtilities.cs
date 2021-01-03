using System;
using System.Collections.Generic;
using System.IO;

namespace Video.Renaming.Common.Utilities
{
    public static class FileUtilities
    {
        public static string GetFileAttributes(string fullFileName)
        {
            throw new NotImplementedException();
            var file = new FileInfo(fullFileName);

            var tagLib = TagLib.File.Create(file.Name);

            var title = tagLib.Tag.Title;
            var length = tagLib.Properties.Duration;

            return title;
            // more exmamples
            // https://stackoverflow.com/questions/64737356/reading-extended-file-properties-with-net-core
        }

        public static IEnumerable<string> GetFolders(string directory)
        {
            throw new NotImplementedException();
        }
    }
}