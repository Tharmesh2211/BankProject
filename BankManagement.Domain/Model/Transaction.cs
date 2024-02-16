using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Domain.Model
{
    public class Transaction
    {
        public int id {  get; set; }
        public string AccountAccountNumber {  get; set; }
        public Account Account { get; set; }
        public int WithdrawAmount { get; set; }
        public int DepositAmount {  get; set; }
    }
}
