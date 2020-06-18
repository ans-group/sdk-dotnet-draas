using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DRaaS.Operations
{
    public class IOPSTierOperations<T> : DRaaSOperations, IIOPSTierOperations<T> where T : IOPSTier
    {
        public IOPSTierOperations(IUKFastDRaaSClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetIOPSTiersAsync(ClientRequestParameters parameters = null)
        {
            return await this.Client.GetAllAsync(GetIOPSTiersPaginatedAsync, parameters);
        }

        public async Task<Paginated<T>> GetIOPSTiersPaginatedAsync(ClientRequestParameters parameters = null)
        {
            return await this.Client.GetPaginatedAsync<T>($"/draas/v1/iops-tiers", parameters);
        }

        public async Task<T> GetIOPSTierAsync(string iopsTierID)
        {
            if (string.IsNullOrWhiteSpace(iopsTierID))
            {
                throw new UKFastClientValidationException("Invalid iops tier id");
            }

            return await this.Client.GetAsync<T>($"/draas/v1/iops-tiers/{iopsTierID}");
        }
    }
}