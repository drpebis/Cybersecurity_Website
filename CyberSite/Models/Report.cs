using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CyberSite.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string ReportType { get; set; }
        public string ReportDescription { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReportDate { get; set; }
    }
}
