// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="MeasureCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Directory;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class MeasureCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class MeasureCommands
    {
        /// <summary>
        /// Gets the measure dimension by identifier.
        /// </summary>
        /// <param name="measureDimensionId">The measure dimension identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetMeasureDimensionById(int measureDimensionId)
        {
            var measureService = EngineContext.Current.Resolve<IMeasureService>();
            var measureDimensionCore = measureService.GetMeasureDimensionById(measureDimensionId);
            var measureDimension = AutoMapperConfiguration.Mapper.Map<Domain.Directory.MeasureDimension>(measureDimensionCore);
            return JsonConvert.SerializeObject(measureDimension, Formatting.Indented);
        }

        /// <summary>
        /// Gets the measure dimension by system keyword.
        /// </summary>
        /// <param name="systemKeyword">The system keyword.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetMeasureDimensionBySystemKeyword(string systemKeyword)
        {
            var measureService = EngineContext.Current.Resolve<IMeasureService>();
            var measureDimensionCore = measureService.GetMeasureDimensionBySystemKeyword(systemKeyword);
            var measureDimension = AutoMapperConfiguration.Mapper.Map<Domain.Directory.MeasureDimension>(measureDimensionCore);
            return JsonConvert.SerializeObject(measureDimension, Formatting.Indented);
        }

        /// <summary>
        /// Gets the measure weight by identifier.
        /// </summary>
        /// <param name="measureWeightId">The measure weight identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetMeasureWeightById(int measureWeightId)
        {
            var measureService = EngineContext.Current.Resolve<IMeasureService>();
            var measureWeightCore = measureService.GetMeasureWeightById(measureWeightId);
            var measureWeight = AutoMapperConfiguration.Mapper.Map<Domain.Directory.MeasureWeight>(measureWeightCore);
            return JsonConvert.SerializeObject(measureWeight, Formatting.Indented);
        }

        /// <summary>
        /// Gets the measure weight by system keyword.
        /// </summary>
        /// <param name="systemKeyword">The system keyword.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetMeasureWeightBySystemKeyword(string systemKeyword)
        {
            var measureService = EngineContext.Current.Resolve<IMeasureService>();
            var measureWeightCore = measureService.GetMeasureWeightBySystemKeyword(systemKeyword);
            var measureWeight = AutoMapperConfiguration.Mapper.Map<Domain.Directory.MeasureWeight>(measureWeightCore);
            return JsonConvert.SerializeObject(measureWeight, Formatting.Indented);
        }

    }
}
