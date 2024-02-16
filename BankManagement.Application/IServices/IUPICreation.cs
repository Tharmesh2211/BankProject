using BankManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Application.IServices
{
    public interface IUPICreation
    {
        Task<UPICreation> CreateUPI (UPICreation upicreation);
    }
}
