using System;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleDotNetCoreApi.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IServiceProvider _serviceProvider;
        public BaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected async Task ValidateReqeustAsync<TRequest>(TRequest request)
        {
            var validator = _serviceProvider.GetRequiredService<IValidator<TRequest>>();

            var validationResult = await validator.ValidateAsync(request);

            validationResult.AddToModelState(ModelState, null);
        }
    }
}