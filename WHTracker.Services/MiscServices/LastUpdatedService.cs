using System;
using System.Collections.Generic;
using System.Text;

namespace WHTracker.Services.MiscServices
{
    public class LastUpdatedService
    {
        public LastUpdatedService()
        {
            Time = new DateTime();
        }

        public DateTime Time { get; private set; }


        public void UpdateTime()
        {
            Time = DateTime.UtcNow;
        }
    }
}
