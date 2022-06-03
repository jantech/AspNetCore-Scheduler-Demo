using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task GenerateDailyReportAsync()
        {
            var fileName = "GenerateDailyReport_" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".txt";
            Console.WriteLine(fileName);

            // Get the current directory.
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TaskFiles");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string targetPath = Path.Combine(path, fileName);
            Console.WriteLine("The current directory is {0}", targetPath);

            // write your logic Async

            string[] lines =
            {
                "First line", "Second line", "Third line", DateTime.Now.ToString()
            };

            await File.WriteAllLinesAsync(targetPath, lines);

            await Task.Run(() =>
            {
                return true;
            });
        }
    }
}
