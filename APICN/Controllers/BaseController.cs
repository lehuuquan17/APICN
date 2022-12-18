using API_HTGT.Context;
//using APICN.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICN.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        protected readonly MyDBcontext dbcontext;

        public BaseController(MyDBcontext dBcontext)
        {
            this.dbcontext = dBcontext;
        }
    }
}
