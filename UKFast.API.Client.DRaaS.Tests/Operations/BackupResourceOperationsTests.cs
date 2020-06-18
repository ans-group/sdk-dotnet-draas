using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using NSubstitute;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Operations;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Response;

namespace UKFast.API.Client.DRaaS.Tests.Operations
{
    [TestClass]
    public class BackupResourceOperationsTests
    {
        [TestMethod]
        public async Task GetSolutionBackupResourcesAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<BackupResource>>(), null).Returns(Task.Run<IList<BackupResource>>(() =>
                new List<BackupResource>()
                {
                    new BackupResource(),
                    new BackupResource()
                }));

            var ops = new BackupResourceOperations<BackupResource>(client);
            var backupResources = await ops.GetSolutionBackupResourcesAsync("00000000-0000-0000-0000-000000000000");

            Assert.AreEqual(2, backupResources.Count);
        }

        [TestMethod]
        public async Task GetSolutionBackupResourcesPaginatedAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetPaginatedAsync<BackupResource>("/draas/v1/solutions/00000000-0000-0000-0000-000000000000/backup-resources").Returns(Task.Run(() =>
                new Paginated<BackupResource>(client, "/draas/v1/solutions/00000000-0000-0000-0000-000000000000/backup-resources", null, 
                    new ClientResponse<IList<BackupResource>>()
                    {
                        Body = new ClientResponseBody<IList<BackupResource>>()
                        {
                            Data = new List<BackupResource>()
                            {
                                new BackupResource(),
                                new BackupResource()
                            }
                        }
                    })));

            var ops = new BackupResourceOperations<BackupResource>(client);
            var solutionID = "00000000-0000-0000-0000-000000000000";
            var backupResources = await ops.GetSolutionBackupResourcesPaginatedAsync(solutionID, null);

            Assert.AreEqual(2, backupResources.Items.Count);
        }

        [TestMethod]
        public async Task GetSolutionBackupResourcesPaginatedAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var ops = new BackupResourceOperations<BackupResource>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetSolutionBackupResourcesPaginatedAsync("", null));
        }

    }
}