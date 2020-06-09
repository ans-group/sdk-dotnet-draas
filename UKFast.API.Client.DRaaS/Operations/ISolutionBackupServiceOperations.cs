using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Models.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public interface ISolutionBackupServiceOperations<T> where T : BackupService
    {
        Task<T> GetSolutionBackupServiceAsync(string solutionID);

        Task ResetSolutionSolutionBackupServiceCredentialsAsync(string solutionID, ResetBackupServiceCredentialsRequest req);
    }
}