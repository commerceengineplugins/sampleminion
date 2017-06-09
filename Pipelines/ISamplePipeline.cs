// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISamplePipeline.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// <summary>
//   ISamplePipeline pipeline interface definition.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Plugin.Sample.Minion
{
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Pipelines;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the ISamplePipeline interface
    /// </summary>
    /// <seealso cref="Sitecore.Framework.Pipelines.IPipeline{Plugin.Sample.Minion.SampleArgument, Plugin.Sample.Minion.SampleEntity, Sitecore.Commerce.Core.CommercePipelineExecutionContext}" />
    [PipelineDisplayName("SamplePipeline")]
    public interface ISamplePipeline : IPipeline<SampleArgument, SampleEntity, CommercePipelineExecutionContext>
    {
    }
}
