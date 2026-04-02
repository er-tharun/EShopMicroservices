namespace Ordering.Domain.ValueObjects
{
    public record OrderItemId
    {
        public Guid Value { get; }
        private OrderItemId(Guid value)
        {
            Value = value;
        }

        public static OrderItemId Of(Guid orderItemId)
        {
            if (orderItemId.ToString() == "")
                throw new DomainException("OrderItemId cant be null");
            return new OrderItemId(orderItemId);
        }
    }
}
