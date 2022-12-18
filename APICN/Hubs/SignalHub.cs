using API_HTGT.DAO;
using Microsoft.AspNetCore.SignalR;

namespace APICN.Hubs
{
    public class SignalHub : Hub
    {
        public async Task SendNguoiDung(User nguoiDung)
        {
            await Clients.All.SendAsync("ReceiveLocation", nguoiDung);
        }
        public async Task SendLocation(string Location)
        {
            await Clients.All.SendAsync("ReceiveLocation", Location);
        }

    }
}

