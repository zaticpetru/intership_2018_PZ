using System;
using System.Threading;

namespace IOC_and_PP_exmpl
{
    class ScheduleViewer : IScheduleViewer
    {
        private IScheduleManager _scheduleManager;

        public ScheduleViewer(IScheduleManager scheduleManager)
        {
            _scheduleManager = scheduleManager;
        }

        public void ViewSchedule()
        {
            Console.WriteLine("Rendering image and creating windows");
            Thread.Sleep(1000);
            Console.WriteLine(_scheduleManager.GetSchedule());
        }
    }
}