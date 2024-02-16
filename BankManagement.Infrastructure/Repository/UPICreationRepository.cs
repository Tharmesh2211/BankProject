using BankManagement.Application.IServices;
using BankManagement.Domain.Model;
using BankManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Infrastructure.Repository
{
    public class UPICreationRepository : IUPICreation
    {
        private readonly BankContext _bankContext;
        public UPICreationRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public async Task<UPICreation> CreateUPI(UPICreation upicreation)
        {
            var addUPI = await _bankContext.UPICreation.AddAsync(upicreation);
            await _bankContext.SaveChangesAsync();
            return addUPI.Entity;
        }
    }
}
