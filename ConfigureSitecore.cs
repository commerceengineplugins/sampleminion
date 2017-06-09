// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureSitecore.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// <summary>
//   The SamplePlugin startup class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Plugin.Sample.Minion
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Configuration;
    using Sitecore.Framework.Pipelines.Definitions.Extensions;
    using Pipelines;
    using Pipelines.Blocks;
    using Sitecore.Framework.Pipelines;
    using Sitecore.Commerce.Plugin.Orders;

    /// <summary>
    /// The carts configure sitecore class.
    /// </summary>
    public class ConfigureSitecore : IConfigureSitecore
    {
        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.RegisterAllPipelineBlocks(assembly);

            // SitecorePipelinesConfigBuilder pipelinesConfigBuilder = pipelinesConfigBuilder1.AddPipeline<IGetCountryPipeline, GetCountryPipeline>
            // ((Action<PipelineDefinition<IGetCountryPipeline>>)(c => c.Add<GetCountryBlock>()), section1, order1).AddPipeline<IGetCountriesPipeline, GetCountriesPipeline>();

            services.Sitecore().Pipelines(config => config
             .AddPipeline<IExportOrdersMinionPipeline, ExportOrdersMinionPipeline>(
                    configure =>
                        {
                            configure.Add<RetrieveOrderBlock>().Add<ExportOrderToFileBlock>();
                        })
            );

            services.Sitecore().Pipelines(config => config
 .AddPipeline<ISamplePipeline, SamplePipeline>(
        configure =>
        {
            configure.Add<SampleBlock>();
        })
);

            services.RegisterAllCommands(assembly);
        }
    }
}