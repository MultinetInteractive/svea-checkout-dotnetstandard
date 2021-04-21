using Svea.Checkout.Exceptions;
using Svea.Checkout.Validation;
using System.Collections.Generic;
using Xunit;

namespace Svea_Checkout.Tests
{
    public class ValidationChecks
    {
        [Fact]
        public void TestMustNotBeEmpty_Throws()
        {
            Assert.Throws<SveaInputValidationException>(() => ValidationService.MustNotBeEmpty(null, "Test"));
            Assert.Throws<SveaInputValidationException>(() => ValidationService.MustNotBeEmpty(string.Empty, "Test"));
        }

        [Fact]
        public void TestMustNotBeEmpty_NoErrors()
        {
            ValidationService.MustNotBeEmpty(new { notEmpty = "String" }, "Test");
            ValidationService.MustNotBeEmpty("Not empty", "Test");
        }

        [Fact]
        public void TestLengthMustBeBetween_Throws()
        {
            Assert.Throws<SveaInputValidationException>(() => ValidationService.LengthMustBeBetween(null, 1, 100, "Test"));
            Assert.Throws<SveaInputValidationException>(() => ValidationService.LengthMustBeBetween(string.Empty, 1, 100, "Test"));
            Assert.Throws<SveaInputValidationException>(() => ValidationService.LengthMustBeBetween("", 1, 100, "Test"));
            Assert.Throws<SveaInputValidationException>(() => ValidationService.LengthMustBeBetween("12345678901", 1, 10, "Test"));
        }

        [Fact]
        public void TestLengthMustBeBetween_NoErrors()
        {
            ValidationService.LengthMustBeBetween("Not empty", 1, 100, "Test");
            ValidationService.LengthMustBeBetween("1234567890", 1, 10, "Test");
            ValidationService.LengthMustBeBetween("1", 1, 10, "Test");
        }

        [Fact]
        public void TestMustNotBeEmptyList_Throws()
        {
            Assert.Throws<SveaInputValidationException>(() => ValidationService.MustNotBeEmptyList(null, "Test"));
            Assert.Throws<SveaInputValidationException>(() => ValidationService.MustNotBeEmptyList(new List<int> { }, "Test"));
        }

        [Fact]
        public void TestMustNotBeEmptyList_NoErrors()
        {
            ValidationService.MustNotBeEmptyList(new List<int> { 1 }, "Test");
        }

        [Fact]
        public void TestMustBeList_Throws()
        {
            Assert.Throws<SveaInputValidationException>(() => ValidationService.MustBeList(null, "Test"));
        }

        [Fact]
        public void TestMustBeList_NoErrors()
        {
            ValidationService.MustBeList(new List<int> { 1 }, "Test");
        }
    }
}
