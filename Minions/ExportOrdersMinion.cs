using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Plugin.Sample.Minion.Pipelines;
using Plugin.Sample.Minion.Pipelines.Arguments;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Orders;
using System;
using System.Threading.Tasks;

namespace Plugin.Sample.Minion.Minions
{
    public class ExportOrdersMinion : Sitecore.Commerce.Core.Minion
    {
        protected IExportOrdersMinionPipeline MinionPipeline { get; set; }
        
        public override void Initialize(IServiceProvider serviceProvider, ILogger logger, MinionPolicy policy, CommerceEnvironment environment, CommerceContext globalContext)
        {
            base.Initialize(serviceProvider, logger, policy, environment, globalContext);
            MinionPipeline = serviceProvider.GetService<IExportOrdersMinionPipeline>();
        }

        public override async Task<MinionRunResultsModel> Run()
        {
            MinionRunResultsModel runResults = new MinionRunResultsModel();
            long listCount = await this.GetListCount(this.Policy.ListToWatch);
            this.Logger.LogInformation(string.Format("{0}-Review List {1}: Count:{2}", (object)this.Name, (object)this.Policy.ListToWatch, (object)listCount));
            foreach (string id in (await this.GetListIds<Order>(this.Policy.ListToWatch, Convert.ToInt32(listCount))).IdList)
            {
                this.Logger.LogDebug(string.Format("{0}-Reviewing Pending Order: {1}", (object)this.Name, (object)id), Array.Empty<object>());

                var minionPipeline = MinionPipeline;
                var ordersMinionArgument = new ExportOrdersMinionArgument(id);
                var commerceContext = new CommerceContext(this.Logger, this.MinionContext.TelemetryClient, (IGetLocalizableMessagePipeline)null);
                commerceContext.Environment = this.Environment;
     
                CommercePipelineExecutionContextOptions executionContextOptions = new CommercePipelineExecutionContextOptions(commerceContext, null, null, null, null, null);

                var order = await minionPipeline.Run(ordersMinionArgument, executionContextOptions);
            }

            return runResults;
        }
    }
}
