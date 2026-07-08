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

namespace Demo.Application.Features.Product.Queries
{
    public class GetAllProductsQuery : IRequest<ApiResponse<IEnumerable<Domain.Entities.Product>>>
    {
        internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ApiResponse<IEnumerable<Domain.Entities.Product>>>
        {
            private readonly IApplicationDbContext _dbContext;

            public GetAllProductsQueryHandler(IApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ApiResponse<IEnumerable<Domain.Entities.Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var result = await _dbContext.Products.ToListAsync(cancellationToken);
                if (result == null)
                {
                    throw new ApiException($"Product not found.");
                }

                return new ApiResponse<IEnumerable<Domain.Entities.Product>>(result, "Data Fetched successfully");
         
            }
        }
    }


}
