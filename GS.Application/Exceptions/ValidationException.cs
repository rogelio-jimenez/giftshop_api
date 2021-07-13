using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Exceptions
{
    public class ValidationException: Exception
    {
        public List<string> Errors { get; }
        public ValidationException(): base("There are one or more validation errors")
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures): this()
        {
            foreach(var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

    }
}
