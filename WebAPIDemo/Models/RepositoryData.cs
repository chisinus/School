using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models
{
    public class RepositoryData : IRepositoryData
    {
        private WebAPIDemoContext db;

        public RepositoryData(WebAPIDemoContext db)
        {
            this.db = db;
        }

        public IQueryable<OrderData> GetAllOrders()
        {
            return db.Orders;
        }

        public IQueryable<OrderData> GetAllOrdersWithDetails()
        {
            return db.Orders.Include("OrderDetailData");
        }

        public OrderData GetOrder(int id)
        {
            return db.Orders.Include("OrderDetailData.Book")
                        .FirstOrDefault(o => o.ID == id);
        }
    }
}