using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public interface ISolutionHardwarePlanOperations<T> where T : HardwarePlan
    {
        Task<IList<T>> GetSolutionHardwarePlansAsync(string solutionID, ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetSolutionHardwarePlansPaginatedAsync(string solutionID, ClientRequestParameters parameters = null);

        Task<T> GetSolutionHardwarePlanAsync(string solutionID, string hardwarePlanID);
    }
}