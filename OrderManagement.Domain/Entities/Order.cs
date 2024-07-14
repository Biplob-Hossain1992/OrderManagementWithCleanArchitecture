using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Domain.Entities
{
    [Table("Order", Schema = "Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int ReferenceId { get; set; }
        public string OrderNo { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public int SupplierId { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string Remarks { get; set; } = string.Empty;
    }
}
