using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> createOrder(Order newOrder);
        Task<Order> getOrderById(int id);

    }
}