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

        [HttpGet]
        public IActionResult GetProducts(CancellationToken cancellationToken)
        {
           var result = _mediator.Send(new GetAllProductsQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
