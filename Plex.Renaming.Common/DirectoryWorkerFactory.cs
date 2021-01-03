using System.Threading;
using System.Threading.Tasks;
using Video.Renaming.Common.Interfaces;
using Video.Renaming.Common.Models;

namespace Video.Renaming.Common
{
    public static class DirectoryWorkerFactory
    {
        /// <summary>
        /// Create instance of directory worker supplied and return result
        /// </summary>
        /// <typeparam name="T">Type of directory worker to instantiate</typeparam>
        /// <param name="folder">Full folder name to process</param>
        /// <param name="cancellationToken">Token used for cancellation. Cancels all worker threads also</param>
        /// <returns></returns>
        public static Task<RenamingResult> StartWorker<T>(string folder, CancellationToken cancellationToken)
            where T : IDirectoryWorker, new()
        {
            var instance = new T
            {
                CancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken)
            };
            return instance.StartRenamingProcess(folder);
        }
    }
}