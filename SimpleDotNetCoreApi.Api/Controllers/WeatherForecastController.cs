using System.Threading.Tasks;
using SimpleDotNetCoreApi.Queries.WeatherForecast;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SimpleDotNetCoreApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
        private readonly IMediator _mediator;
        public WeatherForecastController(IMediator mediator, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetWeatherForecast.Query request) 
        {
            await ValidateReqeustAsync(request);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _mediator.Send(request));
        }
    }
}
