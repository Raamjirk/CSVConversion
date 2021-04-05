using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Controller
{
    public class BaseController : ControllerBase
    {
        public BaseController(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }


        /// <summary>
        /// Gets the IServiceProvider.
        /// </summary>
        protected IServiceProvider ServiceProvider { get; }
    }
}
