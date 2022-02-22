using MediatR;
using PTC.Product.Application.SharedKernel.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC.Product.Application.Queries
{
    public class GetProductByIdQuery : QueryBase, IRequest<PTC.Product.Domain.Entities.Product>
    {
        public int Id { get; set; }
    }
}
