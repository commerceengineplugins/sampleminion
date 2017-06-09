// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SamplePipeline.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// <summary>
//   SamplePipeline pipeline.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Plugin.Sample.Minion
{
    using Microsoft.Extensions.Logging;
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Pipelines;

    /// <summary>
    /// Defines the get SamplePipeline pipeline.
    /// </summary>
    public class SamplePipeline : CommercePipeline<SampleArgument, SampleEntity>, ISamplePipeline
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SamplePipeline"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The definition.
        /// </param>
        public SamplePipeline(IPipelineConfiguration<ISamplePipeline> configuration, ILoggerFactory loggerFactory)
            : base(configuration, loggerFactory)
        {
        }
    }
}

