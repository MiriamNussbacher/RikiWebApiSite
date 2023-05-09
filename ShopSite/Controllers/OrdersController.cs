using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;
        IMapper _mapper;
        public OrdersController(IOrderService orderService,IMapper mapper)
        {
            _mapper = mapper; 
            _orderService = orderService;
        }

        //GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {

            Order order = await _orderService.getOrderById(id);
            OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order);
            return orderDTO == null? NoContent():Ok(orderDTO);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orderFromBody)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderFromBody); 
            Order orderCreated = await _orderService.createOrder(order);
            OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(orderCreated);
            return CreatedAtAction(nameof(Get), new { OrderId = orderDTO.OrderId }, orderDTO);
        }

    }
}
