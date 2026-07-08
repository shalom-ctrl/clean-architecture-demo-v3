using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Features.Product.Commands
{
    public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Product name is required.")
                .Length(2, 100).WithMessage("Product name must be between 2 and 100 characters.");
            RuleFor(x => x.Remarks).NotNull().NotEmpty().WithMessage("Product remarks are required.")
                .Length(2, 200).WithMessage("Product remarks must be between 2 and 200 characters.");
            RuleFor(x => x.Rate).NotNull().WithMessage("Product rate is required.")
                .InclusiveBetween(0, decimal.MaxValue).WithMessage("Product rate must be a positive number.");
        }
    }
}
