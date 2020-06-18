using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public class ComputeResourceOperations<T> : DRaaSOperations, IComputeResourceOperations<T> where T : ComputeResource
    {
        public ComputeResourceOperations(IUKFastDRaaSClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetSolutionComputeResourcesAsync(string solutionID, ClientRequestParameters parameters = null)
        {
            return await this.Client.GetAllAsync(
                funcParameters => GetSolutionComputeResourcesPaginatedAsync(solutionID, funcParameters),
                parameters);
        }

        public async Task<Paginated<T>> GetSolutionComputeResourcesPaginatedAsync(string solutionID, ClientRequestParameters parameters = null)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            return await this.Client.GetPaginatedAsync<T>($"/draas/v1/solutions/{solutionID}/compute-resources", parameters);
        }

        public async Task<T> GetSolutionComputeResourceAsync(string solutionID, string computeResourceID)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            if (string.IsNullOrWhiteSpace(computeResourceID))
            {
                throw new UKFastClientValidationException("Invalid compute resource id");
            }

            return await this.Client.GetAsync<T>(
                $"/draas/v1/solutions/{solutionID}/compute-resources/{computeResourceID}");
        }
    }
}