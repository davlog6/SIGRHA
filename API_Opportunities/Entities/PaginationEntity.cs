using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Opportunities.Entities
{
    public class PaginationEntity<TDocument>
    {
        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public string SortColumn { get; set; }

        public string SortDirection { get; set; }

        public string Filter { get; set; }

        public FilterValue FilterValue { get; set; }

        public int PagesQuantity { get; set; }

        public IEnumerable<TDocument> Data { get; set; }

        public int TotalRows { get; set; }
    }
}
