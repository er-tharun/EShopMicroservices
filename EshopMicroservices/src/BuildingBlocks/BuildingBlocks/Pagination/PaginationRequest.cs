using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Pagination
{
    public class PaginationRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
