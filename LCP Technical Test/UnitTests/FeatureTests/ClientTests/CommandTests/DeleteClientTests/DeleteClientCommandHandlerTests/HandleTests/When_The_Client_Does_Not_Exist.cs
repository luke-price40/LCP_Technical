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
    public class When_The_Client_Does_Not_Exist : Given_A_DeleteClientCommandHandler
    {
        private BasicResponse _result;

        public override void When()
        {
            MockClientRepository.GetWhereAsync(Arg.Any<Expression<Func<Client, bool>>>()).Returns(new List<Client>());

            _result = SUT.Handle(new DeleteClientCommand {ID = 1}, CancellationToken.None).Result;
        }

        [Test]
        public void Then_ClientRepository_DeleteAsync_Is_Not_Called()
        {
            MockClientRepository.DidNotReceive().DeleteAsync(Arg.Any<Client>());
        }

        [Test]
        public void Then_The_Result_Is_Not_Successful()
        {
            Assert.IsFalse(_result.Success);
        }
    }
}