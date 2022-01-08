using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Clients.Queries.GetAllClients;
using Application.Responses;
using Domain.Entities;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests.FeatureTests.ClientTests.QueryTests.GetAllClientTests.GetClientListQueryHandlerTests.HandleTests
{
    [TestFixture]
    public class When_Called : Given_A_GetClientsListQueryHandler
    {
        private ResponseWithData<List<ClientListViewModel>> _result;

        public override void When()
        {
            MockClientRepository.ListAllAsync().Returns(Task.FromResult(new List<Client>
            {
                new Client {FirstName = "Tim"},
                new Client {FirstName = "Dani"}
            }));

            _result = SUT.Handle(new GetClientsListQuery(), CancellationToken.None).Result;
        }

        [Test]
        public void Then_ClientRepository_ListAllAsync_Is_Called_Once()
        {
            MockClientRepository.Received(1).ListAllAsync();
        }

        [Test]
        public void Then_The_Result_Is_Successful()
        {
            Assert.IsTrue(_result.Success);
        }

        [Test]
        public void Then_Two_Clients_Should_Be_Returned()
        {
            Assert.IsTrue(_result.Data.Count == 2);
        }

        [Test]
        public void Then_Each_Returned_Client_Is_A_ClientListViewModel()
        {
            Assert.IsTrue(_result.Data.All(r => r is ClientListViewModel));
        }
    }
}