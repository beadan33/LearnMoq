using System;
using System.Collections.Generic;
using System.Linq;
using LearnMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MoqTest
{
    [TestClass]
    public class CustomerServiceTests
    {
        //shows the basic arrange, act, assert pattern
        //shows the simple verification of a method call
        [TestMethod]
        public void the_repository_save_should_be_called()
        {
            //Arrange
            var mockRepository = new Mock<ICustomerRepository>();

            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));

            var customerService = new CustomerService(mockRepository.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mockRepository.VerifyAll();
        }

        //shows the basic arrange, act, assert pattern
        //shows the simple verification of a method call
        [TestMethod]
        public void the_repository_save_should_be_called_number_of_customer_collection()
        {
            //Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var customerService = new CustomerService(mockRepository.Object);

            //Act
            customerService.Create(CustomerToCreateDtoList);

            //Assert
            mockRepository.Verify(x=>x.Save(It.IsAny<Customer>()), Times.Exactly(CustomerToCreateDtoList.Count()));
        }

        private IEnumerable<CustomerToCreateDto> CustomerToCreateDtoList => new List<CustomerToCreateDto>
        {
            new CustomerToCreateDto
            {
                FirstName = "Sam",
                LastName = "Sampson"
            },
            new CustomerToCreateDto
            {
                FirstName = "Bob",
                LastName = "Builder"
            },
            new CustomerToCreateDto
            {
                FirstName = "Doug",
                LastName = "Digger"
            }
        };
    }
}
