using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Domain.Model
{
    public class UPITransaction
    {
        public int Id { get; set; }
        public string FromAccount {  get; set; }
        public string ToAccount { get; set; }
        public double Amount {  get; set; }
        public string Password {  get; set; }   
    }
}
