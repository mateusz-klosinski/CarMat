using CarMat.Repositories;
using CarMat.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Controllers.API
{
    [Authorize]
    [Route("api/Notifications")]
    public class NotificationController : Controller
    {
        private INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }


        [HttpGet("GetNotifications")]
        public IActionResult GetNotifications()
        {
            var username = User.Identity.Name;

            var notifications = _service.GetNotReadNotifications(username);

            return Ok(notifications);
        }


        [HttpPost("ReadNotifications")]
        public IActionResult ReadNotifications()
        {
            var username = User.Identity.Name;

            _service.ReadUserNotifications(username);

            return Ok();
        }
    }
}
