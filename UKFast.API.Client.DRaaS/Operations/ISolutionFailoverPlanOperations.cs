using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Models.Request;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public interface ISolutionFailoverPlanOperations<T> where T : FailoverPlan
    {
        Task<IList<T>> GetSolutionFailoverPlansAsync(string solutionID, ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetSolutionFailoverPlansPaginatedAsync(string solutionID, ClientRequestParameters parameters = null);

        Task<T> GetSolutionFailoverPlanAsync(string solutionID, string failoverPlanID);

        Task StartSolutionFailoverPlanAsync(string solutionID, string failoverPlanID, StartFailoverPlanRequest req);

        Task StopSolutionFailoverPlanAsync(string solutionID, string failoverPlanID);
    }
}