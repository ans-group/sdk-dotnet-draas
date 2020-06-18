# sdk-dotnet-draas

This is the official .NET SDK for UKFast DRaaS

You should refer to the [Getting Started](https://developers.ukfast.io/getting-started) section of the API documentation before proceeding below

## Basic usage

To get started, we'll instantiate an instance of `IUKFastDRaaSClient`:

```csharp
IUKFastDRaaSClient client = new UKFastDRaaSClient(new ClientConnection("myapikey"));
```

We can then obtain an instance of ISolutionOperations to perform operations against the current available DRaaS solutions

```csharp
var ops = client.SolutionOperations();
```

We can use this instance to get all available DRaaS solutions:

```csharp
IList<Solution> draasSolutions = await ops.GetSolutionsAsync()
```

## Operations

All operations available via the SDK are exposed via the client `IUKFastDRaaSClient`:

- `BackupResourceOperations()` - returns an instance of `IBackupResourceOperations` for performing backup resource operations
- `BackupServiceOperations()` - returns an instance of `IBackupServiceOperations` for performing backup service operations
- `BillingTypeOperations()` - returns an instance of `IBillingTypeOperations` for performing billing operations
- `ComputeResourceOperations()` - returns an instance of `IComputeResourceOperations` for performing compute resource operations
- `FailoverPlanOperations()` - returns an instance of `IFailoverPlanOperations` for performing failover plan operations
- `HardwarePlanOperations()` - returns an instance of `IHardwarePlanOperations` for performing hardware plan operations
- `HardwarePlanReplicaOperations()` - returns an instance of `IHardwarePlanReplicaOperations` for hardware plan replica operations
- `IOPSTierOperations()` - returns an instance of `IIOPSTierOperations` for performing IOPs tier operations
- `SolutionOperations()` - returns an instance of `ISolutionOperations` for performing solution operations
