using System;

namespace eventYouTubeExample
{
    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MessageService: sending a text message ... encoded ->  {0}", e.Video.Title);
        }
    }
}
