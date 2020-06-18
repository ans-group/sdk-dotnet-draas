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
    public class IOPsTierOperationsTests
    {
        [TestMethod]
        public async Task GetIOPSTiersAsync_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<IOPSTier>>(), null).Returns(Task.Run<IList<IOPSTier>>(() =>
                new List<IOPSTier>()
                {
                    new IOPSTier(),
                    new IOPSTier()
                }));

            var ops = new IOPSTierOperations<IOPSTier>(client);
            var iopsTiers = await ops.GetIOPSTiersAsync();

            Assert.AreEqual(2, iopsTiers.Count);
        }

        [TestMethod]
        public async Task GetIOPSTiersPaginatedAsync_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetPaginatedAsync<IOPSTier>("/draas/v1/iops-tiers", null).Returns(Task.Run(() =>
                new Paginated<IOPSTier>(client, "/draas/v1/iops-tiers", null,
                    new ClientResponse<IList<IOPSTier>>()
                    {
                        Body = new ClientResponseBody<IList<IOPSTier>>()
                        {
                            Data = new List<IOPSTier>()
                            {
                                new IOPSTier(),
                                new IOPSTier()
                            }
                        }
                    })));

            var ops = new IOPSTierOperations<IOPSTier>(client);
            var iopsTiers = await ops.GetIOPSTiersPaginatedAsync();

            Assert.AreEqual(2, iopsTiers.Items.Count);
        }

        [TestMethod]
        public async Task GetIOPSTierAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAsync<IOPSTier>("/draas/v1/iops-tiers/00000000-0000-0000-0000-000000000000")
                .Returns(new IOPSTier()
                {
                    ID = "11111111-1111-1111-1111-111111111111"
                });

            var ops = new IOPSTierOperations<IOPSTier>(client);
            var iopsTier = await ops.GetIOPSTierAsync("00000000-0000-0000-0000-000000000000");

            Assert.AreEqual("11111111-1111-1111-1111-111111111111", iopsTier.ID);
        }

        [TestMethod]
        public async Task GetIOPSTierAsync_InvalidIOPSTierID_ThrowsUKFastClientValidationException()
        {
            var ops = new IOPSTierOperations<IOPSTier>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetIOPSTierAsync(""));
        }
    }
}