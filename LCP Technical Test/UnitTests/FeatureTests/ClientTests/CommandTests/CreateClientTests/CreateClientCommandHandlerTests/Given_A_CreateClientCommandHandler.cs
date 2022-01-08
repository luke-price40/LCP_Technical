using Application.Features.Clients.Commands.CreateClient;
using Application.Interfaces.Persistence;
using Domain.Entities;
using NSubstitute;

namespace UnitTests.FeatureTests.ClientTests.CommandTests.CreateClientTests.CreateClientCommandHandlerTests
{
    public abstract class Given_A_CreateClientCommandHandler : BaseGiven<CreateClientCommandHandler>
    {
        protected IAsyncRepository<Client> MockClientRepository;

        public override void Given()
        {
            CreateMockMapper();
            MockClientRepository = Substitute.For<IAsyncRepository<Client>>();

            SUT = new CreateClientCommandHandler(
                MockMapper,
                MockClientRepository);
        }
    }
}
