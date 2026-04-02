namespace Ordering.Domain.Models
{
    public class Order : Aggregate<OrderId>
    {
        private List<OrderItem> _orderItems => new();
        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
        public CustomerId CustomerId { get; private set; } = default!;
        public OrderName OrderName { get; private set; } = default!;
        public Address BillingAddress { get; private set; } = default!;
        public Address ShippingAddress { get; private set; } = default!;
        public Payment Payment { get; private set; } = default!;
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;
        public decimal TotalPrice 
        {
            get => OrderItems.Sum(x => x.Quantity * x.Price);
            private set { }
        }

        public static Order Create(OrderName orderName, 
            Address billingAddress, 
            Address shippingAddress, 
            Payment payment, 
            OrderStatus orderStatus)
        {
            var order = new Order
            {
                ID = OrderId.Of(Guid.NewGuid()),
                OrderName = orderName,
                BillingAddress = billingAddress,
                ShippingAddress = shippingAddress,
                Payment = payment,
                Status = orderStatus
            };
            order.AddDomainEvent(new OrderCreatedEvent(order));
            return order;
        }

        public void Update(OrderName orderName, Address billingAddress, Address shippingAddress, Payment payment, OrderStatus orderStatus)
        {
            OrderName = orderName;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            Payment = payment;
            Status = orderStatus;

            AddDomainEvent(new OrderUpdatedEvent(this));
        }

        public void Add(ProductId productId, int quantity, decimal price, string name)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(quantity);
            ArgumentOutOfRangeException.ThrowIfNegative(price);

            var orderItem = OrderItem.Create(OrderItemId.Of(Guid.NewGuid()),productId, ID,quantity);
            _orderItems.Add(orderItem);
        }
    }
}
