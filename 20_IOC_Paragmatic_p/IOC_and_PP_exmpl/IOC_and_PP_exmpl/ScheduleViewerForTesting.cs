using System;

namespace IOC_and_PP_exmpl
{
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
}