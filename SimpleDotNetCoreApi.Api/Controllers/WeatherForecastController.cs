using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using SimpleDotNetCoreApi.Queries.WeatherForecast;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleDotNetCoreApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<GetWeatherForecast.Query> _queryValidator;
        public WeatherForecastController(IMediator mediator, IValidator<GetWeatherForecast.Query> queryValidator)
        {
            _mediator = mediator;
            _queryValidator = queryValidator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetWeatherForecast.Query request) 
        {
            var validationResult = await _queryValidator.ValidateAsync(request);

            validationResult.AddToModelState(ModelState, null);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _mediator.Send(request));
        }
    }
}
