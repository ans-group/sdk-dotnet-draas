using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public class BillingTypeOperations<T> : DRaaSOperations, IBillingTypeOperations<T> where T : BillingType
    {
        public BillingTypeOperations(IUKFastDRaaSClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetBillingTypesAsync(ClientRequestParameters parameters = null)
        {
            return await this.Client.GetAllAsync(GetBillingTypesPaginatedAsync, parameters);
        }

        public async Task<Paginated<T>> GetBillingTypesPaginatedAsync(ClientRequestParameters parameters = null)
        {
            return await this.Client.GetPaginatedAsync<T>($"/draas/v1/billing-types", parameters);
        }

        public async Task<T> GetBillingTypeAsync(string billingTypeID)
        {
            if (string.IsNullOrWhiteSpace(billingTypeID))
            {
                throw new UKFastClientValidationException("Invalid billing type id");
            }

            return await this.Client.GetAsync<T>($"/draas/v1/billing-types/{billingTypeID}");
        }
    }
}