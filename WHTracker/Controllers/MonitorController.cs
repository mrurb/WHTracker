using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using WHTracker.Services.Models;
using WHTracker.Services.Workers;

namespace WHTracker.Controllers
{
    public class MonitorController : Controller
    {
        private readonly IBackgroundTaskQueue<IEnumerable<KillmailHash>> killmailHashBackgroundQueue;
        private readonly IBackgroundTaskQueue<IEnumerable<KillmailValue>> killmailValueBackgroundQueue;

        public MonitorController(IBackgroundTaskQueue<IEnumerable<KillmailHash>> KillmailHashBackgroundQueue, IBackgroundTaskQueue<IEnumerable<KillmailValue>> KillmailValueBackgroundQueue)
        {
            killmailHashBackgroundQueue = KillmailHashBackgroundQueue;
            killmailValueBackgroundQueue = KillmailValueBackgroundQueue;
        }

        public IActionResult Index()
        {
            ViewData["KillMailHash"] = killmailHashBackgroundQueue.GetQueueLength();
            ViewData["KillMailValue"] = killmailValueBackgroundQueue.GetQueueLength();

            return View();
        }
    }
}
