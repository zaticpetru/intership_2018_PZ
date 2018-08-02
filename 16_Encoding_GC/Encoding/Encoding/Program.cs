using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

            //Console.WriteLine(t.ToString());

            DateTime datetime = new DateTime(1998, 08, 22); // kind unspecified

            DateTime datetimeUTC = new DateTime(1998, 08, 22, 0, 0, 0, DateTimeKind.Utc);

            DateTime datetimeLocal = new DateTime(1998,08,22,0,0,0,DateTimeKind.Local);

            DateTimeOffset datetimeOffset = datetimeLocal;

            //Console.WriteLine(datetimeOffset.ToString());
            //Console.WriteLine(datetimeLocal.ToString());
            //Console.WriteLine(datetimeOffset.DateTime == datetimeUTC);
            //Console.WriteLine(datetimeOffset.DateTime == datetime);

            //Console.WriteLine(datetimeLocal.ToUniversalTime());
            //Console.WriteLine(datetimeLocal.ToUniversalTime().ToLocalTime());
            //Console.WriteLine(datetimeOffset.ToUniversalTime());
            //Console.WriteLine(datetimeOffset.ToLocalTime());

            TimeZone timeZone = TimeZone.CurrentTimeZone;

            Console.OutputEncoding = Encoding.UTF8;

            //Console.WriteLine(timeZone.StandardName);
            //Console.WriteLine(timeZone.DaylightName);

            TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;

            //Console.WriteLine();
            //Console.WriteLine(timeZoneInfo.Id);
            //Console.WriteLine(timeZoneInfo.StandardName);
            //Console.WriteLine(timeZoneInfo.SupportsDaylightSavingTime);

            NumberFormatInfo numberFormatInfo = NumberFormatInfo.CurrentInfo;
            DateTimeFormatInfo dateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo;
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;

            //Console.WriteLine(equ, nameof(numberFormatInfo.CurrencyDecimalDigits),numberFormatInfo.CurrencyDecimalDigits);
            //Console.WriteLine(equ, nameof(numberFormatInfo.CurrencyDecimalSeparator), numberFormatInfo.CurrencyDecimalSeparator);
            //Console.WriteLine(equ, nameof(numberFormatInfo.CurrencyGroupSeparator), numberFormatInfo.CurrencyGroupSeparator);
            //Console.WriteLine(equ, nameof(numberFormatInfo.CurrencyGroupSizes), numberFormatInfo.CurrencyGroupSizes);
            //Console.WriteLine(equ, nameof(numberFormatInfo.CurrencyNegativePattern), numberFormatInfo.CurrencyNegativePattern);
            //Console.WriteLine(equ, nameof(numberFormatInfo.CurrencyPositivePattern), numberFormatInfo.CurrencyPositivePattern);
            //Console.WriteLine(equ, nameof(numberFormatInfo.CurrencySymbol), numberFormatInfo.CurrencySymbol);
            //Console.WriteLine(equ, nameof(numberFormatInfo.DigitSubstitution), numberFormatInfo.DigitSubstitution);
            //Console.WriteLine(equ, nameof(numberFormatInfo.IsReadOnly), numberFormatInfo.IsReadOnly);
            //Console.WriteLine(equ, nameof(numberFormatInfo.NaNSymbol), numberFormatInfo.NaNSymbol);
            //Console.WriteLine(equ, nameof(numberFormatInfo.NativeDigits), numberFormatInfo.NativeDigits);
            //Console.WriteLine(equ, nameof(numberFormatInfo.NegativeInfinitySymbol), numberFormatInfo.NegativeInfinitySymbol);

            //DisplayProperties(numberFormatInfo);
            //DisplayProperties(dateTimeFormatInfo);
            //DisplayProperties(cultureInfo);

            using(FileStream fs = new FileStream("TestFile.txt", FileMode.OpenOrCreate))
            {
                string str = "A testing string";
                fs.Write(UTF32.GetBytes(str), 0, UTF32.GetByteCount(str));
            }

            Console.ReadKey();

        }

        public static void DisplayProperties(object o)
        {
            var props = o.GetType().GetProperties();
            foreach (var p in props)
                Console.WriteLine("{0} = {1}", p.Name, p.GetValue(o, null));
        }
    }
}
