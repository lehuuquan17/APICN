using API_HTGT.DAO;
using APICN.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace APICN.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationController : Controller
    {


        private readonly IHubContext<SignalHub> hubContext;
        public LocationController(IHubContext<SignalHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        [HttpGet]
        [Route("Pushnguoidung")]

        public IActionResult Pushnguoidung(Guid ID, string TrangThai)
        {
            User user = new User();
            user.ID = ID;
            user.TrangThai = TrangThai;
            hubContext.Clients.All.SendAsync("Receivenguoidung", user);
            return Ok("Done");
        }
        [HttpGet]
        [Route("PushLocation")]
        public IActionResult PushLocation( string Location)
        {
          
            hubContext.Clients.All.SendAsync("ReceiveLocation", Location);
            return Ok("Done");
        }

    }
}
