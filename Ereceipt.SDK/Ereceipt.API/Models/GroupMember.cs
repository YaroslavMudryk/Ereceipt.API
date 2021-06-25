using System;
using System.Text.Json.Serialization;
namespace Ereceipt.API.Models
{
    public class GroupMember
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("group")]
        public Group Group { get; set; }
        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}