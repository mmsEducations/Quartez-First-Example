using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartez.App
{
    public class ShowTimeJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            WriteTimeNow();
            WriteMessage();
            return Task.CompletedTask;
        }

        private static void WriteTimeNow()
        {
            var timeNow = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine($"ShowTimeJob is working at : {timeNow}");
        }

        public void WriteMessage()
        {
            Console.WriteLine("--------------------------------");
        }
    }
}

//IJobtan Miras alınarak Execute metodu imlemente edilir yapmak istediğimiz işlemler  Execute metodu içerisine yazılır

#region MyRegion


//if (Directory.Exists(@"C:\Job"))
//{

//}

#endregion