namespace Ordering.Domain.Models
{
    public class OrderItem : Entity<OrderItemId>
    {
        protected OrderItem()
        {
            
        }
        private OrderItem(ProductId productid, OrderId orderId, int quantity, decimal price)
        {
            ID = OrderItemId.Of(Guid.NewGuid());
            OrderId = orderId;
            ProductId = productid;
            Quantity = quantity;
            Price = price;
        }
        public OrderId OrderId { get; private set; }
        public ProductId ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public static OrderItem Create(OrderItemId id, ProductId productid, OrderId orderId, int quantity, decimal price)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(orderId.ToString());
            ArgumentOutOfRangeException.ThrowIfNegative(quantity);
            ArgumentOutOfRangeException.ThrowIfNegative(price);

            return new OrderItem
            {
                ID = id,
                ProductId = productid,
                OrderId = orderId,
                Quantity = quantity,
                Price = price
            };
        }
    }
}
