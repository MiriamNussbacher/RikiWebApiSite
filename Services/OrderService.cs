using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositories;
namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> createOrder(Order newOrder)
        {

            newOrder.Date = new DateTime();
            return await _orderRepository.createOrder(newOrder);
        }


        public async Task<Order> getOrderById(int id)
        {
            return await _orderRepository.getOrderById(id);
        }
    }
}
