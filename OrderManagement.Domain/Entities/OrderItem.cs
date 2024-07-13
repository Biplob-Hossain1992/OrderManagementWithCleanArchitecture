using OrderManagement.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Domain.Entities
{
    [Table("OrderItem", Schema = "Order")]
    public class OrderItem : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
    }
}
