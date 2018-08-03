using System;
using Ninject;

namespace IOC_and_PP_exmpl
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new SimpleConfigModule());

            IScheduleViewer scheduleViewer = kernel.Get<IScheduleViewer>();

            scheduleViewer.ViewSchedule();

            var viewer = kernel.Get<IScheduleViewer>();

            viewer.ViewSchedule();

            IScheduleManager t1 = kernel.Get<IScheduleManager>();
            var t2 = kernel.Get<IScheduleManager>();

            Console.WriteLine("\nt1 == t2 = {0}\nscheduleViewer == viewer = {1}\n",t1 == t2, scheduleViewer == viewer);

            var testViewer = new ScheduleViewerForTesting(kernel.Get<IScheduleManager>());
            testViewer.ViewSchedule();
            testViewer.ViewSchedule();
            testViewer.ViewSchedule();
            testViewer.ViewSchedule();

            Console.WriteLine();
            var testViewer2 = new ScheduleViewerForTesting(new ScheduleManager());
            testViewer2.ViewSchedule();
            testViewer2.ViewSchedule();
            testViewer2.ViewSchedule();
            testViewer2.ViewSchedule();

            Console.ReadKey();
        }
    }
}