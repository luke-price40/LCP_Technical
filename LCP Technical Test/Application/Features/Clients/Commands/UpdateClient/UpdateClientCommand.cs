using Application.Responses;
using MediatR;

namespace Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<BasicResponse>
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Postcode { get; set; }
    }
}