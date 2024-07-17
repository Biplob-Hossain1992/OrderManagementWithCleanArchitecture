using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Domain.Entities
{
    [Table("OrderItem", Schema = "Order")]
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; } // Removed foreign key relation. if you want could keep FK Relation
        public int ItemId { get; set; } // Removed foreign key relation. if you want could keep FK Relation
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
    }
}
