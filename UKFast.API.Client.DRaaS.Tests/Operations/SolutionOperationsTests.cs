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
    public class SolutionOperationsTests
    {
        [TestMethod]
        public async Task GetSolutionsAsync_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<Solution>>(), null).Returns(Task.Run<IList<Solution>>(() =>
                new List<Solution>()
                {
                    new Solution(),
                    new Solution()
                }));

            var ops = new SolutionOperations<Solution>(client);
            var solutions = await ops.GetSolutionsAsync();

            Assert.AreEqual(2, solutions.Count);
        }

        [TestMethod]
        public async Task GetSolutionsPaginatedAsync_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetPaginatedAsync<Solution>("/draas/v1/solutions").Returns(Task.Run(() =>
                new Paginated<Solution>(client, "/draas/v1/solutions", null, new ClientResponse<IList<Solution>>()
                {
                    Body = new ClientResponseBody<IList<Solution>>()
                    {
                        Data = new List<Solution>()
                    {
                        new Solution(),
                        new Solution()
                    }
                    }
                })));

            var ops = new SolutionOperations<Solution>(client);
            var solutions = await ops.GetSolutionsPaginatedAsync(null);

            Assert.AreEqual(2, solutions.Items.Count);
        }

        [TestMethod]
        public async Task GetSolutionAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAsync<Solution>("/draas/v1/solutions/00000000-0000-0000-0000-000000000000").Returns(new Solution()
            {
                ID = "00000000-0000-0000-0000-000000000000"
            });

            var ops = new SolutionOperations<Solution>(client);
            var solution = await ops.GetSolutionAsync("00000000-0000-0000-0000-000000000000");

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", solution.ID);
        }

        [TestMethod]
        public async Task GetSolutionAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var ops = new SolutionOperations<Solution>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetSolutionAsync(""));
        }

        [TestMethod]
        public async Task UpdateSolutionAsync_ValidParameters_ExpectedClientCall()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            UpdateSolutionRequest req = new UpdateSolutionRequest
            {
                IOPSTierID = "11111111-1111-1111-1111-111111111111"
            };
            
            var ops = new SolutionOperations<Solution>(client);
            await ops.UpdateSolutionAsync("00000000-0000-0000-0000-000000000000", req);

            await client.Received().PatchAsync("/draas/v1/solutions/00000000-0000-0000-0000-000000000000", req);
        }

        [TestMethod]
        public async Task UpdateSolutionAsync_InvalidSolutionID_ThrowsUKFastClientValidationException()
        {
            var ops = new SolutionOperations<Solution>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => 
                ops.UpdateSolutionAsync("", null));
        }

    }
}