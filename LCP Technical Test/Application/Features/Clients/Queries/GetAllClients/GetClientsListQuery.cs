using Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Clients.Queries.GetAllClients
{
    public class GetClientsListQuery : IRequest<ResponseWithData<List<ClientListViewModel>>>
    {
    }
}
