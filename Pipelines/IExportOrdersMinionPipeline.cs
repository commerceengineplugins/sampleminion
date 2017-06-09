using Plugin.Sample.Minion.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Orders;
using Sitecore.Framework.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plugin.Sample.Minion.Pipelines
{
    [PipelineDisplayName("IExportOrdersMinionPipeline")]
    public interface IExportOrdersMinionPipeline : IPipeline<ExportOrdersMinionArgument, Order, CommercePipelineExecutionContext>, IPipelineBlock<ExportOrdersMinionArgument, Order, CommercePipelineExecutionContext>, IPipelineBlock, IPipeline
    {
    }
}
