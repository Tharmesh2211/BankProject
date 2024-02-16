using BankManagement.Domain.Model;


namespace BankManagement.Application.IServices
{
    public interface IAccount
    {
        Task<Account> AddAccount(Customer Customer);
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccountByAccountNumber(string AccountNumber);
        Task<Account> UpdateAccount(Account Account);
        Task<Account> DeleteCstomerByAccountNumber(string AccountNumber);
    }
}
