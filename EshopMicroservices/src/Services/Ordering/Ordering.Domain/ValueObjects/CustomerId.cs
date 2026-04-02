using Ordering.Domain.Exceptions;

namespace Ordering.Domain.ValueObjects
{
    public record CustomerId
    {
        public Guid Value { get; }
        private CustomerId(Guid value) => Value = value;

        public static CustomerId Of(Guid value)
        {
            if (value.ToString() == string.Empty)
                throw new DomainException("Customer Id");
            return new CustomerId(value);
        }
    }
}
