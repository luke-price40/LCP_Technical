using Application.Responses;
using MediatR;

namespace Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest<BasicResponse>
    {
        public int ID { get; set; }
    }
}