using Application.Features.Clients.Commands.CreateClient;
using Application.Features.Clients.Commands.UpdateClient;
using Application.Features.Clients.Queries.GetAllClients;
using AutoMapper;
using Domain.Entities;

namespace Application.MappingProfiles
{
    public class ClientProfiles : Profile
    {
        public ClientProfiles()
        {
            CreateMap<Client, ClientListViewModel>();
            CreateMap<Client, CreateClientDto>().ReverseMap();
            CreateMap<Client, UpdateClientCommand>().ReverseMap();
        }
    }
}
