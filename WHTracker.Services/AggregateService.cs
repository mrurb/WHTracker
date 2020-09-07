using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHTracker.Data;
using WHTracker.Services.Models;

namespace WHTracker.Services
{
    public class AggregateService
    {
        private readonly ApplicationContext context;


        public AggregateService(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task ProcessKillmail(Killmail killmail)
        {

        }

        public async Task ProcessKillmailValue(Killmail killmail, float value)
        {

        }
    }
}
