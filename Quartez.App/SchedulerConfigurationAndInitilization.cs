using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartez.App
{
    public class SchedulerConfigurationAndInitilization
    {
        //StdSchedulerFactory,JobBuilder,TriggerBuilder
        public static async Task<IScheduler> StartSchedulerAsync()
        {
           //1)Scheduler tanımlanır ve başlatılır- zamanlayıcı
           IScheduler  scheduler = await new StdSchedulerFactory().GetScheduler();
           await scheduler.Start();

            JobKey jobKeyName = new JobKey("ShowTimeJob");
           //2)Jobbuilder ile Job tanımı yapılır ve build edilir - İş 
           IJobDetail showTimeJob = JobBuilder.Create<ShowTimeJob>()
                     .WithIdentity(jobKeyName)
                     .Build();


            //3)Job'ın çalışma bilgileri 
            //Belirtilen Job Nezaman çalımaya başalaycak ve ne aralıklarla çalışacaktır ,Trigger    - Zamanlayıcı ve işin Birleştirilmesi 
            TriggerKey triggerKeyName = new TriggerKey("ShowTimeJob");
            ITrigger triggerSettingsForShowTimeJobs = TriggerBuilder.Create()
                          .WithIdentity(triggerKeyName)
                          .StartNow()
                          .WithSimpleSchedule(work => work.WithIntervalInSeconds(3).RepeatForever())
                          .Build();
            //.WithCronSchedule("* 0 0 ? * * *");


            //ITrigger triggerSettingsForShowTimeJobsV2 = TriggerBuilder.Create()
            //              .WithIdentity(triggerKeyName)
            //              .StartAt(new DateTimeOffset(2022,7,1,14,10,0,0,new TimeSpan()))
            //              .WithSimpleSchedule(work => work.WithIntervalInSeconds(1).RepeatForever())
            //              .Build();

            //4)Job'ın çalışma bilgileri job'ı bir araya getirdiğimiz yer
            var result = await scheduler.ScheduleJob(showTimeJob, triggerSettingsForShowTimeJobs);


           return scheduler;

        }
    }
}
