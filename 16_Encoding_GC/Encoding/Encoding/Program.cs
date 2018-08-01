using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding ASCII = Encoding.ASCII;
            Encoding Default = Encoding.Default;
            Encoding BigEndianUnicode = Encoding.BigEndianUnicode;
            Encoding Unicode = Encoding.Unicode;
            Encoding UTF32 = Encoding.UTF32;
            Encoding UTF7 = Encoding.UTF7;
            Encoding UTF8 = Encoding.UTF8;
            EncodingInfo[] All = Encoding.GetEncodings();

            //foreach (var t in All)
            //    Console.WriteLine(t.Name);

            string MyString = "lai lai";
            byte[] MyStringEncoded = Encoding.UTF32.GetBytes(MyString);

            //Console.WriteLine(MyString);

            //foreach(byte i in MyStringEncoded)
            //    Console.Write(i + " ");

            string MyUnicodeChars = "Here you can see unicode : (\u03a0) (\u00a1) (\u0129)";

            byte[] UnicodeBytes = Unicode.GetBytes(MyUnicodeChars);
            byte[] AsciiBytes = Encoding.Convert(Unicode, ASCII, UnicodeBytes);

            string MyAsciiChars = ASCII.GetString(AsciiBytes);

            //Console.WriteLine(MyUnicodeChars);
            //Console.WriteLine(MyAsciiChars);

            //Console.WriteLine("с".Equals("c",StringComparison.Ordinal));

            TimeSpan t = new TimeSpan(23,22,22);

            t += TimeSpan.FromHours(72);

            Console.WriteLine(t.ToString());

            Console.ReadKey();

        }
    }
}
