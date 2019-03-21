using App.Core.Requests;
using MediatR;
using MediatR.Pipeline;

namespace App.Core.Handlers {
    public class AddHandler : RequestHandler<AddRequest, AddResponse> {

        public AddHandler () {

        }

        protected override AddResponse Handle (AddRequest request) {
            int sum = request.Number1 + request.Number2;
            AddResponse response = new AddResponse {
                Sum = sum
            };

            return response;
        }

    }
}