using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Domain.Model
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string BankName { get; set; }
        public string CustomerName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }

        [ForeignKey("CustomerAdhaarNumber")]
        public long CustomerAdhaarNumber { get; set; }
        public Customer Customer { get; set; }
      
    }
}
