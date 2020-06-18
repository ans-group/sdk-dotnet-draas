using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Operations;

namespace UKFast.API.Client.DRaaS
{
    public class UKFastDRaaSClient : UKFastClient, IUKFastDRaaSClient
    {
        public UKFastDRaaSClient(IConnection connection) : base(connection)
        {
        }

        public UKFastDRaaSClient(IConnection connection, ClientConfig config) : base(connection, config)
        {
        }

        public IBackupResourceOperations<BackupResource> BackupResourceOperations()
        {
            return new BackupResourceOperations<BackupResource>(this);
        }

        public IBackupServiceOperations<BackupService> BackupServiceOperations()
        {
            return new BackupServiceOperations<BackupService>(this);
        }

        public IBillingTypeOperations<BillingType> BillingTypeOperations()
        {
            return new BillingTypeOperations<BillingType>(this);
        }

        public IComputeResourceOperations<ComputeResource> ComputeResourceOperations()
        {
            return new ComputeResourceOperations<ComputeResource>(this);
        }

        public IFailoverPlanOperations<FailoverPlan> FailoverPlanOperations()
        {
            return new FailoverPlanOperations<FailoverPlan>(this);
        }

        public IHardwarePlanOperations<HardwarePlan> HardwarePlanOperations()
        {
            return new HardwarePlanOperations<HardwarePlan>(this);
        }

        public IIOPSTierOperations<IOPSTier> IOPSTierOperations()
        {
            return new IOPSTierOperations<IOPSTier>(this);
        }

        public IHardwarePlanReplicaOperations<Replica> HardwarePlanReplicaOperations()
        {
            return new HardwarePlanReplicaOperations<Replica>(this);
        }

        public ISolutionOperations<Solution> SolutionOperations()
        {
            return new SolutionOperations<Solution>(this);
        }
    }
}