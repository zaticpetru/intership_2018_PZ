using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace eventYouTubeExample
{
    public class Video
    {
        public string Title;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "Video test" };
            var videoEncoder = new VideoEncoder(); // publuisher
            var mailService = new MaileService(); // subscriber 
            var messageService = new MessageService(); // subscriber

            //videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            WeakEventManager<VideoEncoder, VideoEventArgs>.AddHandler(videoEncoder, "VideoEncoded", mailService.OnVideoEncoded);

            videoEncoder.Encode(video);

            Console.ReadKey();
        }
    }
}
