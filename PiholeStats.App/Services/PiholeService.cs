using PiholeStats.App.Data;
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
            string output = $"Pihole Stats (Today): \n \n";
            output += $"Status: { piholeStats.Status } \n";
            output += $"DNS Queries: { piholeStats.DnsQueriesToday } \n";
            output += $"Ads Blocked: { piholeStats.AdsBlockedToday} \n";
            output += $"% Blocked: { Math.Round(piholeStats.PercentBlockedToday, 2) } \n";
            output += $"Queries Forwarded: { piholeStats.QueriesForwarded } \n";
            output += $"Queries Cached: { piholeStats.QueriesCached } \n";

            Console.WriteLine(output);
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
