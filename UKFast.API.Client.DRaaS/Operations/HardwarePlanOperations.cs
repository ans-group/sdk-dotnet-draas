using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public class HardwarePlanOperations<T> : DRaaSOperations, IHardwarePlanOperations<T> where T : HardwarePlan
    {
        public HardwarePlanOperations(IUKFastDRaaSClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetSolutionHardwarePlansAsync(string solutionID, ClientRequestParameters parameters = null)
        {
            return await this.Client.GetAllAsync(
                funcParameters => GetSolutionHardwarePlansPaginatedAsync(solutionID, funcParameters),
                parameters);
        }

        public async Task<Paginated<T>> GetSolutionHardwarePlansPaginatedAsync(string solutionID, ClientRequestParameters parameters = null)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            return await this.Client.GetPaginatedAsync<T>($"/draas/v1/solutions/{solutionID}/hardware-plans", parameters);
        }

        public async Task<T> GetSolutionHardwarePlanAsync(string solutionID, string hardwarePlanID)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            if (string.IsNullOrWhiteSpace(hardwarePlanID))
            {
                throw new UKFastClientValidationException("Invalid hardware plan id");
            }

            return await this.Client.GetAsync<T>($"/draas/v1/solutions/{solutionID}/hardware-plans/{hardwarePlanID}");
        }
    }
}