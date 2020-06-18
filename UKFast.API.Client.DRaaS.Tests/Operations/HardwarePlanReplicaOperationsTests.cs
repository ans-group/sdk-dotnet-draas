using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Models.Request;
using UKFast.API.Client.DRaaS.Operations;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Response;

namespace UKFast.API.Client.DRaaS.Tests.Operations
{
    [TestClass]
    public class HardwarePlanReplicaOperationsTests
    {
        [TestMethod]
        public async Task GetSolutionHardwarePlanReplicasAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<Replica>>(), null).Returns(
                Task.Run<IList<Replica>>(() =>
                    new List<Replica>()
                    {
                        new Replica(),
                        new Replica()
                    }));

            var ops = new HardwarePlanReplicaOperations<Replica>(client);
            var solutionID = "00000000-0000-0000-0000-000000000000";
            var hardwarePlanID = "11111111-1111-1111-1111-111111111111";
            var replicas = await ops.GetSolutionHardwarePlanReplicasAsync(solutionID, hardwarePlanID);

            Assert.AreEqual(2, replicas.Count);
        }

        [TestMethod]
        public async Task GetSolutionHardwarePlanReplicasPaginatedAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetPaginatedAsync<Replica>(
                "/draas/v1/solutions/00000000-0000-0000-0000-000000000000/hardware-plans/11111111-1111-1111-1111-111111111111/replicas",
                null).Returns(Task.Run(() =>
                new Paginated<Replica>(client,
                    "/draas/v1/solutions/00000000-0000-0000-0000-000000000000/hardware-plans/11111111-1111-1111-1111-111111111111/replicas",
                    null,
                    new ClientResponse<IList<Replica>>()
                    {
                        Body = new ClientResponseBody<IList<Replica>>()
                        {
                            Data = new List<Replica>()
                            {
                                new Replica(),
                                new Replica()
                            }
                        }
                    })));

            var ops = new HardwarePlanReplicaOperations<Replica>(client);
            var solutionID = "00000000-0000-0000-0000-000000000000";
            var hardwarePlanID = "11111111-1111-1111-1111-111111111111";
            var replicas = await ops.GetSolutionHardwarePlanReplicasPaginatedAsync(solutionID, hardwarePlanID);

            Assert.AreEqual(2, replicas.Items.Count);
        }

        [TestMethod]
        public async Task
            GetSolutionHardwarePlanReplicasPaginatedAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var ops = new HardwarePlanReplicaOperations<Replica>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetSolutionHardwarePlanReplicasPaginatedAsync("", "11111111-1111-1111-1111-111111111111"));
        }

        [TestMethod]
        public async Task
            GetSolutionHardwarePlanReplicasPaginatedAsync_InvalidHardwarePlanID_ThrowsUKFastClientValidationException()
        {
            var ops = new HardwarePlanReplicaOperations<Replica>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetSolutionHardwarePlanReplicasPaginatedAsync("00000000-0000-0000-0000-000000000000", ""));
        }

        [TestMethod]
        public async Task UpdateSolutionReplicaIOPSAsync_ValidParameters_ExpectedClientCall()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();
            var req = new UpdateReplicaIOPSRequest();

            var ops = new HardwarePlanReplicaOperations<Replica>(client);
            await ops.UpdateSolutionReplicaIOPSAsync("00000000-0000-0000-0000-000000000000",
                "11111111-1111-1111-1111-111111111111", req);

            await client.Received()
                .PostAsync(
                    $"/draas/v1/solutions/00000000-0000-0000-0000-000000000000/replicas/11111111-1111-1111-1111-111111111111/iops",
                    req);
        }

        [TestMethod]
        public async Task UpdateSolutionReplicaIOPSAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var req = new UpdateReplicaIOPSRequest();
            var ops = new HardwarePlanReplicaOperations<Replica>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.UpdateSolutionReplicaIOPSAsync("", "11111111-1111-1111-1111-111111111111", req));
        }

        [TestMethod]
        public async Task UpdateSolutionReplicaIOPSAsync_InvalidReplicaID_ThrowsUKFastClientValidationException()
        {
            var req = new UpdateReplicaIOPSRequest();
            var ops = new HardwarePlanReplicaOperations<Replica>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.UpdateSolutionReplicaIOPSAsync("00000000-0000-0000-0000-000000000000", "", req));
        }
    }
}