using Demo.Application.Exceptions;
using Demo.Application.Interfaces;
using Demo.Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Product.Commands
{
    public class DeleteProductCommand : IRequest<ApiResponse<int>>
    {
        public int Id { get; set; }
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ApiResponse<int>>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteProductCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ApiResponse<int>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {

                var product = await _dbContext.Products
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                if (product == null)
                {
                    throw new ApiException("Product not found");
                }

                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();

                return new ApiResponse<int>(product.Id, "Product Deleted successfully");

            }
        }
    }
}
