using Application.Responses;
using MediatR;

namespace Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<ResponseWithData<CreateClientDto>>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Postcode { get; set; }
    }
}