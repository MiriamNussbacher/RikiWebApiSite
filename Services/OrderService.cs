using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.Extensions.Logging;
using Repositories;
namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        IProductRepository _productRepository;
        ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            //_logger = logger;
        }
        private async Task<double> checkOrderSum(ICollection<OrderItem> orderItems)
        {
            double totalSum = 0;
            orderItems.ToList().ForEach(async item => { totalSum += (await _productRepository.getProductById(item.ProductId)).Price * item.Quantity; } );
            return totalSum;
        }

        public async Task<Order> createOrder(Order newOrder)
        {

            double totoalSum = await checkOrderSum(newOrder.OrderItems);
            //if(totoalSum!= newOrder.OrderSum)
            //    _logger.LogInformation("total sum != OrderSum")
            newOrder.OrderSum = (decimal)totoalSum;
            newOrder.Date = DateTime.UtcNow;
            return await _orderRepository.createOrder(newOrder);
        }


        public async Task<Order> getOrderById(int id)
        {
            double x;
            return await _orderRepository.getOrderById(id);
        }
    }
}
