using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Models.Request;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public interface IHardwarePlanReplicaOperations<T> where T : Replica
    {
        Task<IList<T>> GetSolutionHardwarePlanReplicasAsync(string solutionID, string hardwarePlanID, ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetSolutionHardwarePlanReplicasPaginatedAsync(string solutionID, string hardwarePlanID, ClientRequestParameters parameters = null);

        Task UpdateSolutionReplicaIOPSAsync(string solutionID, string replicaID, UpdateReplicaIOPSRequest req);
    }
}