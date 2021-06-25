using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Ereceipt.API.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
        [JsonPropertyName("receipts")]
        public List<Receipt> Receipts { get; set; }
        [JsonPropertyName("groupMembers")]
        public List<GroupMember> GroupMembers { get; set; }
    }
}