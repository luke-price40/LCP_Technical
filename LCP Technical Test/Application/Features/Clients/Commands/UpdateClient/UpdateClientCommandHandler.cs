using Application.Interfaces.Persistence;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, BasicResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Client> _clientRepository;

        public UpdateClientCommandHandler(
            IMapper mapper,
            IAsyncRepository<Client> clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<BasicResponse> Handle(
            UpdateClientCommand request,
            CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Client>(request);

            await _clientRepository.UpdateAsync(client);

            return new BasicResponse();
        }
    }
}