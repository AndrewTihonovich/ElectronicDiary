using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicDiary.WebApi.Models.Report
{
    public class ReportReq
    {
        public DateTime StartData { get; set; }
        public DateTime EndData { get; set; }

    }
}
