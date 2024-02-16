using BankManagement.Application.IServices;
using BankManagement.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace BankManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBank _bank;
        private readonly IAccount _account;
        private readonly ICustomer _customer;
        private readonly IUPITransaction _upiTranction;
        private readonly IUPICreation _upiCreation;
        private readonly ITransaction _transaction;

        public BankController(IBank bank, IAccount account, ICustomer customer, IUPITransaction upiTranction, IUPICreation upiCreation, ITransaction transaction)
        {
            _bank = bank;
            _account = account;
            _customer = customer;
            _upiTranction = upiTranction;
            _upiCreation = upiCreation;
            _transaction = transaction;
        }

        [HttpPost("AddBank")]
        public async Task<Bank> AddBank(Bank bank)
        {
            await _bank.AddBank(bank);
            return bank;
        }

        [HttpGet("GetBanks")]
        public async Task<IEnumerable<Bank>> GetBanks()
        {
            return await _bank.GetBanks();
        }

        [HttpPost("AddCustomer")]
        public async Task<Customer> AddCustomer(Customer Customer)
        {
            await _customer.AddCustomer(Customer);
            return Customer;
        }
        [HttpGet("GetCustomers")]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customer.GetCustomers();
        }
        [HttpGet("GetAccounts")]
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _account.GetAccounts();
        }
        [HttpPost("AddTransaction")]
        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            await _transaction.WithdrawOrDeposit(transaction);
            return transaction;
        }
        [HttpPost("AddUPICreation")]
        public async Task<UPICreation> AddUPICreation(UPICreation upiCreation)
        {
            await _upiCreation.CreateUPI(upiCreation);
            return upiCreation;
        }
         [HttpPost("AddUPITransaction")]
        public async Task<UPITransaction> AddUPITransaction(UPITransaction upiTransaction)
        {
            
            return upiTransaction!=null ? await _upiTranction.UPITransaction(upiTransaction) : null;
        }
    }
}
