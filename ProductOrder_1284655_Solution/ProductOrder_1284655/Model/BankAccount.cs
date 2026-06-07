using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrder_1284655.Model
{
    public enum AccountType { Savings=1, Current}
    public class BankAccount : IEntity
    {
        public BankAccount() { }
        public BankAccount(int id, string accountNumber, string accountName, AccountType accountType, DateTime openingDate) 
        {
            this.Id = id;
            this.AccountNumber = accountNumber;
            this.AccountName = accountName;
            this.AccountType = accountType;
            this.OpeningDate = openingDate;
            this.CurrentBalance = 0;
        }
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime OpeningDate { get; set; }
        public decimal CurrentBalance { get; set; }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber}, Holder: {AccountName} Type:{AccountType} Openned: {OpeningDate: yyyy-MM-dd} Balance: {CurrentBalance:0.00}";
        }

    }
}
