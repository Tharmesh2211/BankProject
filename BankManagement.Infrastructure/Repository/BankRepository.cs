using BankManagement.Application.IServices;
using BankManagement.Domain.Model;
using BankManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankManagement.Infrastructure.Repository
{
    public class BankRepository : IBank
    {

        private readonly BankContext _bankContext;
        public BankRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public async Task<Bank> AddBank(Bank Bank)
        {
            var addBank = await _bankContext.Banks.AddAsync(Bank);
            await _bankContext.SaveChangesAsync();
            return addBank.Entity;
        }

        public async Task<IEnumerable<Bank>> GetBanks()
        {
            return await _bankContext.Banks.ToListAsync();
        }
    }
}
