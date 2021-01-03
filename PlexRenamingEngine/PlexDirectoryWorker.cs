using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Video.Renaming.Common.Interfaces;
using Video.Renaming.Common.Models;
using Video.Renaming.Common.Utilities;

namespace Plex.Renaming.Engine
{
    public class PlexDirectoryWorker : DirectoryWorkerBase
    {
        public PlexDirectoryWorker()
        {
        }

        public override Task<RenamingResult> StartRenamingProcess(string folder)
        {
            var movieName = GetTitle(folder);
            var movieYear = GetYear(folder);

            var fileAttributes = FileUtilities.GetFileAttributes(folder);

            // try to get imdb id
            //      if able to get id append tag to folder

            // find all video files and rename to same as folder
            // don't interrupt file size ending (eg. - 4k, - 1080p, etc)
            // do same for subtitle files, but don't touch language suffix
            var files = GetFilesInDirectory(folder);

            throw new NotImplementedException();
        }

        private string GetImdbId(string folderName)
        {
            throw new NotImplementedException();
        }

        private string GetTitle(string folderName)
        {
            throw new NotImplementedException();
            var regex = new Regex("");

            return "";
        }

        private string GetYear(string folderName)
        {
            throw new NotImplementedException();

            // return null if not found in title
        }
    }
}