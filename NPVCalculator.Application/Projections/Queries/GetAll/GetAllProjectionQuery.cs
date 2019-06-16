using System;
using MediatR;

namespace NPVCalculator.Application.Projections.Queries
{
    /// <summary>
    /// Get all projections query.
    /// </summary>
    public class GetAllProjectionsQuery : IRequest<ProjectionListViewModel>
    {

    }
}
