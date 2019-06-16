using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NPVCalculator.Application.Projections.Commands.CalculateProjection;
using NPVCalculator.Application.Projections.Queries;

namespace NPVCalculator.API.Controllers
{
    /// <summary>
    /// Controller class for projections related endpoints
    /// </summary>
    public class ProjectionsController : BaseController
    {
        /// <summary>
        /// Get all history of calculated projections
        /// </summary>
        /// <returns>ProjectListViewModel</returns>
        [HttpGet]
        public async Task<ActionResult<ProjectionListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProjectionsQuery()));
        }

       /// <summary>
       /// Calculate the Net Present Value.
       /// </summary>
       /// <returns>The ProjectionsListViewModel</returns>
        [HttpPost]
        public async Task<ActionResult<CalculatedProjectionResponse>> CalculateNPV([FromBody] CalculateProjectionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
