using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Video.Renaming.Common.Models;

namespace Video.Renaming.Common.Interfaces
{
    public interface IRenamingEngine
    {
        double FileProgress { get; }
        double FolderProgress { get; }

        /// <summary>
        /// Processes all folders in the supplied file on separate threads
        /// </summary>
        /// <param name="folders">List of all folders to process with full folder names. (eg 'C:/some-folder/movies")</param>
        /// <param name="cancellationToken">Token used for cancellation. Cancels all worker threads also.</param>
        /// <returns></returns>
        IAsyncEnumerable<RenamingResult> ProcessDirectoryAsync(IEnumerable<string> folders,
            [EnumeratorCancellation] CancellationToken cancellationToken);
    }
}