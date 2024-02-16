using BankManagement.Application.IServices;
using BankManagement.Domain.Model;
using BankManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Repository
{
    public class UPITransactionRepository : IUPITransaction
    {
        private readonly BankContext _bankContext;
        public UPITransactionRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public async Task<UPITransaction> UPITransaction(UPITransaction transaction)
        {
            var getFromAccount = await _bankContext.Accounts.FirstOrDefaultAsync(t => t.AccountNumber.Equals(transaction.FromAccount));
            var getToAccount = await _bankContext.Accounts.FirstOrDefaultAsync(t => t.AccountNumber.Equals(transaction.ToAccount));
            if (getFromAccount != null && getToAccount != null)
            {
                var getFromUPIAccount = await _bankContext.UPICreation.FirstOrDefaultAsync(t => t.AccountAccountNumber.Equals(transaction.FromAccount));
                var getToUPIAccount = await _bankContext.UPICreation.FirstOrDefaultAsync(t => t.AccountAccountNumber.Equals(transaction.ToAccount));

                if(getFromUPIAccount != null && getToUPIAccount != null)
                {
                    if(getFromUPIAccount.CreatePassword == transaction.Password)
                    {
                        var getFromCustomer = await _bankContext.Customers.FirstOrDefaultAsync(t => t.AdhaarNumber.Equals(getFromAccount.CustomerAdhaarNumber));
                        if (getFromCustomer != null)
                        {
                            getFromCustomer.Amount -= transaction.Amount;
                            var getToCustomer = await _bankContext.Customers.FirstOrDefaultAsync(t => t.AdhaarNumber.Equals(getToAccount.CustomerAdhaarNumber));
                            if (getToCustomer != null)
                            {
                                getToCustomer.Amount += transaction.Amount;
                                var addUPI = await _bankContext.UPITransaction.AddAsync(transaction);
                                await _bankContext.SaveChangesAsync();
                                return addUPI.Entity;
                            }
                        }

                    }
                }
            }
            return null;
        }
    }
}
