using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC.Product.Application.SharedKernel.Paging
{
    public interface IPagedQueryResult
    {
        long TotalItemCount { get; }

        int Page { get; }

        int PageSize { get; }

        int PageCount { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }

        int StartItemIndex { get; }

        int EndItemIndex { get; }
    }
}
