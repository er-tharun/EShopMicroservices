namespace Ordering.Domain.ValueObjects
{
    public record ProductId
    {
        public Guid Value { get; }
        private ProductId(Guid value)
        {
            Value = value;
        }

        public static ProductId Of(Guid value)
        {
            if (value.ToString() == "")
                throw new DomainException("ProductId cant be null");
            return new ProductId(value);
        }
    }
}
