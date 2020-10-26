using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HX.GenerateCode.Helper;
using HX.GenerateCode.Model;
using HX.GenerateCode.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HX.GenerateCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HxGeneratedController : ControllerBase
    {
        private readonly HxService hxService;

        public HxGeneratedController(HxService hxService)
        {
            this.hxService = hxService;
        }

        [HttpGet]
        public string Index()
        {
            return "Api connected";
        }

        [HttpPost]
        public async Task<object> Execute(ClientRequest request)
        {
            var sponsorId = request.SponsorId;
            var result = await this.hxService.ExecuteAsync(sponsorId, request);

            var className = request.ProcedureName.GetClassName();
            var fields = result.GetFieldsFromDataTable();
            var constant = string.Format("public const string {0} = {1};", request.ProcedureName.ToUpper(), request.ProcedureName);
            var attribute = string.Format("[StoreName(Constant.StoreProcedure.{0})]", request.ProcedureName.ToUpper());

            return new { constant, attribute, className, fields };
        }
    }
}
