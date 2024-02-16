using BankManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Application.IServices
{
    public interface IUPITransaction
    {
        public Task<UPITransaction> UPITransaction (UPITransaction transaction);
    }
}
