using Application.Interfaces.Persistence;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ResponseWithData<CreateClientDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Client> _clientRepository;

        public CreateClientCommandHandler(
            IMapper mapper,
            IAsyncRepository<Client> clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<ResponseWithData<CreateClientDto>> Handle(
            CreateClientCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new CreateClientCommandValidator();

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                return new ResponseWithData<CreateClientDto>(new CreateClientDto(), false);
            }

            var client = new Client
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Postcode = request.Postcode
            };

            client = await _clientRepository.AddAsync(client);

            return new ResponseWithData<CreateClientDto>(
                _mapper.Map<CreateClientDto>(client));
        }
    }
}
