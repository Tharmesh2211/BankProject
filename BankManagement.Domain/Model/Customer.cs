using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Domain.Model
{
    public class Customer
    {
        [ForeignKey("BankId")]
        public int BankId { get; set; }
        public Bank Bank { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CustomerDob { get; set; }
        public long CustomerPhone { get; set; }
        [Key]
        public long AdhaarNumber { get; set; }
        public string PANNumber { get; set; }
        public double Amount {  get; set; }
        public bool IsDeleted { get; set; }

    }
}
