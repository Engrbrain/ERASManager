using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.Mapping
{
    public class GasAccountingREVMapping
    {
        public int Id { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int NumberOfChanges { get; set; }
        [MaxLength(500)]
        public string ReportField { get; set; }
        [MaxLength(50)]
        public string FieldDescription { get; set; }
        [MaxLength(10)]
        public string MappingFields { get; set; }
        public DateTime TimeStamp { get; set; }

        public GasAccountingREVMapping()
        {
            this.LastUpdateDate = DateTime.Today.Date;
            this.TimeStamp = DateTime.Now;
        }
    }

}