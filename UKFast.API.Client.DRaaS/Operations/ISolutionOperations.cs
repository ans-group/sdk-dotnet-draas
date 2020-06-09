using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Models.Request;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public interface ISolutionOperations<T> where T : Solution
    {
        Task<IList<T>> GetSolutionsAsync(ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetSolutionsPaginatedAsync(ClientRequestParameters parameters = null);

        Task<T> GetSolutionAsync(string solutionID);

        Task UpdateSolutionAsync(string solutionID, UpdateSolutionRequest req);
    }
}