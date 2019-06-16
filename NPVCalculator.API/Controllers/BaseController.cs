using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace NPVCalculator.API.Controllers
{
    /// <summary>
    /// Base controller for API
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Mediator
        /// </summary>
        private IMediator _mediator;

        /// <summary>
        /// Mediator instance
        /// </summary>
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
    }

}
