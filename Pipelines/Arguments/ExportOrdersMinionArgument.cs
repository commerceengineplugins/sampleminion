using Sitecore.Commerce.Core;
using Sitecore.Framework.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plugin.Sample.Minion.Pipelines.Arguments
{
    public class ExportOrdersMinionArgument : PipelineArgument
    {
        public string OrderId { get; set; }

        public ExportOrdersMinionArgument(string orderId)
        {
            Condition.Requires<string>(orderId, "orderId").IsNotNullOrEmpty();

            this.OrderId = orderId;
        }
    }
}
