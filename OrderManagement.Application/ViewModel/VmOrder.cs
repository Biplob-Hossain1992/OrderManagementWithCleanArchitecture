using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.ViewModel
{
    #nullable disable
    public class VmOrder
    {
        public int Id { get; set; }
        public int ReferenceId { get; set; }
        public string OrderNo { get; set; }
        public string OrderDateString { get; set; }
        public DateTime OrderDate { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ExpectedDateString { get; set; }
        public DateTime ExpectedDate { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
    }
}
