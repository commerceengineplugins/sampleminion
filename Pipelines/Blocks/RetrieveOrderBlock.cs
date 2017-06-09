using Plugin.Sample.Minion.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Orders;
using Sitecore.Framework.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plugin.Sample.Minion.Pipelines.Blocks
{
    [PipelineDisplayName("Orders.block.RetrieveOrderBlock")]
    public class RetrieveOrderBlock : PipelineBlock<ExportOrdersMinionArgument, Order, CommercePipelineExecutionContext>
    {
        private readonly IFindEntityPipeline _findEntityPipeline;

        public RetrieveOrderBlock(IFindEntityPipeline findEntityPipeline)
        {
            this._findEntityPipeline = findEntityPipeline;
        }

        public override async Task<Order> Run(ExportOrdersMinionArgument arg, CommercePipelineExecutionContext context)
        {
            Order order = await this._findEntityPipeline.Run(new FindEntityArgument(typeof(Order), string.Format("{0}", (object)arg.OrderId), false), context) as Order;
            if (order == null)
            {
                CommercePipelineExecutionContext executionContext = context;
                string reason = await context.CommerceContext.AddMessage(context.GetPolicy<KnownResultCodes>().Error, "OrderNotFound", new object[1] {
          (object) arg.OrderId
                }, string.Format("Order {0} was not found.", (object)arg.OrderId));
                executionContext.Abort(reason, (object)context);
                executionContext = (CommercePipelineExecutionContext)null;
                return (Order)null;
            }

            return order;
        }
    }
}
