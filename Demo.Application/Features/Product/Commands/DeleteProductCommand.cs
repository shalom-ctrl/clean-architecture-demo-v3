using Demo.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Product.Commands
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
        {
            private readonly IApplicationDbContext _dbContext;

            public DeleteProductCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {

                var product = await _dbContext.Products
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                if (product == null)
                {
                    return default;
                }

                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();

                return request.Id;
            }
        }
    }
}
