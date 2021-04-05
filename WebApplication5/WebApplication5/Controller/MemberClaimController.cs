using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApplication5.Business;

namespace WebApplication5.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MemberClaimController : BaseController
    {

        public MemberClaimController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetClaimsByDateParam")]
        public async Task<string> GetClaimsByDateParam( string DateParam)
        {
            var epicService = this.ServiceProvider.GetService<MemberClaimBusiness>();

            return await this.GetClaims(epicService, DateParam).ConfigureAwait(false);
        }

        [HttpGet]
        public string Test()
        {
            return "OK";
        }

        public async Task<string> GetClaims(MemberClaimBusiness epicService, string date)
        {
            var claim = await epicService.GetClaimsByDate(date);

            return claim;
        }

     }
}
