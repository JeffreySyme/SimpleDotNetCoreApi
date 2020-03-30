using FluentValidation;
using FluentValidation.AspNetCore;
using SimpleDotNetCoreApi.Commands.Counter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SimpleDotNetCoreApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CounterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<IncrementCounter.Command> _incrementValidator;
        public CounterController(IMediator mediator, IValidator<IncrementCounter.Command> incrementValidator)
        {
            _mediator = mediator;
            _incrementValidator = incrementValidator;
        }

        [HttpPost("increment")]
        public async Task<IActionResult> Increment([FromBody] IncrementCounter.Command request) 
        {
            var validationResult = await _incrementValidator.ValidateAsync(request);

            validationResult.AddToModelState(ModelState, null);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _mediator.Send(request));
        }
    }
}
