using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace PiholeStats.App.Models
{
    public class PiholeStatsModel
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("dns_queries_today")]
        [Display(Name = "DNS Queries")]
        public int DnsQueriesToday { get; set; }

        [JsonPropertyName("ads_blocked_today")]
        [Display(Name = "Ads Blocked")]
        public int AdsBlockedToday { get; set; }

        [JsonPropertyName("ads_percentage_today")]
        [Display(Name = "% Blocked")]
        public decimal PercentBlockedToday { get; set; }

        [JsonPropertyName("queries_forwarded")]
        [Display(Name = "Queries Forwarded")]
        public int QueriesForwarded { get; set; }

        [JsonPropertyName("queries_cached")]
        [Display(Name = "Queries Cached")]
        public int QueriesCached { get; set; }
    }
}
