using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSchedulerDemo.Services
{
    public class ReportGenerator : IReportGenerator
    {
        public ReportGenerator()
        {
                
        }

        public string GenerateDailyReport()
        {
            Console.WriteLine("GenerateDailyReport : " + DateTime.Now.ToString());

            return "GenerateDailyReport";
        }
    }
}
