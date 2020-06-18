using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Models.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public interface IBackupServiceOperations<T> where T : BackupService
    {
        Task<T> GetSolutionBackupServiceAsync(string solutionID);

        Task ResetSolutionBackupServiceCredentialsAsync(string solutionID, ResetBackupServiceCredentialsRequest req);
    }
}