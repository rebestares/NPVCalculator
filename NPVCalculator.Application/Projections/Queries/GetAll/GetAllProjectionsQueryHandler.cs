using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NPVCalculator.Application.Interfaces;

namespace NPVCalculator.Application.Projections.Queries
{
    /// <summary>
    /// Get all projections query handler
    /// </summary>
    public class GetAllProjectionsQueryHandler : IRequestHandler<GetAllProjectionsQuery, ProjectionListViewModel>
    {
        private readonly INPVCalculatorDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProjectionsQueryHandler(INPVCalculatorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectionListViewModel> Handle(GetAllProjectionsQuery request, CancellationToken cancellationToken)
        {
            var projections = await _context.Projections.OrderBy(p => p.Id).ToListAsync(cancellationToken);

            var model = new ProjectionListViewModel
            {
                Projections = _mapper.Map<IEnumerable<ProjectionDto>>(projections)
            };

            return model;
        }
    }
}
