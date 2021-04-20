using System.Collections;
using Svea.Checkout.Exceptions;

namespace Svea.Checkout.Validation
{
    public static class ValidationService
    {
        public static void MustNotBeEmpty(object data, string fieldName)
        {
            var valid = data switch
            {
                string s => !string.IsNullOrEmpty(s),
                _ => throw new SveaInputValidationException(
                    $"{fieldName} should not be empty"
                )
            };

            if (!valid)
            {
                throw new SveaInputValidationException(
                    $"{fieldName} should not be empty"
                );
            }
        }

        public static void LengthMustBeBetween(string data, int minLength, int maxLength, string fieldName)
        {
            var sizeOfData = data?.Length ?? 0;

            if (sizeOfData < minLength || sizeOfData > maxLength)
            {
                throw new SveaInputValidationException(
                    $"{fieldName} must be between or equal to {minLength} and {maxLength}"
                );
            }
        }

        public static void MustNotBeEmptyArray(object array, string fieldName)
        {
            if (array as IList == null || ((IList)array).Count < 1)
            {
                throw new SveaInputValidationException(
                    $"{fieldName} must be a list, and contain at least one item"
                );
            }
        }

        public static void MustBeArray(object array, string fieldName)
        {
            if (array as IList == null)
            {
                throw new SveaInputValidationException(
                    $"{fieldName} must be a list"
                );
            }
        }
    }
}
