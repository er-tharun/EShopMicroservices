using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Pagination
{
    public class PaginationResponse<TEntity>
        where TEntity : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IEnumerable<TEntity> Result { get; set; }
    }
}
