using System;
using System.Text.Json.Serialization;
namespace Ereceipt.API.Models.Helpers
{
    public class Token
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
        [JsonPropertyName("expiredAt")]
        public DateTime ExpiredAt { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}