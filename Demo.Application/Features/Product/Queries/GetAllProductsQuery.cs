using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Product.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Domain.Entities.Product>>
    {
        internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Domain.Entities.Product>>
        {
            public Task<IEnumerable<Domain.Entities.Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var list = new List<Domain.Entities.Product>();
                for(int i = 0; i < 100; i++)
                {
                    var product = new Domain.Entities.Product();
                    product.Name = "Product " + i;
                    product.Description = "Description " + i;
                    product.Rate = i * 10;

                    list.Add(product);
                }

                return Task.FromResult<IEnumerable<Domain.Entities.Product>>(list);
            }
        }
    }


}
