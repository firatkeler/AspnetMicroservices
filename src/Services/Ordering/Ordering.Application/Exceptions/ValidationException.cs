using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Linq;

namespace Ordering.Application.Exceptions
{
	public class ValidationException : ApplicationException
	{
		public ValidationException() : base("One or more validation failures have occured.")
		{
			Errors = new Dictionary<string, string[]>();
		}

		public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
			Errors = failures
				.GroupBy(f => f.PropertyName, f => f.ErrorMessage)
				.ToDictionary(f => f.Key, f => f.ToArray());
        }

		public IDictionary<string, string[]> Errors { get; }
	}
}

