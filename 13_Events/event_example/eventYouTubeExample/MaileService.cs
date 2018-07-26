using System;

namespace eventYouTubeExample
{
    public class MaileService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("Mail service: sending an email ... encoded ->  {0}", e.Video.Title);
        }
    }
}
