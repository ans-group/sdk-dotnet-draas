using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Models.Request;
using UKFast.API.Client.Exception;

namespace UKFast.API.Client.DRaaS.Operations
{
    public class BackupServiceOperations<T> : DRaaSOperations, IBackupServiceOperations<T> where T : BackupService
    {
        public BackupServiceOperations(IUKFastDRaaSClient client) : base(client)
        {
        }

        public async Task<T> GetSolutionBackupServiceAsync(string solutionID)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            return await this.Client.GetAsync<T>($"/draas/v1/solutions/{solutionID}/backup-service");
        }

        public async Task ResetSolutionBackupServiceCredentialsAsync(string solutionID, ResetBackupServiceCredentialsRequest req)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            await this.Client.PostAsync($"/draas/v1/solutions/{solutionID}/backup-service/reset-credentials", req);
        }
    }
}