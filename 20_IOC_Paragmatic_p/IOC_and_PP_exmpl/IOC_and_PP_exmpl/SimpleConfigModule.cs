using Ninject.Modules;

namespace IOC_and_PP_exmpl
{
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
}