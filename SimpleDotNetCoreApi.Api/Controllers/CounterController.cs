using FluentValidation;
using FluentValidation.AspNetCore;
using SimpleDotNetCoreApi.Commands.Counter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace SimpleDotNetCoreApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CounterController : BaseController
    {
        private readonly IMediator _mediator;
        public CounterController(IMediator mediator, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _mediator = mediator;
        }

        [HttpPost("increment")]
        public async Task<IActionResult> Increment([FromBody] IncrementCounter.Command request) 
        {
            await ValidateReqeustAsync(request);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _mediator.Send(request));
        }
    }
}
