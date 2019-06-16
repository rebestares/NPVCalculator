using System;
using AutoMapper;

namespace NPVCalculator.Application.Interfaces.Mapping
{
    /// <summary>
    /// Custom mapping interface
    /// </summary>
    public interface ICustomMapping
    {
        /// <summary>
        /// Create mapping
        /// </summary>
        /// <param name="configuration">AutoMapper Profile object</param>
        void CreateMappings(Profile configuration);
    }
}
