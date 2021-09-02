using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MovieMates_Backend.Hubs;

namespace MovieMates_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IHubContext<NotificationHub> _notificationHub;

        public MessageController(IHubContext<NotificationHub> notificationHub)
        {
            _notificationHub = notificationHub;
        }



        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> SendMessage([FromBody] Message msg)
        {
            await _notificationHub.Clients.All.SendAsync("sendToUser", msg.msgHeader,msg.msgContext);
            return Ok("Message Send!");
        }

    }
}
