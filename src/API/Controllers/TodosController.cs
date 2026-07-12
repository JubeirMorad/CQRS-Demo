using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Requests;
using Application.Features.Todos.Commands.CreateTodo;
using Application.Features.Todos.Commands.DeleteTodo;
using Application.Features.Todos.Commands.UpdateTodo;
using Application.Features.Todos.Queries.GetTodd;
using Application.Features.Todos.Queries.GetTodoById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly IMediator mediator;
        public TodosController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await mediator.Send(new GetTodosQuery()));
        }


        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await mediator.Send(new GetTodoByIdQuery(id)));
        }



        //
        //
        [HttpPost]
        public async Task<IActionResult> Add(CreateTodoRequest request)
        {
            CreateTodoCommand command = new(request.Title, request.Description);

            await mediator.Send(command);
            return Ok();
        }


        [HttpPut("{Id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateTodoRequest request)
        {
            UpdateTodoCommand command = new(id, request.Title, request.Description, request.Done);

            await mediator.Send(command);
            return Ok();
        }


        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await mediator.Send(new DeleteTodoCommand(id));
            return Ok();
        }
    }
}