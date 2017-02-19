using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HighStocks.Models
{
    public class Report
    {
        public DateTime ReportDate { get; set; }

        public decimal ReportAmount { get; set; }
    }
}