namespace Shopping.Web.Modals.Basket
{
    public class ShoppingCartItemModal
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public decimal Price { get; set; }
        public string Colour { get; set; } = default!;
        public int Quantity { get; set; }
    }
}
