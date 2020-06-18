using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public interface IBackupResourceOperations<T> where T : BackupResource
    {
        Task<IList<T>> GetSolutionBackupResourcesAsync(string solutionID, ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetSolutionBackupResourcesPaginatedAsync(string solutionID, ClientRequestParameters parameters = null);
    }
}