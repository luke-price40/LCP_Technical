using Application.Features.Clients.Queries.GetAllClients;
using Application.Interfaces.Persistence;
using Domain.Entities;
using NSubstitute;

namespace UnitTests.FeatureTests.ClientTests.QueryTests.GetAllClientTests.GetClientListQueryHandlerTests
{
    public abstract class Given_A_GetClientsListQueryHandler : BaseGiven<GetClientsListQueryHandler>
    {
        protected IAsyncRepository<Client> MockClientRepository;

        public override void Given()
        {
            CreateMockMapper();
            MockClientRepository = Substitute.For<IAsyncRepository<Client>>();

            SUT = new GetClientsListQueryHandler(
                MockMapper,
                MockClientRepository);
        }
    }
}
