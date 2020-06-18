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
    public class FailoverPlanOperationsTests
    {
        [TestMethod]
        public async Task GetSolutionFailoverPlansAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<FailoverPlan>>(), null).Returns(Task.Run<IList<FailoverPlan>>(() =>
                new List<FailoverPlan>()
                {
                    new FailoverPlan(),
                    new FailoverPlan()
                }));

            var ops = new FailoverPlanOperations<FailoverPlan>(client);
            var solutionID = "00000000-0000-0000-0000-000000000000";
            var failoverPlans = await ops.GetSolutionFailoverPlansAsync(solutionID);

            Assert.AreEqual(2, failoverPlans.Count);
        }

        [TestMethod]
        public async Task GetSolutionFailoverPlansPaginatedAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetPaginatedAsync<FailoverPlan>(
                "/draas/v1/solutions/00000000-0000-0000-0000-000000000000/failover-plans", null).Returns(Task.Run(() =>
                new Paginated<FailoverPlan>(client, "/draas/v1/solutions/00000000-0000-0000-0000-000000000000/failover-plans", null,
                    new ClientResponse<IList<FailoverPlan>>()
                    {
                        Body = new ClientResponseBody<IList<FailoverPlan>>()
                        {
                            Data = new List<FailoverPlan>()
                            {
                                new FailoverPlan(),
                                new FailoverPlan()
                            }
                        }
                    })));

            var ops = new FailoverPlanOperations<FailoverPlan>(client);
            var solutionID = "00000000-0000-0000-0000-000000000000";
            var failoverPlans = await ops.GetSolutionFailoverPlansPaginatedAsync(solutionID);

            Assert.AreEqual(2, failoverPlans.Items.Count);
        }

        [TestMethod]
        public async Task GetSolutionFailoverPlansPaginatedAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var ops = new FailoverPlanOperations<FailoverPlan>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetSolutionFailoverPlansPaginatedAsync(""));
        }

        [TestMethod]
        public async Task GetSolutionFailoverPlanAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAsync<FailoverPlan>("/draas/v1/solutions/00000000-0000-0000-0000-000000000000/failover-plans/11111111-1111-1111-1111-111111111111")
                .Returns(new FailoverPlan()
                {
                    ID = "11111111-1111-1111-1111-111111111111"
                });

            var ops = new FailoverPlanOperations<FailoverPlan>(client);
            var failoverPlan = await ops.GetSolutionFailoverPlanAsync("00000000-0000-0000-0000-000000000000", "11111111-1111-1111-1111-111111111111");

            Assert.AreEqual("11111111-1111-1111-1111-111111111111", failoverPlan.ID);
        }

        [TestMethod]
        public async Task GetSolutionFailoverPlanAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var ops = new FailoverPlanOperations<FailoverPlan>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetSolutionFailoverPlanAsync("", "11111111-1111-1111-1111-111111111111"));
        }

        [TestMethod]
        public async Task GetSolutionFailoverPlanAsync_InvalidFailoverPlanID_ThrowsUKFastClientValidationException()
        {
            var ops = new FailoverPlanOperations<FailoverPlan>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetSolutionFailoverPlanAsync("00000000-0000-0000-0000-000000000000", ""));
        }

        [TestMethod]
        public async Task StartSolutionFailoverPlanAsync_ValidParameters_ExpectedClientCall()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();
            var req = new StartFailoverPlanRequest();

            var ops = new FailoverPlanOperations<FailoverPlan>(client);
            await ops.StartSolutionFailoverPlanAsync("00000000-0000-0000-0000-000000000000", "11111111-1111-1111-1111-111111111111", req);

            await client.Received()
                .PostAsync($"/draas/v1/solutions/00000000-0000-0000-0000-000000000000/failover-plans/11111111-1111-1111-1111-111111111111/start", req);
        }

        [TestMethod]
        public async Task StartSolutionFailoverPlanAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var req = new StartFailoverPlanRequest();
            var ops = new FailoverPlanOperations<FailoverPlan>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.StartSolutionFailoverPlanAsync("", "11111111-1111-1111-1111-111111111111", req));
        }

        [TestMethod]
        public async Task StartSolutionFailoverPlanAsync_InvalidFailoverPlanID_ThrowsUKFastClientValidationException()
        {
            var req = new StartFailoverPlanRequest();
            var ops = new FailoverPlanOperations<FailoverPlan>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.StartSolutionFailoverPlanAsync("00000000-0000-0000-0000-000000000000", "", req));
        }

        [TestMethod]
        public async Task StopSolutionFailoverPlanAsync_ValidParameters_ExpectedClientCall()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            var ops = new FailoverPlanOperations<FailoverPlan>(client);
            await ops.StopSolutionFailoverPlanAsync("00000000-0000-0000-0000-000000000000", "11111111-1111-1111-1111-111111111111");

            await client.Received()
                .PostAsync($"/draas/v1/solutions/00000000-0000-0000-0000-000000000000/failover-plans/11111111-1111-1111-1111-111111111111/stop");
        }

        [TestMethod]
        public async Task StopSolutionFailoverPlanAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var ops = new FailoverPlanOperations<FailoverPlan>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.StopSolutionFailoverPlanAsync("", "11111111-1111-1111-1111-111111111111"));
        }

        [TestMethod]
        public async Task StopSolutionFailoverPlanAsync_InvalidFailoverPlanID_ThrowsUKFastClientValidationException()
        {
            var ops = new FailoverPlanOperations<FailoverPlan>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.StopSolutionFailoverPlanAsync("00000000-0000-0000-0000-000000000000", ""));
        }
    }
}