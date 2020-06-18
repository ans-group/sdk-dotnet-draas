using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Operations;

namespace UKFast.API.Client.DRaaS
{
    public interface IUKFastDRaaSClient : IUKFastClient
    {
        IBackupResourceOperations<BackupResource> BackupResourceOperations();

        IBackupServiceOperations<BackupService> BackupServiceOperations();

        IBillingTypeOperations<BillingType> BillingTypeOperations();

        IComputeResourceOperations<ComputeResource> ComputeResourceOperations();

        IFailoverPlanOperations<FailoverPlan> FailoverPlanOperations();

        IHardwarePlanOperations<HardwarePlan> HardwarePlanOperations();

        IIOPSTierOperations<IOPSTier> IOPSTierOperations();

        IHardwarePlanReplicaOperations<Replica> HardwarePlanReplicaOperations();

        ISolutionOperations<Solution> SolutionOperations();
    }
}