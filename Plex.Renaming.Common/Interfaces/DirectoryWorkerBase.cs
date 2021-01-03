using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Video.Renaming.Common.Models;

namespace Video.Renaming.Common.Interfaces
{
    public abstract class DirectoryWorkerBase : IDisposable, IDirectoryWorker
    {
        public CancellationTokenSource CancellationTokenSource
        {
            get => _cancellationTokenSource;
            set => _cancellationTokenSource = _cancellationTokenSource == null
                ? value
                : CancellationTokenSource.CreateLinkedTokenSource(_cancellationTokenSource.Token, value.Token);
        }

        private CancellationTokenSource _cancellationTokenSource;

        public void Dispose()
        {
            CancellationTokenSource.Cancel(false);
        }

        public abstract Task<RenamingResult> StartRenamingProcess(string folder);

        protected FileInfo GetFilesInDirectory(string folder)
        {
            throw new NotImplementedException();
        }
    }
}