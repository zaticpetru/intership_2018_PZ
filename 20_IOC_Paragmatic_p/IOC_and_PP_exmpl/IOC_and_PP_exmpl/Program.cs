using System;
using Ninject.Modules;
using Ninject;
using System.Threading;

namespace IOC_and_PP_exmpl
{
    interface IScheduleManager
    {
        string GetSchedule();
    }

    interface IScheduleViewer
    {
        void ViewSchedule();
    }

    class ScheduleManager : IScheduleManager
    {
        private int i = 0;
        public string GetSchedule()
        {
            return "Some schedule for this week" + i++;
        }
    }

    class ScheduleViewerForTesting : IScheduleViewer
    {
        private IScheduleManager _scheduleManager;

        public ScheduleViewerForTesting(IScheduleManager scheduleManager)
        {
            _scheduleManager = scheduleManager;
        }

        public void ViewSchedule()
        {
            Console.WriteLine(_scheduleManager.GetSchedule());
        }
    }

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

    class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IScheduleManager>().To<ScheduleManager>().InSingletonScope();
            //Bind<IScheduleManager>().To<ScheduleManager>().InThreadScope();

            Bind<IScheduleViewer>().To<ScheduleViewer>();
            //Bind<IScheduleViewer>().To<ScheduleViewerForTesting>();
            // the bottom line is optional 
            //Bind<ScheduleViewer>().ToSelf();
        }
    }
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