using AutoMapper;
using clean_architecture_demo_v3_api.SharedServices;
using Demo.Application.Interfaces;
using Demo.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Product.Commands
{
    public class CreateProductCommand : IRequest<ApiResponse<int>>
    {
        public string Name { get; set; }
        public string Remarks { get; set; }
        public decimal Rate { get; set; }
        internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ApiResponse<int>>
        {
            private readonly IApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            private readonly IAuthenticatedUser _authenticatedUser;

            public CreateProductCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IAuthenticatedUser authenticatedUser)
            {
                _dbContext = dbContext;
                _mapper = mapper;
                _authenticatedUser = authenticatedUser;
            }
            public async Task<ApiResponse<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Domain.Entities.Product>(request);
                product.CreatedBy = _authenticatedUser.UserId;
                product.CreatedOn = DateTime.Now;
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();

                return new ApiResponse<int>(product.Id, "Product Created successfully");
            }
        }
    }
}
