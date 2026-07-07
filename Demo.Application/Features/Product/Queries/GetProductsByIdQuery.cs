using Demo.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Product.Queries
{
    public class GetProductsByIdQuery : IRequest<Domain.Entities.Product>
    {
        public int Id { get; set; }
        internal class GetProductsByIdQueryHandler : IRequestHandler<GetProductsByIdQuery , Domain.Entities.Product>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetProductsByIdQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<Domain.Entities.Product> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _dbContext.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                return result;
            }
        }
    }


}
