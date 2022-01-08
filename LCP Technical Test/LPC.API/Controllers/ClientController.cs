using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Clients.Queries.GetAllClients;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LPC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllClients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ClientListViewModel>>> GetAllClients()
        {
            var clients = await _mediator.Send(new GetClientsListQuery());

            return Ok(clients);
        }
    }
}
