using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DRaaS.Models;
using UKFast.API.Client.DRaaS.Operations;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Response;

namespace UKFast.API.Client.DRaaS.Tests.Operations
{
    [TestClass]
    public class HardwarePlanOperationsTests
    {
        [TestMethod]
        public async Task GetSolutionHardwarePlansAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<HardwarePlan>>(), null).Returns(Task.Run<IList<HardwarePlan>>(() =>
                new List<HardwarePlan>()
                {
                    new HardwarePlan(),
                    new HardwarePlan()
                }));

            var ops = new HardwarePlanOperations<HardwarePlan>(client);
            var solutionID = "00000000-0000-0000-0000-000000000000";
            var hardwarePlans = await ops.GetSolutionHardwarePlansAsync(solutionID);

            Assert.AreEqual(2, hardwarePlans.Count);
        }

        [TestMethod]
        public async Task GetSolutionHardwarePlansPaginatedAsync_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetPaginatedAsync<HardwarePlan>(
                "/draas/v1/solutions/00000000-0000-0000-0000-000000000000/hardware-plans", null).Returns(Task.Run(() =>
                new Paginated<HardwarePlan>(client, "/draas/v1/solutions/00000000-0000-0000-0000-000000000000/hardware-plans", null,
                    new ClientResponse<IList<HardwarePlan>>()
                    {
                        Body = new ClientResponseBody<IList<HardwarePlan>>()
                        {
                            Data = new List<HardwarePlan>()
                            {
                                new HardwarePlan(),
                                new HardwarePlan()
                            }
                        }
                    })));

            var ops = new HardwarePlanOperations<HardwarePlan>(client);
            var solutionID = "00000000-0000-0000-0000-000000000000";
            var hardwarePlans = await ops.GetSolutionHardwarePlansPaginatedAsync(solutionID);

            Assert.AreEqual(2, hardwarePlans.Items.Count);
        }

        [TestMethod]
        public async Task GetSolutionHardwarePlansPaginatedAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var ops = new HardwarePlanOperations<HardwarePlan>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetSolutionHardwarePlansPaginatedAsync(""));
        }

        [TestMethod]
        public async Task GetSolutionHardwarePlanAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAsync<HardwarePlan>("/draas/v1/solutions/00000000-0000-0000-0000-000000000000/hardware-plans/11111111-1111-1111-1111-111111111111")
                .Returns(new HardwarePlan()
                {
                    ID = "11111111-1111-1111-1111-111111111111"
                });

            var ops = new HardwarePlanOperations<HardwarePlan>(client);
            var computeResource = await ops.GetSolutionHardwarePlanAsync("00000000-0000-0000-0000-000000000000", "11111111-1111-1111-1111-111111111111");

            Assert.AreEqual("11111111-1111-1111-1111-111111111111", computeResource.ID);
        }

        [TestMethod]
        public async Task GetSolutionHardwarePlanAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var ops = new HardwarePlanOperations<HardwarePlan>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetSolutionHardwarePlanAsync("", "11111111-1111-1111-1111-111111111111"));
        }

        [TestMethod]
        public async Task GetSolutionHardwarePlanAsync_InvalidHardwarePlanID_ThrowsUKFastClientValidationException()
        {
            var ops = new HardwarePlanOperations<HardwarePlan>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetSolutionHardwarePlanAsync("00000000-0000-0000-0000-000000000000", ""));
        }
    }
}