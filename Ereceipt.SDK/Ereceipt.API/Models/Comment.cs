using System;
using System.Text.Json.Serialization;
namespace Ereceipt.API.Models
{
    public class Comment
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("user")]
        public User User { get; set; }
        [JsonPropertyName("receipt")]
        public Receipt Receipt { get; set; }
        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}