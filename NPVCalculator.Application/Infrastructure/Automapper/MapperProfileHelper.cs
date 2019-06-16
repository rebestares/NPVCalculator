using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NPVCalculator.Application.Interfaces.Mapping;

namespace NPVCalculator.Application.Infrastructure.Automapper
{
    /// <summary>
    /// Map class
    /// </summary>
    public sealed class Map
    {
        public Type Source { get; set; }
        public Type Destination { get; set; }
    }

    /// <summary>
    /// Mapper profile helper class
    /// </summary>
    public static class MapperProfileHelper
    {
        /// <summary>
        /// Load automapper standard mappings
        /// </summary>
        /// <param name="rootAssembly">Assembly object</param>
        /// <returns></returns>
        public static IList<Map> LoadStandardMappings(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var mapsFrom = (
                    from type in types
                    from instance in type.GetInterfaces()
                    where
                        instance.IsGenericType && instance.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                        !type.IsAbstract &&
                        !type.IsInterface
                    select new Map
                    {
                        Source = type.GetInterfaces().First().GetGenericArguments().First(),
                        Destination = type
                    }).ToList();

            return mapsFrom;
        }

        /// <summary>
        /// Load custom mappings
        /// </summary>
        /// <param name="rootAssembly">Assembly object</param>
        /// <returns></returns>
        public static IList<ICustomMapping> LoadCustomMappings(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var mapsFrom = (
                    from type in types
                    from instance in type.GetInterfaces()
                    where
                        typeof(ICustomMapping).IsAssignableFrom(type) &&
                        !type.IsAbstract &&
                        !type.IsInterface
                    select (ICustomMapping)Activator.CreateInstance(type)).ToList();

            return mapsFrom;
        }
    }
}
