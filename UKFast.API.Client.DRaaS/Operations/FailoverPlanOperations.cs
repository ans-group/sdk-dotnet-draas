using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Models.Request;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public class FailoverPlanOperations<T> : DRaaSOperations, IFailoverPlanOperations<T> where T : FailoverPlan
    {
        public FailoverPlanOperations(IUKFastDRaaSClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetSolutionFailoverPlansAsync(string solutionID, ClientRequestParameters parameters = null)
        {
            return await this.Client.GetAllAsync(
                funcParameters => GetSolutionFailoverPlansPaginatedAsync(solutionID, funcParameters),
                parameters);
        }

        public async Task<Paginated<T>> GetSolutionFailoverPlansPaginatedAsync(string solutionID, ClientRequestParameters parameters = null)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            return await this.Client.GetPaginatedAsync<T>($"/draas/v1/solutions/{solutionID}/failover-plans", parameters);
        }

        public async Task<T> GetSolutionFailoverPlanAsync(string solutionID, string failoverPlanID)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            if (string.IsNullOrWhiteSpace(failoverPlanID))
            {
                throw new UKFastClientValidationException("Invalid failover plan id");
            }

            return await this.Client.GetAsync<T>($"/draas/v1/solutions/{solutionID}/failover-plans/{failoverPlanID}");
        }

        public async Task StartSolutionFailoverPlanAsync(string solutionID, string failoverPlanID, StartFailoverPlanRequest req)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            if (string.IsNullOrWhiteSpace(failoverPlanID))
            {
                throw new UKFastClientValidationException("Invalid failover plan id");
            }

            await this.Client.PostAsync($"/draas/v1/solutions/{solutionID}/failover-plans/{failoverPlanID}/start", req);
        }

        public async Task StopSolutionFailoverPlanAsync(string solutionID, string failoverPlanID)
        {
            if (string.IsNullOrWhiteSpace(solutionID))
            {
                throw new UKFastClientValidationException("Invalid solution id");
            }

            if (string.IsNullOrWhiteSpace(failoverPlanID))
            {
                throw new UKFastClientValidationException("Invalid failover plan id");
            }

            await this.Client.PostAsync($"/draas/v1/solutions/{solutionID}/failover-plans/{failoverPlanID}/stop");
        }
    }
}