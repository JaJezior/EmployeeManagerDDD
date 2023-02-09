using EmployeeManagerDomain.Models;

namespace EmployeeManagerTests
{
    public class EmployeeReferenceNoTests
    {
        [Fact]
        public void ShouldNotCreateReferenceNo_WhenReferenceNoIsTooHigh()
        {
            //arrange
            int invalidNumber = 123456789;
            //act + assert
            Assert.Throws<ArgumentException>(() => new EmployeeReferenceNo(invalidNumber));
        }

        [Fact]
        public void ShouldCreateEmployeeReferenceNo_WhenDataIsValid()
        {
            //arrange
            int validNumber = 12345678;
            //act
            var referenceNo = new EmployeeReferenceNo(validNumber);
            //assert
            Assert.Equal(12345678, referenceNo.IntValue);
            Assert.Equal("12345678", referenceNo.Number);
        }
    }
}