using AspCoreServer.Model;

using System.Reactive.Subjects;

namespace AspCoreServer
{
    public class EventBroker : IObservable<OrderEvent>
    {
        private readonly Subject<OrderEvent> subscriptions = new();
        public IDisposable Subscribe(IObserver<OrderEvent> observer)
        {
            return subscriptions.Subscribe(observer);
        }

        public void Publish(OrderEvent ord)
        {
            subscriptions.OnNext(ord);
        }
    }
}