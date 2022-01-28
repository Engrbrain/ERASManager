using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.RevisedBackAllocation
{
    public class RBK_TransactionalData
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        [MaxLength(50)]
        public string Well { get; set; }
        public double LiquidPotential { get; set; }
        public double OilPotential { get; set; }
        public double GasPotential { get; set; }
        public double CFBPlatformOilPotential { get; set; }
        public double WFBPlatformOilPotential { get; set; }
        public double CFBPlatformAllocatedProd { get; set; }
        public double WFBPlatformAllocatedProd { get; set; }
        public double WellAllocatedProd { get; set; }
        public double WellAllocatedWaterProd { get; set; }
        public double WellAllocatedGasProd { get; set; }
        public DateTime TimeStamp { get; set; }
        public RBK_TransactionalData()
        {
            this.TimeStamp = DateTime.Now;
        }
    }

}