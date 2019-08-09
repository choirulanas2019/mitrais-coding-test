using System;

namespace MitraisCodingTest.Core.Exceptions
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(string message) : base(message)
        {
        }
    }
}
