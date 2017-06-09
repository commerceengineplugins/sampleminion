using Sitecore.Commerce.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plugin.Sample.Minion.Policies
{
    public class OrderExportPolicy : Policy
    {
        public string ExportLocation { get; set; }
    }
}
