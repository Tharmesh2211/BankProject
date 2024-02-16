
using BankManagement.Domain.Model;

namespace BankManagement.Application.IServices
{
    public interface ICustomer
    {
        Task<Customer> AddCustomer(Customer Customer);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerByAdhaar(long Adhaar);
        Task<Customer> UpdateCustomer(Customer Customer);
        Task<Customer> DeleteCstomerByAdhaar(long Adhaar);
    }
}
