using PiholeStats.App.Data.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PiholeStats.App.Services
{
    public static class PiholeService
    {
        public static void PrintStats(PiholeInfo piholeStats)
        {
            foreach (PropertyInfo prop in typeof(PiholeInfo).GetProperties())
            {
                string output = $"{ prop.Name }: { prop.GetValue(piholeStats, null) }";
                Thread.Sleep(150);
                Console.WriteLine(output);
            }
        }

        public static async Task<PiholeInfo> GetStatsAsync(string piholeIpAddress)
        {
            string piholeJsonResponse = await GetPiholeJsonAsync(piholeIpAddress);

            PiholeInfo piholeStats = JsonSerializer.Deserialize<PiholeInfo>(piholeJsonResponse);

            return piholeStats;
        }

        private static async Task<string> GetPiholeJsonAsync(string piholeIpAddress)
        {
            string apiEndpoint = $"http://{ piholeIpAddress }/admin/api.php";

            using (var httpClient = new HttpClient())
            using (var response = await httpClient.GetAsync(apiEndpoint))
            using (var content = response.Content)
            {
                var result = await content.ReadAsStringAsync();

                return result;
            }
        }
    }
}
