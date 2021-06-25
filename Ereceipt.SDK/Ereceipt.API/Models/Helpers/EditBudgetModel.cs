using System;
namespace Ereceipt.API.Models.Helpers
{
    public class EditBudgetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Description { get; set; }
        public DateTime StartPeriod { get; set; }
        public DateTime EndPeriod { get; set; }
        public int? CurrencyId { get; set; }
    }
}