using System;

namespace MitraisCodingTest.Core.Exceptions
{
    public class ItemExistException : Exception
    {
        public ItemExistException(string message) : base(message)
        {
        }
    }
}
