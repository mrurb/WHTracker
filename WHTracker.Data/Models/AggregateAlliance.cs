﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WHTracker.Data.Models
{
    public class AggregateAlliance : AggregateData
    {

        public int AllianceId { get; set; }

        public Alliance Alliance { get; set; }
    }
}
