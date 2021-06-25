using System.Text.Json.Serialization;
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