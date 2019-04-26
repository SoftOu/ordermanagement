using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Models
{
    /// <summary>
    /// Order view model.
    /// </summary>
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal OrderValue { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string OrderDateString { get; set; }
        public string OrderValueString { get; set; }
    }
}
