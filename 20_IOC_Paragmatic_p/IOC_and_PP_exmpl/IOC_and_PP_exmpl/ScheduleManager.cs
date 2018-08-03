namespace IOC_and_PP_exmpl
{
    class ScheduleManager : IScheduleManager
    {
        private int i = 0;
        public string GetSchedule()
        {
            return "Some schedule for this week" + i++;
        }
    }
}