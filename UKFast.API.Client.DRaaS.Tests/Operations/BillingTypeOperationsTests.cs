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
    public class BillingTypeOperationsTests
    {
        [TestMethod]
        public async Task GetBillingTypesAsync_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<BillingType>>(), null).Returns(Task.Run<IList<BillingType>>(() =>
                new List<BillingType>()
                {
                    new BillingType(),
                    new BillingType()
                }));

            var ops = new BillingTypeOperations<BillingType>(client);
            var billingTypes = await ops.GetBillingTypesAsync();

            Assert.AreEqual(2, billingTypes.Count);
        }

        [TestMethod]
        public async Task GetBillingTypesPaginatedAsync_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetPaginatedAsync<BillingType>("/draas/v1/billing-types", null).Returns(Task.Run(() =>
                new Paginated<BillingType>(client, "/draas/v1/billing-types", null,
                    new ClientResponse<IList<BillingType>>()
                    {
                        Body = new ClientResponseBody<IList<BillingType>>()
                        {
                            Data = new List<BillingType>()
                            {
                                new BillingType(),
                                new BillingType()
                            }
                        }
                    })));

            var ops = new BillingTypeOperations<BillingType>(client);
            var billingTypes = await ops.GetBillingTypesPaginatedAsync();

            Assert.AreEqual(2, billingTypes.Items.Count);
        }

        [TestMethod]
        public async Task GetBillingTypeAsync_ValidParameters_ExpectedResult()
        {
            IUKFastDRaaSClient client = Substitute.For<IUKFastDRaaSClient>();

            client.GetAsync<BillingType>("/draas/v1/billing-types/00000000-0000-0000-0000-000000000000")
                .Returns(new BillingType()
                {
                    ID = "11111111-1111-1111-1111-111111111111"
                });

            var ops = new BillingTypeOperations<BillingType>(client);
            var billingType = await ops.GetBillingTypeAsync("00000000-0000-0000-0000-000000000000");

            Assert.AreEqual("11111111-1111-1111-1111-111111111111", billingType.ID);
        }

        [TestMethod]
        public async Task GetBillingTypeAsync_InvalidBillingTypeID_ThrowsUKFastClientValidationException()
        {
            var ops = new BillingTypeOperations<BillingType>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetBillingTypeAsync(""));
        }
    }
}