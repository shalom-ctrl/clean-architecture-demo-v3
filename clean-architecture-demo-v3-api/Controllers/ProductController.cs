using Demo.Application.Features.Product.Commands;
using Demo.Application.Features.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clean_architecture_demo_v3_api.Controllers
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductsByIdQuery { Id = id }, cancellationToken);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllProductsQuery(), cancellationToken);
            return Ok(result);
        }


        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand create, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(create, cancellationToken);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductCommand update, CancellationToken cancellationToken)
        {
            update.Id = id;
            var result = await _mediator.Send(update, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteProductCommand { Id = id }, cancellationToken);
            return Ok(result);
        }
    }
}
