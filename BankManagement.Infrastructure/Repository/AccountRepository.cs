using BankManagement.Application.IServices;
using BankManagement.Domain.Model;
using BankManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace BankManagement.Infrastructure.Repository
{
    public class AccountRepository : IAccount
    {

        private readonly BankContext _bankContext;
        public AccountRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task<Account?> AddAccount(Customer customer)
        {
           

            var getBank = await _bankContext.Banks.FirstOrDefaultAsync(t => t.BankID.Equals(customer.BankId));
            if (getBank != null)
            {
                Account account = new Account();

                account.AccountNumber = GenerateAccountNumber(customer);
                account.BankName = getBank.BankName;
                account.IFSCCode = getBank.IFSCCode;
                account.CustomerName = customer.CustomerName;
                account.CustomerAdhaarNumber = customer.AdhaarNumber;
                account.Customer = customer;

                var addAccount = await _bankContext.Accounts.AddAsync(account);
                await _bankContext.SaveChangesAsync();
                return addAccount.Entity;
            }
            return null;
        }
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _bankContext.Accounts.ToListAsync();
        }

        public Task<Account> GetAccountByAccountNumber(string AccountNumber)
        {
            throw new NotImplementedException();
        }
        
        public  Task<Account> UpdateAccount(Account Account)
        {
            throw new NotImplementedException();
        }

        public Task<Account> DeleteCstomerByAccountNumber(string AccountNumber)
        {
            throw new NotImplementedException();
        }
        public string GenerateAccountNumber(Customer customer)
        {
            Random rnd = new Random();
            string s = "";
            for (int i = 1; i <= 16; i++)
            {
                int number = rnd.Next(0, 9);
                s = s + number;
            }
            return s;
        }

        public string GenerateIFSCCode(Customer customer)
        {
            Random rnd = new Random();
            string s = "HDFC";
            for (int i = 1; i <= 7; i++)
            {
                int number = rnd.Next(0, 9);
                s = s + number;
            }
            return s;
        }
    }
}
