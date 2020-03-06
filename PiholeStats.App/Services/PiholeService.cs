using PiholeStats.App.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PiholeStats.App.Services
{
    public static class PiholeService
    {
        public static async Task<PiholeStatsModel> GetStatsAsync(string piholeIpAddress)
        {
            string piholeJsonResponse = await GetPiholeJsonAsync(piholeIpAddress);

            PiholeStatsModel piholeStats = JsonSerializer.Deserialize<PiholeStatsModel>(piholeJsonResponse);

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
