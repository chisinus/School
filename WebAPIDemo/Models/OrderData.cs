using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class OrderData
    {
        public OrderData()
        {
            OrderDetails = new List<OrderDetailData> { };
        }

        public int ID { get; set; }
        public string Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ICollection<OrderDetailData> OrderDetails { get; set; }
    }
}