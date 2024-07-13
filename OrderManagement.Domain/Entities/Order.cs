using OrderManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Entities
{
    [Table("Order", Schema = "Order")]
    public class Order: BaseEntity<int>
    {
        public int ReferenceId { get; set; }
        public string OrderNo { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public int SupplierId { get; set; }
        public DateTime ExpectedDate { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; } = string.Empty;
    }
}
