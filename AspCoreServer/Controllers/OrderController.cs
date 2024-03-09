using AspCoreServer.Model;
using AspCoreServer.Subscriber;

using Microsoft.AspNetCore.Mvc;

namespace AspCoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        protected readonly EventBroker _eventBroker;

        protected readonly OrderSubscriber orderSubscriber;

        public OrderController(EventBroker eventBroker, OrderSubscriber orderSubscriber)
        {
            this._eventBroker = eventBroker;

            this.orderSubscriber = orderSubscriber;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Order model)
        {
            this._eventBroker.Publish(new OrderEvent(model));

            return Ok(model);
        }
    }
}
