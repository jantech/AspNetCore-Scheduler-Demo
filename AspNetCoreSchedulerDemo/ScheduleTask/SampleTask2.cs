using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSchedulerDemo.BackgroundService;
using AspNetCoreSchedulerDemo.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreSchedulerDemo.ScheduleTask
{
    public class SampleTask2 : ScheduledProcessor
    {
        public SampleTask2(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {

        }

        protected override string Schedule => "*/2 * * * *"; // every 1 min 

        public override Task ProcessInScope(IServiceProvider scopeServiceProvider)
        {
            Console.WriteLine("SampleTask2 : " + DateTime.Now.ToString());

            IReportGenerator reportGenerator = scopeServiceProvider.GetRequiredService<IReportGenerator>();
            reportGenerator.GenerateDailyReportAsync();

            return Task.CompletedTask;
        }
    }
}
