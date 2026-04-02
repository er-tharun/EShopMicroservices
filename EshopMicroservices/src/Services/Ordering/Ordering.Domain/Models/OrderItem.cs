namespace Ordering.Domain.Models
{
    public class OrderItem : Entity<OrderItemId>
    {
        protected OrderItem()
        {
            
        }
        private OrderItem(Product product, OrderId orderId, int quantity, decimal price)
        {
            ID = OrderItemId.Of(Guid.NewGuid());
            OrderId = orderId;
            Product = product;
            Quantity = quantity;
        }
        public OrderId OrderId { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public static OrderItem Create(OrderItemId id, Product product, OrderId orderId, int quantity)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(orderId.ToString());
            ArgumentOutOfRangeException.ThrowIfNegative(quantity);

            return new OrderItem
            {
                ID = id,
                Product = product,
                OrderId = orderId,
                Quantity = quantity
            };
        }
    }
}
