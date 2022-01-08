using Application.Features.Clients.Commands.CreateClient;
using Application.Responses;
using Domain.Entities;
using NSubstitute;
using NUnit.Framework;
using System.Threading;

namespace UnitTests.FeatureTests.ClientTests.CommandTests.CreateClientTests.CreateClientCommandHandlerTests.HandleTests
{
    [TestFixture]
    public class When_Called : Given_A_CreateClientCommandHandler
    {
        private ResponseWithData<CreateClientDto> _result;

        public override void When()
        {
            MockClientRepository.AddAsync(Arg.Any<Client>()).Returns(
                new Client
                {
                    FirstName = "Bob",
                    LastName = "Thompson",
                    Email = "bob.thompson@gmail.com",
                    PhoneNumber = "07546378945",
                    Address = "123 code lane",
                    Postcode = "ET10 9RG"
                });

            _result = SUT.Handle(new CreateClientCommand
            {
                FirstName = "Bob",
                LastName = "Thompson",
                Email = "bob.thompson@gmail.com",
                PhoneNumber = "07546378945",
                Address = "123 code lane",
                Postcode = "ET10 9RG"
            }, CancellationToken.None).Result;
        }

        [Test]
        public void Then_ClientRepository_AddAsync_Is_Called_Once()
        {
            MockClientRepository.Received(1).AddAsync(Arg.Any<Client>());
        }

        [Test]
        public void Then_The_Result_Is_Successful()
        {
            Assert.IsTrue(_result.Success);
        }

        [Test]
        public void Then_The_Added_Client_Should_Be_Returned()
        {
            Assert.IsTrue(_result.Data.FirstName == "Bob");
            Assert.IsTrue(_result.Data.LastName == "Thompson");
            Assert.IsTrue(_result.Data.Email == "bob.thompson@gmail.com");
        }

        [Test]
        public void Then_Each_Returned_Client_Is_A_CreateClientDto()
        {
            Assert.IsTrue(_result.Data is CreateClientDto);
        }
    }
}