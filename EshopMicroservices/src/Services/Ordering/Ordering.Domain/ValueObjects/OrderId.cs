namespace Ordering.Domain.ValueObjects
{
    public record OrderId
    {
        public Guid Value { get; }
        private OrderId(Guid value)
        {
            Value = value;
        }

        public static OrderId Of(Guid value)
        {
            if (value.ToString() == "")
                throw new DomainException("Orderd cant be null");
            return new OrderId(value);
        }
    }
}
