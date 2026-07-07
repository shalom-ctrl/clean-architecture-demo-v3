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
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IApplicationDbContext _dbContext;

            public UpdateProductCommandHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _dbContext.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                if(product != null)
                {

                  product.Name = request.Name;
                  product.Description = request.Description;
                  product.Rate = request.Rate;
                  product.ModifiedBy = "Admin";

                  await _dbContext.SaveChangesAsync();
                  return product.Id;
                }

                return default;
            }
        }
    }
}
