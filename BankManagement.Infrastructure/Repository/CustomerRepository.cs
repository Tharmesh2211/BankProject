
using BankManagement.Application.IServices;
using BankManagement.Domain.Model;
using BankManagement.Infrastructure.Data;
using BankManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace BankManagement.Infrastructure.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly BankContext _bankContext;
        public CustomerRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            var addCustomer = await _bankContext.Customers.AddAsync(customer);
            await _bankContext.SaveChangesAsync();

            await new AccountRepository(_bankContext).AddAccount(customer);
            return addCustomer.Entity;
        }

        public Task<Customer> DeleteCstomerByAdhaar(long Adhaar)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByAdhaar(long Adhaar)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _bankContext.Customers.ToListAsync();
        }

        public Task<Customer> UpdateCustomer(Customer Customer)
        {
            throw new NotImplementedException();
        }
    }
}
//AccountRepository accountRepository = new AccountRepository();