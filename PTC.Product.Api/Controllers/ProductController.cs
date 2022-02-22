using MediatR;
using Microsoft.AspNetCore.Mvc;
using PTC.Product.Application.Commands;
using PTC.Product.Application.Queries;
using PTC.Product.Application.Responses;
using PTC.Product.Application.SharedKernel.Paging;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PTC.Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<PagedQueryResult<PTC.Product.Domain.Entities.Product>> Get()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<PTC.Product.Domain.Entities.Product> Get(int id)
        {
            return await _mediator.Send(new GetProductByIdQuery() { Id = id });
        }

        // POST api/<ProductController>4
        [HttpPost]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponse>> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductResponse>> DeleteProduct(int id, [FromBody] DeleteProductCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
