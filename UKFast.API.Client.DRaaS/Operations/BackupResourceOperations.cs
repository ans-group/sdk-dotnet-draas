using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public class BackupResourceOperations<T> : DRaaSOperations, IBackupResourceOperations<T> where T : BackupResource
    {
        public BackupResourceOperations(IUKFastDRaaSClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetSolutionBackupResourcesAsync(string solutionID, ClientRequestParameters parameters = null)
        {
            return await this.Client.GetAllAsync(
                funcParameters => GetSolutionBackupResourcesPaginatedAsync(solutionID, funcParameters),
                parameters);
        }

        public async Task<Paginated<T>> GetSolutionBackupResourcesPaginatedAsync(string solutionID, ClientRequestParameters parameters = null)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            return await this.Client.GetPaginatedAsync<T>($"/draas/v1/solutions/{solutionID}/backup-resources", parameters);
        }
    }
}