using System.Threading;
using System.Threading.Tasks;
using Video.Renaming.Common.Models;

namespace Video.Renaming.Common.Interfaces
{
    public interface IDirectoryWorker
    {
        Task<RenamingResult> StartRenamingProcess(string folder);
        CancellationTokenSource CancellationTokenSource { get; set; }
    }
}