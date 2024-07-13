using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.ViewModel
{
    public class VmResponseMessage
    {
        public string Message { get; set; } = "An Error Occurred";
        public string Type { get; set; } = "Error";
    }
}
