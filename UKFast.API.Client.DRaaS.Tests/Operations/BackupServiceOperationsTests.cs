using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using NSubstitute;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Models.Request;
using UKFast.API.Client.DRaaS.Operations;
using UKFast.API.Client.Exception;

namespace UKFast.API.Client.DRaaS.Tests.Operations
{
    [TestClass]
    public class BackupServiceOperationsTests
    {
        [TestMethod]
        public async Task GetSolutionBackupServiceAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAsync<BackupService>($"/draas/v1/solutions/00000000-0000-0000-0000-000000000000/backup-service").Returns(new BackupService()
            {
                AccountName = "Test"
            });

            var ops = new BackupServiceOperations<BackupService>(client);
            var backupService = await ops.GetSolutionBackupServiceAsync("00000000-0000-0000-0000-000000000000");

            Assert.AreEqual("Test", backupService.AccountName);
        }

        [TestMethod]
        public async Task GetSolutionBackupServiceAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var ops = new BackupServiceOperations<BackupService>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetSolutionBackupServiceAsync(""));
        }

        [TestMethod]
        public async Task ResetSolutionBackupServiceCredentialsAsync_ValidParameters_ExpectedClientCall()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            var req = new ResetBackupServiceCredentialsRequest()
            {
                Password = "pass"
            };

            var ops = new BackupServiceOperations<BackupService>(client);
            var solutionID = "00000000-0000-0000-0000-000000000000";
            await ops.ResetSolutionBackupServiceCredentialsAsync(solutionID, req);

            await client.Received()
                .PostAsync($"/draas/v1/solutions/{solutionID}/backup-service/reset-credentials", req);
        }

        [TestMethod]
        public async Task ResetSolutionBackupServiceCredentialsAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var ops = new BackupServiceOperations<BackupService>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.ResetSolutionBackupServiceCredentialsAsync("", null));
        }
    }
}