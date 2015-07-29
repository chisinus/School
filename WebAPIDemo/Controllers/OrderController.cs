using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class OrderController : ApiController
    {
        private IRepositoryData _repo;

        public OrderController(IRepositoryData repo)
        {
            _repo = repo;
        }

        public IQueryable<OrderData> Get()
        {
            return _repo.GetAllOrders();
        }

        public IQueryable<OrderData> Get(bool includeDetails)
        {
            return (includeDetails)
                        ? _repo.GetAllOrdersWithDetails()
                        : _repo.GetAllOrders();
        }

        public OrderData Get(int id)
        {
            return _repo.GetOrder(id);
        }
    }
}
