using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Domain.Model
{
    public class UPICreation
    {
        public int Id { get; set; }
        public string AccountAccountNumber {  get; set; }
        public Account Account { get; set; }  
        public string CreatePassword {  get; set; }

    }
}
