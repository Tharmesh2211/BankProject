using BankManagement.Application.IServices;
using BankManagement.Domain.Model;
using BankManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Repository
{
    public class TransactionRepository : ITransaction
    {
        private readonly BankContext _bankContext;
        public TransactionRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public async Task<Transaction> WithdrawOrDeposit(Transaction transaction)
        {
            var getAccount = await _bankContext.Accounts.FirstOrDefaultAsync(t => t.AccountNumber.Equals(transaction.AccountAccountNumber));
            if (getAccount != null)
            {
                var getCustomer = await _bankContext.Customers.FirstOrDefaultAsync(t => t.AdhaarNumber.Equals(getAccount.CustomerAdhaarNumber));

                if (transaction.WithdrawAmount != 0 && transaction.DepositAmount != 0 )
                {
                    return null;
                }
                if(transaction.WithdrawAmount != 0)
                {   
                    getCustomer.Amount -= transaction.WithdrawAmount;
                }
                else
                {
                    getCustomer.Amount += transaction.DepositAmount;
                }
                var addCustomer = await _bankContext.Transaction.AddAsync(transaction);
                await _bankContext.SaveChangesAsync();
            }
            return transaction;
        }
    }
}
