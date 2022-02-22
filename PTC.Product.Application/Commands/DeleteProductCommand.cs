using MediatR;
using PTC.Product.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC.Product.Application.Commands
{
    public class DeleteProductCommand : IRequest<ProductResponse>
    {
        public int Id { get; set; }
    }
}
