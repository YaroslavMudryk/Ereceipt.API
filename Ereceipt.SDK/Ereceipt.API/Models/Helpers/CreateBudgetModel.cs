using System;
namespace Ereceipt.API.Models.Helpers
{
    public class CreateBudgetModel
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Description { get; set; }
        public DateTime StartPeriod { get; set; }
        public DateTime EndPeriod { get; set; }
        public Guid GroupId { get; set; }
        public int CurrencyId { get; set; }
    }
}