using AutoMapper.Configuration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Demo.Application.Exceptions;

namespace Demo.Application.Behaviours
{
    public class ValidationBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviours(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
              var validationContext = new ValidationContext<TRequest>(request);
              var result = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(validationContext, cancellationToken)));
              var failures = result.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count > 0)
                {
                    throw new ValidationErrorException(failures);
                }
            }
            var response = await next();

            return response;
        }
    }
}
