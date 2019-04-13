using System;
using System.Threading.Tasks;
using App.Core.Handlers;
using App.Core.Requests;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Core.Test {
    [TestClass]
    public class HandlerTests {
        IMediator _mediator;

        [TestInitialize]
        public void Intialize () {
            var serviceProvider = new ServiceCollection ()
                .AddMediatR (typeof (AddHandler).Assembly)
                .BuildServiceProvider ();

            _mediator = serviceProvider.GetService<IMediator> ();
        }

        [TestMethod]
        public async Task AdderHandler__Add__HappyCase () {
            // Arrange
            AddRequest request = new AddRequest {
                Number1 = 3,
                Number2 = 2
            };

            // Act
            AddResponse addResponse = await _mediator.Send (request);

            // Assert
            Assert.IsTrue (addResponse != null, "response");
            Assert.IsTrue (addResponse.Sum == 5, "sum defined");
        }
    }
}