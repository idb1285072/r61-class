using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrder_1284655.Model
{
    public class DebitCard : IEntity
    {
        public DebitCard() { }
        public DebitCard(int id, string holderName, DateTime issueDate, decimal currentBalance) { 
            this.Id = id;
            this.HolderName = holderName;
            this.IssueDate = issueDate;
            this.CurrentBalance = currentBalance;
        }
        public int Id { get; set; }
        public string HolderName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get=>this.IssueDate.AddMonths(24);  } 
        public decimal CurrentBalance { get; set; }
        public override string ToString()
        {
            return $"Id:{Id}, Holder: {HolderName}, Issued: {IssueDate:yyyy-MM-dd}, Expires: {ExpireDate: yyyy-MM-dd}, Balance: {CurrentBalance:0.00}";
        }
    }
}
