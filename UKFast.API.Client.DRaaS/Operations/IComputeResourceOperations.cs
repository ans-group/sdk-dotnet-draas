using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public interface IComputeResourceOperations<T> where T : ComputeResource
    {
        Task<IList<T>> GetSolutionComputeResourcesAsync(string solutionID, ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetSolutionComputeResourcesPaginatedAsync(string solutionID, ClientRequestParameters parameters = null);

        Task<T> GetSolutionComputeResourceAsync(string solutionID, string computeResourceID);
    }
}