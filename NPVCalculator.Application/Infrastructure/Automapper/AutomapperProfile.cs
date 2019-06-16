using System.Reflection;
using AutoMapper;
using NPVCalculator.Application.Projections.Queries;
using NPVCalculator.Domain.Entities;

namespace NPVCalculator.Application.Infrastructure.Automapper
{
    public class AutomapperProfile : Profile
    {
        /// <summary>
        /// Automapper profile
        /// </summary>
        public AutomapperProfile()
        {
            LoadStandardMappings();
            LoadCustomMappings();
            LoadConverters();
        }

        /// <summary>
        /// Load converters
        /// </summary>
        private void LoadConverters()
        {
            CreateMap<Projection, ProjectionDto>();
        }

        /// <summary>
        /// Load standard automapper mappings
        /// </summary>
        private void LoadStandardMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadStandardMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                CreateMap(map.Source, map.Destination).ReverseMap();
            }
        }

        /// <summary>
        /// Load custom automapper mappings
        /// </summary>
        private void LoadCustomMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadCustomMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                map.CreateMappings(this);
            }
        }
    }
}
