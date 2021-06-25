namespace Ereceipt.API.Models.Helpers
{
    public class CreateProductModel
    {
        public string Id { get; set; }
        public double CountWeight { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}