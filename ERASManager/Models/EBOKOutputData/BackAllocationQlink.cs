﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKOutputData
{
    public class BackAllocationQlink
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double Well { get; set; }
        public double Qlink { get; set; }
    }
}