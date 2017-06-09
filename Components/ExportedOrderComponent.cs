using Sitecore.Commerce.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plugin.Sample.Minion.Components
{
    public class ExportedOrderComponent : Component
    {
        public DateTime DateExported { get; set; }

        public string ExportFilename { get; set; }
    }
}
