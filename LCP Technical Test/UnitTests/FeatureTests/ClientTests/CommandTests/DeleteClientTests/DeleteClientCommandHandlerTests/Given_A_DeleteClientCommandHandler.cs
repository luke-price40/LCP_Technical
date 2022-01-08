using Application.Features.Clients.Commands.DeleteClient;
using Application.Interfaces.Persistence;
using Domain.Entities;
using NSubstitute;

namespace UnitTests.FeatureTests.ClientTests.CommandTests.DeleteClientTests.DeleteClientCommandHandlerTests
{
    public abstract class Given_A_DeleteClientCommandHandler : BaseGiven<DeleteClientCommandHandler>
    {
        protected IAsyncRepository<Client> MockClientRepository;

        public override void Given()
        {
            MockClientRepository = Substitute.For<IAsyncRepository<Client>>();

            SUT = new DeleteClientCommandHandler(
                MockClientRepository);
        }
    }
}