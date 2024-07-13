using OrderManagement.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Domain.Entities
{
    [Table("Supplier", Schema = "Supplier")]
    public class Supplier : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
