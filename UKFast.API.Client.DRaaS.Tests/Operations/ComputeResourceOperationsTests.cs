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
    public class ComputeResourceOperationsTests
    {
        [TestMethod]
        public async Task GetSolutionComputeResources_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<ComputeResource>>(), null).Returns(Task.Run<IList<ComputeResource>>(() =>
                new List<ComputeResource>()
                {
                    new ComputeResource(),
                    new ComputeResource()
                }));

            var ops = new ComputeResourceOperations<ComputeResource>(client);
            var solutionID = "00000000-0000-0000-0000-000000000000";
            var computeResources = await ops.GetSolutionComputeResourcesAsync(solutionID);

            Assert.AreEqual(2, computeResources.Count);
        }

        [TestMethod]
        public async Task GetSolutionComputeResourcesPaginatedAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetPaginatedAsync<ComputeResource>(
                "/draas/v1/solutions/00000000-0000-0000-0000-000000000000/compute-resources", null).Returns(Task.Run(() =>
                    new Paginated<ComputeResource>(client, "/draas/v1/solutions/00000000-0000-0000-0000-000000000000/compute-resources", null,
                        new ClientResponse<IList<ComputeResource>>()
                        {
                            Body = new ClientResponseBody<IList<ComputeResource>>()
                            {
                                Data = new List<ComputeResource>()
                                {
                                    new ComputeResource(),
                                    new ComputeResource()
                                }
                            }
                        })));

            var ops = new ComputeResourceOperations<ComputeResource>(client);
            var solutionID = "00000000-0000-0000-0000-000000000000";
            var computeResources = await ops.GetSolutionComputeResourcesPaginatedAsync(solutionID);

            Assert.AreEqual(2, computeResources.Items.Count);
        }

        [TestMethod]
        public async Task GetSolutionComputeResourcesPaginatedAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var ops = new ComputeResourceOperations<ComputeResource>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetSolutionComputeResourcesPaginatedAsync(""));
        }

        [TestMethod]
        public async Task GetSolutionComputeResourceAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAsync<ComputeResource>("/draas/v1/solutions/00000000-0000-0000-0000-000000000000/compute-resources/11111111-1111-1111-1111-111111111111")
                .Returns(new ComputeResource()
                {
                    ID = "11111111-1111-1111-1111-111111111111"
                });

            var ops = new ComputeResourceOperations<ComputeResource>(client);
            var computeResource = await ops.GetSolutionComputeResourceAsync("00000000-0000-0000-0000-000000000000", "11111111-1111-1111-1111-111111111111");

            Assert.AreEqual("11111111-1111-1111-1111-111111111111", computeResource.ID);
        }

        [TestMethod]
        public async Task GetSolutionComputeResourceAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var ops = new ComputeResourceOperations<ComputeResource>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetSolutionComputeResourceAsync("", "11111111-1111-1111-1111-111111111111"));
        }

        [TestMethod]
        public async Task GetSolutionComputeResourceAsync_InvalidComputeResourceID_ThrowsUKFastClientValidationException()
        {
            var ops = new ComputeResourceOperations<ComputeResource>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetSolutionComputeResourceAsync("00000000-0000-0000-0000-000000000000", ""));
        }
    }
}