using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.RevisedBackAllocation
{
    public class RBackDateWellSelector
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        [MaxLength(50)]
        public string Well { get; set; }
    }

}