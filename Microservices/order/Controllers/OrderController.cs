using Microsoft.AspNetCore.Mvc;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Order
            {
                Date = DateTime.Now.AddDays(index),
                cost=100,
                id=1

            })
            .ToArray();
        }
        [HttpGet]
        [Route("{id}")]
        public Order GetById(int id)
        {
            var order = new Order
            {
                Date = DateTime.Now,
                cost = 100,
                id = id
            };
            _logger.LogInformation("order data {@order}",order);
            return order;
        }
        [HttpPost]
        public bool Post(Order order)
        {
            try
            {
                _logger.LogInformation("save order:" + order.id);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}