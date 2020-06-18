using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Models.Request;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public class HardwarePlanReplicaOperations<T> : DRaaSOperations, IHardwarePlanReplicaOperations<T> where T : Replica
    {
        public HardwarePlanReplicaOperations(IUKFastDRaaSClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetSolutionHardwarePlanReplicasAsync(string solutionID, string hardwarePlanID, ClientRequestParameters parameters = null)
        {
            return await this.Client.GetAllAsync(
                (funcParameters) =>
                    GetSolutionHardwarePlanReplicasPaginatedAsync(solutionID, hardwarePlanID, funcParameters),
                parameters);
        }

        public async Task<Paginated<T>> GetSolutionHardwarePlanReplicasPaginatedAsync(string solutionID, string hardwarePlanID, ClientRequestParameters parameters = null)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            if (string.IsNullOrWhiteSpace(hardwarePlanID))
            {
                throw new UKFastClientValidationException("Invalid hardware plan id");
            }

            return await this.Client.GetPaginatedAsync<T>($"/draas/v1/solutions/{solutionID}/hardware-plans/{hardwarePlanID}/replicas");
        }

        public async Task UpdateSolutionReplicaIOPSAsync(string solutionID, string replicaID, UpdateReplicaIOPSRequest req)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            if (string.IsNullOrWhiteSpace(replicaID))
            {
                throw new UKFastClientValidationException("Invalid hardware plan id");
            }

            await this.Client.PostAsync($"/draas/v1/solutions/{solutionID}/replicas/{replicaID}/iops", req);

        }
    }
}