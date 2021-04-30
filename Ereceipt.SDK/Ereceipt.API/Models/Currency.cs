using System.Text.Json.Serialization;

namespace Ereceipt.API.Models
{
    public class Currency
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("isoFormat")]
        public int ISOFormat { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("countries")]
        public string Countries { get; set; }
    }
}