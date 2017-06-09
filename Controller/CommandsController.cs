﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandsController.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// <summary>
//   Defines the CommandsController controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Plugin.Sample.Minion
{
    using Microsoft.AspNetCore.Mvc;
    using Sitecore.Commerce.Core;
    using System;
    using System.Web.Http.OData;
    using System.Threading.Tasks;

    public class CommandsController : CommerceController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandsController"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="globalEnvironment">The global environment.</param>
        public CommandsController(IServiceProvider serviceProvider, CommerceEnvironment globalEnvironment) : base(serviceProvider, globalEnvironment)
        { }

        /// <summary>
        /// Samples the command.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("SampleCommand()")]
        public async Task<IActionResult> SampleCommand([FromBody] ODataActionParameters value)
        {
            var id = value["Id"].ToString();
            var command = Command<SampleCommand>();
            var result = await command.Process(CurrentContext, id);

            return new ObjectResult(command);
        }
    }
}

