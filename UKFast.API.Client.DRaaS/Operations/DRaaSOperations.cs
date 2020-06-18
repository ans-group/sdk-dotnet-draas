using UKFast.API.Client.Operations;

namespace UKFast.API.Client.DRaaS.Operations
{
    public abstract class DRaaSOperations : OperationsBase<IUKFastDRaaSClient>
    {
        public DRaaSOperations(IUKFastDRaaSClient client) : base(client) { }
    }
}