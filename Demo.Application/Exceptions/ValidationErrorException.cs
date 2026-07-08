using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Exceptions
{
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException() : base("One or more validation errors occurred.")
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }

        public ValidationErrorException(List<ValidationFailure> validationFailures) : this()
        {
            foreach (var failure in validationFailures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
