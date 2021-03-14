using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
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