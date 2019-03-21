using MediatR;

namespace App.Core.Requests
{
    public class AddRequest : IRequest<AddResponse>
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
    }

    public class AddResponse : Response
    {
        public int Sum { get; set; }
    }
}