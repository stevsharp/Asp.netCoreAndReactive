using AspCoreServer.Model;

namespace AspCoreServer.Subscriber
{
    public class OrderSubscriber
    {
        protected readonly EventBroker eventBroker;

        public OrderSubscriber(EventBroker eventBroker)
        {
            this.eventBroker = eventBroker;

            this.eventBroker.Subscribe(x =>
            {
                ShowEvent(x.Order);
            });

        }

        private void ShowEvent(Order order)
        {
            Console.WriteLine(order);
        }
    }
}
