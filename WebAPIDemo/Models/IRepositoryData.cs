using System.Linq;

namespace WebAPIDemo.Models
{
    public interface IRepositoryData
    {
        IQueryable<OrderData> GetAllOrders();
        IQueryable<OrderData> GetAllOrdersWithDetails();
        OrderData GetOrder(int id);
    }
}