using Application.Features.Clients.Commands.DeleteClient;
using Application.Responses;
using Domain.Entities;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;

namespace UnitTests.FeatureTests.ClientTests.CommandTests.DeleteClientTests.DeleteClientCommandHandlerTests.HandleTests
{
    [TestFixture]
    public class When_The_Client_Exists : Given_A_DeleteClientCommandHandler
    {
        private BasicResponse _result;
        private readonly Client _client = new Client {ID = 1, FirstName = "Bob"};

        public override void When()
        {
            MockClientRepository.GetWhereAsync(Arg.Any<Expression<Func<Client, bool>>>())
                .Returns(new List<Client> {_client});

            _result = SUT.Handle(new DeleteClientCommand {ID = 1}, CancellationToken.None).Result;
        }

        [Test]
        public void Then_ClientRepository_DeleteAsync_Is_Called_With_The_Correct_Client()
        {
            MockClientRepository.Received(1).DeleteAsync(_client);
        }

        [Test]
        public void Then_The_Result_Is_Successful()
        {
            Assert.IsTrue(_result.Success);
        }
    }
}