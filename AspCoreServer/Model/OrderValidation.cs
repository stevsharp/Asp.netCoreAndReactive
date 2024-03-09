using FluentValidation;

namespace AspCoreServer.Model
{

    public class OrderValidation : AbstractValidator<Order>
    {
        public OrderValidation()
        {
            RuleFor(request => request.Customer)
                   .Must(x => !string.IsNullOrWhiteSpace(x))
                        .WithMessage($" {nameof(Order.Customer)} is required!");


            RuleFor(request => request.Item)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                    .WithMessage($" {nameof(Order.Item)} is required!");


            RuleFor(request => request.OrderId)
                .Must(x=>ValidateOrder(x.ToString()))
                    .WithMessage($" {nameof(Order.OrderId)} is required!");
        }

        private bool ValidateOrder(string orderId)
        {
            return Guid.TryParse(orderId, out _);
        }
    }
}
