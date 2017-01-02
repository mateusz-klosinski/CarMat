using CarMat.Repositories;
using CarMat.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMat.Controllers.API
{
    [Route("api/Notifications")]
    public class NotificationController : Controller
    {
        private INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }
    }
}
