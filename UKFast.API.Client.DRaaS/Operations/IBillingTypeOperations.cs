using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public interface IBillingTypeOperations<T> where T : BillingType
    {
        Task<IList<T>> GetBillingTypesAsync(ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetBillingTypesPaginatedAsync(ClientRequestParameters parameters = null);

        Task<T> GetBillingTypeAsync(string billingTypeID);
    }
}