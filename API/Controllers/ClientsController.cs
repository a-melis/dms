using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Clients;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> List()
        {
            return  await _mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Details(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id} );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new Delete.Command { Id = id });
        }


    }
}