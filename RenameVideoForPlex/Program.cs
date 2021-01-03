using Plex.Renaming.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Video.Renaming.Common.Interfaces;
using Video.Renaming.Common.Utilities;

namespace RenameVideoForPlex
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var parsedArgs = ParseArgsFromCommandLine(args);
            var cancellationTokenSource = new CancellationTokenSource();

            // use current directory or directory supplied
            var directory = parsedArgs
                                .Select(s => s.Name)
                                .FirstOrDefault(f => f?.ToUpper() == "directory")
                            ?? Directory.GetCurrentDirectory();

            var engine = new RenamingEngine<PlexDirectoryWorker>();
            var folders = FileUtilities.GetFolders(directory);

            var results = engine.ProcessDirectoryAsync(folders, cancellationTokenSource.Token);
            // check results and print
        }

        private static IEnumerable<(string Name, string value)> ParseArgsFromCommandLine(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}