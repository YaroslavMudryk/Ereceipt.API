using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace Ereceipt.API.Models
{
    public class Receipt
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }
        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
        [JsonPropertyName("shopName")]
        public string ShopName { get; set; }
        [JsonPropertyName("totalPrice")]
        public double TotalPrice { get; set; }
        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }
        [JsonPropertyName("isImportant")]
        public bool IsImportant { get; set; }
        [JsonPropertyName("canEdit")]
        public bool CanEdit { get; set; }
        [JsonPropertyName("receiptType")]
        public ReceiptType ReceiptType { get; set; }
        [JsonPropertyName("user")]
        public User User { get; set; }
        [JsonPropertyName("group")]
        public Group Group { get; set; }
        [JsonPropertyName("commentsCount")]
        public int CommentsCount { get; set; }
    }

    public enum ReceiptType
    {
        Paymant,
        Internal
    }
}