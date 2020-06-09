using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Operations;

namespace UKFast.API.Client.DRaaS
{
    public interface IUKFastDRaaSClient : IUKFastClient
    {
        ISolutionBackupResourceOperations<BackupResource> SolutionBackupResourceOperations();

        ISolutionBackupServiceOperations<BackupService> SolutionBackupServiceOperations();

        IBillingTypeOperations<BillingType> BillingTypeOperations();

        ISolutionComputeResourceOperations<ComputeResource> SolutionComputeResourceOperations();

        ISolutionFailoverPlanOperations<FailoverPlan> SolutionFailoverPlanOperations();

        ISolutionHardwarePlanOperations<HardwarePlan> SolutionHardwarePlanOperations();

        IIOPSTierOperations<IOPSTier> IOPSTierOperations();

        ISolutionReplicaOperations<Replica> SolutionReplicaOperations();

        ISolutionOperations<Solution> SolutionOperations();
    }
}