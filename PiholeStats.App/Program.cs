using PiholeStats.App.Models;
using PiholeStats.App.Services;
using System;
using System.Reflection;
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
                repeat = false;

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
                }

            } while (repeat == false);


            Console.WriteLine();
            Console.WriteLine($"Contacting pihole at: { piholeIp }...");

            Thread.Sleep(500);

            Console.WriteLine();

            var piholeStats = await PiholeService.GetStatsAsync(piholeIp);

            foreach (PropertyInfo prop in typeof(PiholeStatsModel).GetProperties())
            {
                string output = $"{ prop.Name }: { prop.GetValue(piholeStats, null) }";
                Thread.Sleep(150);
                Console.WriteLine(output);
            }

        }
    }
}
