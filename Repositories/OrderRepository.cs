using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        ShopDbContext _shopDbContext;
        public OrderRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        
        public async Task<Order> createOrder(Order newOrder)
        {
            await _shopDbContext.Orders.AddAsync(newOrder);
            await _shopDbContext.SaveChangesAsync();
            return newOrder;

        }

        public async Task<Order> getOrderById(int id)
        {
            Order order=await _shopDbContext.Orders.FindAsync(id);
            return order;

        }
    }
}
