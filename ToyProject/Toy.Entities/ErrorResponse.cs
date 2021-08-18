using System;
using System.Collections.Generic;
using System.Text;

namespace Toy.Entities
{
    public class ErrorResponse
    {
        public IEnumerable<string> ErrorMessages { get; set; }

        public ErrorResponse(string errorMessage) : this(new List<string>() { errorMessage }) { }
        public ErrorResponse(IEnumerable<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }

    }
}
