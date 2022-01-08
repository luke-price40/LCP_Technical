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
        }
    }
}
