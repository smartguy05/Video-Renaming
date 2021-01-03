using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Video.Renaming.Common.Interfaces;
using Video.Renaming.Common.Models;

namespace Video.Renaming.Common
{
    public class RenamingEngine<T> : IRenamingEngine where T : IDirectoryWorker, new()
    {
        public double FileProgress => FilesProcessed / TotalFiles == 0 ? 1 : TotalFiles;
        public double FolderProgress => FoldersProcessed / TotalFolders == 0 ? 1 : TotalFolders;

        protected int FilesProcessed = 0;

        protected int FoldersProcessed = 0;

        protected int TotalFiles = 0;

        protected int TotalFolders = 0;

        /// <summary>
        /// Processes all folders in the supplied file on separate threads
        /// </summary>
        /// <param name="folders">List of all folders to process with full folder names. (eg 'C:/some-folder/movies")</param>
        /// <param name="cancellationToken">Token used for cancellation. Cancels all worker threads also.</param>
        /// <returns></returns>
        public async IAsyncEnumerable<RenamingResult> ProcessDirectoryAsync(IEnumerable<string> folders,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var tasks = ProcessFoldersAsync(folders, cancellationToken).ToList();

            while (tasks.Any())
            {
                if (cancellationToken.IsCancellationRequested) yield break;

                var finishedTask = await Task.WhenAny(tasks);
                tasks.Remove(finishedTask);
                yield return await finishedTask;
            }
        }

        /// <summary>
        /// Starts a worker on a new thread for each folder supplied
        /// </summary>
        /// <param name="folders">Folders to process</param>
        /// <param name="cancellationToken">Token used for cancellation. Cancels all worker threads also.</param>
        /// <returns></returns>
        private IEnumerable<Task<RenamingResult>> ProcessFoldersAsync(IEnumerable<string> folders,
            CancellationToken cancellationToken)
        {
            return folders.Select(folder => DirectoryWorkerFactory.StartWorker<T>(folder, cancellationToken));
        }
    }
}