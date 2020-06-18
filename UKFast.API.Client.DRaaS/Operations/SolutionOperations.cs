using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Models.Request;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public class SolutionOperations<T> : DRaaSOperations, ISolutionOperations<T> where T : Solution
    {
        public SolutionOperations(IUKFastDRaaSClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetSolutionsAsync(ClientRequestParameters parameters = null)
        {
            return await this.Client.GetAllAsync(GetSolutionsPaginatedAsync, parameters);
        }

        public async Task<Paginated<T>> GetSolutionsPaginatedAsync(ClientRequestParameters parameters = null)
        {
            return await this.Client.GetPaginatedAsync<T>($"/draas/v1/solutions", parameters);
        }

        public async Task<T> GetSolutionAsync(string solutionID)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            return await this.Client.GetAsync<T>($"/draas/v1/solutions/{solutionID}");
        }

        public async Task UpdateSolutionAsync(string solutionID, UpdateSolutionRequest req)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            await this.Client.PatchAsync($"/draas/v1/solutions/{solutionID}", req);
        }
    }
}