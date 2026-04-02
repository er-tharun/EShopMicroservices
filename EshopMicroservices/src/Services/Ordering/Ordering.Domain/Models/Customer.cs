namespace Ordering.Domain.Models
{
    public class Customer:Entity<CustomerId>
    {
        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;

        protected Customer() {  }

        private Customer(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public static Customer Create(CustomerId id, string name, string email)
        {

            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(email);

            return new Customer
            {
                ID = id,
                Name = name,
                Email = email
            };
        }
    }
}
