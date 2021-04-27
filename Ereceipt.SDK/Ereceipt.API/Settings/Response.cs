using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ereceipt.API.Settings
{
    public class Response<T>
    {
        [JsonPropertyName("ok")]
        public bool OK { get; set; }
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}
