namespace Ordering.Domain.ValueObjects
{
    public record OrderName
    {
        public string Value { get; }
        private OrderName(string value)
        {
            Value = value;
        }

        public static OrderName Of(string value)
        {
            if (value == null)
                throw new DomainException("OrderName cant be null");
            return new OrderName(value);
        }
    }
}
