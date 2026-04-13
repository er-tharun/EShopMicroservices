namespace Shopping.Web.Modals.Order
{
    public class PaginatedResponse<TEntity>
        where TEntity : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IEnumerable<TEntity> Result { get; set; }
    }
}
