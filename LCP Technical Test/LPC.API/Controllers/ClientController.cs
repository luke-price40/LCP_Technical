using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Features.Clients.Commands.CreateClient;
using Application.Features.Clients.Commands.DeleteClient;
using Application.Features.Clients.Commands.UpdateClient;
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

        [HttpPost("create", Name = "CreateClient")]
        public async Task<ActionResult<CreateClientDto>> Create(
            [FromBody] CreateClientCommand createClientCommand)
        {
            var response = await _mediator.Send(createClientCommand);
            return Ok(response);
        }

        [HttpDelete("delete", Name = "DeleteClient")]
        public async Task<ActionResult> Delete(
            [FromBody] DeleteClientCommand deleteClientCommand)
        {
            var response = await _mediator.Send(deleteClientCommand);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch("update", Name = "UpdateClient")]
        public async Task<ActionResult> Update(
            [FromBody] UpdateClientCommand updateClientCommand)
        {
            var response = await _mediator.Send(updateClientCommand);
            return Ok(response);
        }
    }
}
