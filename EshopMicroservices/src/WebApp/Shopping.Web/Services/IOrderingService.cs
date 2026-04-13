namespace Shopping.Web.Services
{
    public interface IOrderingService
    {
        [Get("/ordering-service/orders/")]
        public Task<PaginatedResponse<OrderModal>> GetOrders(OrderModal modal);
        [Get("/ordering-service/orders/{orderName}")]
        public Task<OrderModal> GetOrderByOrderName(string OrderName);
        [Get("/ordering-service/orders/customer/{id}")]
        public Task<OrderModal> GetOrderByCustomer(Guid Id);
    }
}
