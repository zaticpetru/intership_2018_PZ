using System;
using System.Threading;

namespace eventYouTubeExample
{

    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }
    class VideoEncoder
    {
        //1 - define a delegate
        //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);


        //EventHandler instead of create custom delegate
        //EventHandler<TEventArgs>

        public event EventHandler<VideoEventArgs> VideoEncoded;

        //2 - define an event based on that delegate
        //public event VideoEncodedEventHandler VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video ...");
            Thread.Sleep(1500);
            
        //3.2 - Raise the event
            OnVideoEncoded(video);
        }
        
        //3.1 - Raise the event
        protected virtual void OnVideoEncoded(Video video)
        {
            VideoEncoded?.Invoke(this, new VideoEventArgs() {Video = video});
        }
    }
}
