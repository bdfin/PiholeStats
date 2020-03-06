using PiholeStats.App.Data.Models;
using PiholeStats.App.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PiholeStats.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string piholeIp;

            bool repeat;
            do
            {
                repeat = true;

                Console.WriteLine("Enter the PiHole IPv4 address (e.g. 192.168.1.1):");

                piholeIp = Console.ReadLine();

                bool ipIsValid = Validator.IpAddressIsValid(piholeIp);
                if (ipIsValid)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That's not a valid IPv4 address..");
                    Console.WriteLine();
                }

            } while (repeat == true);

            Console.WriteLine();
            Console.WriteLine($"Contacting pihole at: { piholeIp }...");

            Thread.Sleep(500);

            Console.WriteLine();

            PiholeInfo piholeStats = await PiholeService.GetStatsAsync(piholeIp);

            PiholeService.PrintStats(piholeStats);
        }
    }
}
