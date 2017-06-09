using Newtonsoft.Json;
using Plugin.Sample.Minion.Components;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Orders;
using Sitecore.Framework.Pipelines;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Plugin.Sample.Minion.Pipelines.Blocks
{
    public class ExportOrderToFileBlock : PipelineBlock<Order, Order, CommercePipelineExecutionContext>
    {
        private readonly IPersistEntityPipeline persistEntityPipeline;

        public ExportOrderToFileBlock(IPersistEntityPipeline persistEntityPipeline)
        {
            this.persistEntityPipeline = persistEntityPipeline;
        }

        public override async Task<Order> Run(Order order, CommercePipelineExecutionContext context)
        {
            var exportComponent = order.GetComponent<ExportedOrderComponent>();

            //if( exportComponent.DateExported )
            exportComponent.DateExported = DateTime.Now;

            var orderAsString = JsonConvert.SerializeObject(order);

            var orderNumber = order.FriendlyId;

            using (StreamWriter sw = new StreamWriter($"c:\\temp\\order_{order.OrderConfirmationId}.json"))
            {
                await sw.WriteAsync(orderAsString);
            }

            var persistEntityArgument = await persistEntityPipeline.Run(new PersistEntityArgument(order), context);

            return order;
        }
    }
}
