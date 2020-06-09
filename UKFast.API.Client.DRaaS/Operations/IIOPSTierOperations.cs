using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public interface IIOPSTierOperations<T> where T : IOPSTier
    {
        Task<IList<T>> GetIOPSTiersAsync(ClientRequestParameters parameters = null);

        Task<T> GetIOPSTierAsync(string iopsTierID);
    }
}