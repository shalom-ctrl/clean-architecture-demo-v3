using Demo.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Product.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IApplicationDbContext _dbContext;

            public CreateProductCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {

                var product = new Demo.Domain.Entities.Product();

                product.Name = request.Name;
                product.Description = request.Description;
                product.Rate = request.Rate;
                product.CreatedBy = "Admin";


                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
