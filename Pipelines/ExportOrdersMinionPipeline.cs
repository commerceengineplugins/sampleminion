using Plugin.Sample.Minion.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Orders;
using Sitecore.Framework.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Plugin.Sample.Minion.Pipelines 
{
    public class ExportOrdersMinionPipeline : CommercePipeline<ExportOrdersMinionArgument, Order>, IExportOrdersMinionPipeline, IPipeline<ExportOrdersMinionArgument, Order, CommercePipelineExecutionContext>, IPipelineBlock<ExportOrdersMinionArgument, Order, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
        public ExportOrdersMinionPipeline(IPipelineConfiguration<IExportOrdersMinionPipeline> configuration, ILoggerFactory loggerFactory) : base(configuration, loggerFactory)
        {
        }

    }
}
