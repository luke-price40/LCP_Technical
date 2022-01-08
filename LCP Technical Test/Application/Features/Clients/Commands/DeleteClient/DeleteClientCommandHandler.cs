using Application.Interfaces.Persistence;
using Application.Responses;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, BasicResponse>
    {
        private readonly IAsyncRepository<Client> _clientRepository;

        public DeleteClientCommandHandler(
            IAsyncRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<BasicResponse> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var success = false;

            var client = await _clientRepository.GetWhereAsync(c => c.ID.Equals(request.ID));

            if (client.Any())
            {
                await _clientRepository.DeleteAsync(client.First());
                success = true;
            }

            ;

            return new BasicResponse(success);
        }
    }
}
