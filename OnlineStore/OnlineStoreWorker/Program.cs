using System;
using System.Configuration;
using OnlineStoreWorker.Messaging;

namespace OnlineStoreWorker
{
    class Program
    {
        static Configuration Configuration;

        static void Main(string[] args)
        {

            var onlineStoreMq = new OnlineStoreMq();

            Console.WriteLine("Starting to read from the queue");

            while (true)
            {
                onlineStoreMq.ConsumeMessage();
            }

        }


        
    }
}
