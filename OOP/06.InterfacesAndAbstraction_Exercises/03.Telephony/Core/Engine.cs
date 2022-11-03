

namespace Telephony.Core
{
    using Telephony.IO.Contracts;
    using Models;
    using Contracts;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly StationaryPhone stationaryPhone;
        private readonly Smartphone smartphone;

        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = this.reader.ReadLine().Split(" ");
            string[] urls = this.reader.ReadLine().Split(" ");

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                if (phoneNumbers[i].Any(ch => !char.IsDigit(ch)))
                {
                    this.writer.WriteLine("Invalid number!");
                }
                else if (phoneNumbers[i].Length == 10)
                {
                    this.writer.WriteLine(this.smartphone.Call(phoneNumbers[i]));
                }
                else if (phoneNumbers[i].Length == 7)
                {
                    this.writer.WriteLine(this.stationaryPhone.Call(phoneNumbers[i]));
                }
            }

            for (int i = 0; i < urls.Length; i++)
            {
                if (urls[i].Any(ch => char.IsDigit(ch)))
                {
                    this.writer.WriteLine("Invalid URL!");
                }
                else
                {
                    this.writer.WriteLine(this.smartphone.Browse(urls[i]));
                }
            }
        }
    }
}
