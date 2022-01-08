using Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Clients.Queries.GetAllClients
{
    public class GetClientsListQueryHandler : IRequestHandler<GetClientsListQuery, ResponseWithData<List<ClientListViewModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Client> _clientRepository;

        public GetClientsListQueryHandler(
            IMapper mapper,
            IAsyncRepository<Client> clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<ResponseWithData<List<ClientListViewModel>>> Handle(
            GetClientsListQuery request,
            CancellationToken cancellationToken)
        {
            var allClients = (await _clientRepository.ListAllAsync()).OrderBy(x => x.LastName);

            return new ResponseWithData<List<ClientListViewModel>>(
                _mapper.Map<List<ClientListViewModel>>(allClients));
        }
    }
}