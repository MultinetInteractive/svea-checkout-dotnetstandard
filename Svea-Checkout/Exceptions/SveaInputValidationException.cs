using System;

namespace Svea.Checkout.Exceptions
{
    public class SveaInputValidationException : Exception
    {
        public SveaInputValidationException(string message) : base(message)
        {

        }
    }
}
