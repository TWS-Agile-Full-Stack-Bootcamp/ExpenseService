using System;
namespace ExpenseService.Exceptions
{
    public class UnexpectedProjectTypeException : Exception
    {
        public UnexpectedProjectTypeException(string message) : base(message)
        {
        }
    }
}
