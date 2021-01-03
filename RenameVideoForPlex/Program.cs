using Microsoft.Extensions.DependencyInjection;
using Plex.Renaming.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Video.Renaming.Common;
using Video.Renaming.Common.Interfaces;
using Video.Renaming.Common.Utilities;

namespace RenameVideoForPlex
{
    public class Program
    {
        private static CancellationTokenSource _cancellationTokenSource;
        private static string _directory;

        public static void AddServices(ServiceCollection services)
        {
            services.AddSingleton<IDirectoryWorker, PlexDirectoryWorker>();
            services.AddSingleton<IRenamingEngine, RenamingEngine<PlexDirectoryWorker>>();
        }

        private static void Main(string[] args)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var serviceProvider = ConfigurationBuilder.BuildConfiguration(AddServices);

            var parsedArgs = ParseArgsFromCommandLine(args);

            _directory = parsedArgs
                             .Select(s => s.Name)
                             .FirstOrDefault(f => f?.ToUpper() == "directory")
                         ?? Directory.GetCurrentDirectory();

            var engine = serviceProvider.GetService<IRenamingEngine>();
            var folders = FileUtilities.GetFolders(_directory);

            var results = engine.ProcessDirectoryAsync(folders, _cancellationTokenSource.Token);
            // check results and print
        }

        private static IEnumerable<(string Name, string value)> ParseArgsFromCommandLine(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}