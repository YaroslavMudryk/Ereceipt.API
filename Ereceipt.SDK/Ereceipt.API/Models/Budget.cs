using System;
using System.Text.Json.Serialization;
namespace Ereceipt.API.Models
{
    public class Budget
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("balance")]
        public double Balance { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("startPeriod")]
        public DateTime StartPeriod { get; set; }
        [JsonPropertyName("endPeriod")]
        public DateTime EndPeriod { get; set; }
        [JsonPropertyName("group")]
        public Group Group { get; set; }
        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }
    }
}