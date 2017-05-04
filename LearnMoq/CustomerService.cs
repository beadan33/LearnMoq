using System.Collections.Generic;

namespace LearnMoq
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Create(CustomerToCreateDto customerToCreateDto)
        {
            var customer = BuildCustomerObjectFrom(customerToCreateDto);

            _customerRepository.Save(customer);
        }

        private Customer BuildCustomerObjectFrom(CustomerToCreateDto customerToCreateDto)
        {
            return new Customer(customerToCreateDto.Name, customerToCreateDto.City);
        }

        public void Create(IEnumerable<CustomerToCreateDto> customersToCreate)
        {
            foreach (var customerToCreateDto in customersToCreate)
            {
                _customerRepository.Save(
                    new Customer(
                        customerToCreateDto.FirstName,
                        customerToCreateDto.LastName)
                    );
            }
        }
    }
}
