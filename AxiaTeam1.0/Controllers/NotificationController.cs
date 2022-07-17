using AxiaTeam1._0.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Controllers
{
    [Route("api/notification")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        protected readonly IHubContext<ChatHub> _hub;

        public NotificationController([NotNull] IHubContext<ChatHub> hub)
        {
            _hub = hub;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MessagePost messagePost)
        {
            await _hub.Clients.All.SendAsync("sendToReact", "The message '" + messagePost.Message + "' has been received");

            return Ok();
        }
    }

    public class MessagePost
    {
        public virtual string Message { get; set; }
    }
}

