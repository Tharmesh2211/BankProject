using BankManagement.Domain.Model;

namespace BankManagement.Application.IServices
{
    public interface IBank
    {
        Task<Bank> AddBank(Bank Bank);
        Task<IEnumerable<Bank>> GetBanks();
    }
}
