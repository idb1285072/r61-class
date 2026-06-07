using ProductOrder_1284655.Model;
using ProductOrder_1284655.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrder_1284655.DependecyInjectionTest
{
    public class Test1
    {
        IGenericRepository<BankAccount> bankAccountRepository;
        public Test1(IGenericRepository<BankAccount> bankAccountRepository)
        {
            this.bankAccountRepository = bankAccountRepository;
        }
        public void RunTest()
        {
            Console.WriteLine("Data insert");
            this.bankAccountRepository.Insert(new BankAccount { Id = 1, AccountNumber = "1284655", AccountName = "Tarikul Islam", AccountType = AccountType.Savings, OpeningDate=new DateTime(2024, 2, 7), CurrentBalance = 6000.00M });
            this.bankAccountRepository.InsertRange(new BankAccount[]
            {
                new BankAccount(2, "1284852", "Hasib Mahmud", AccountType.Current,DateTime.Parse("2024-01-02") ){CurrentBalance=90000.00M},
                new BankAccount(3, "1284887", "Asadujjaman", AccountType.Savings,DateTime.Parse("2024-01-02") ){CurrentBalance=4000.00M},
                new BankAccount(4, "1285165", "Sajib", AccountType.Current,DateTime.Parse("2024-01-02") ){CurrentBalance=90000.00M}
            });
            Console.WriteLine("Get All");
            this.bankAccountRepository.GetAll()
                .ToList()
                .ForEach( ba => Console.WriteLine(ba.ToString()));
            Console.WriteLine("Get one entity");
            var acc = this.bankAccountRepository.Get(3);
            Console.WriteLine(acc.ToString());
            Console.WriteLine("Update");
            acc.CurrentBalance += 500;
            this.bankAccountRepository.Update(acc);
            this.bankAccountRepository.GetAll()
                .ToList()
                .ForEach(ba => Console.WriteLine(ba.ToString()));
            Console.WriteLine("Delete (3)");
            this.bankAccountRepository.Delete(3);
            this.bankAccountRepository.GetAll()
               .ToList()
               .ForEach(ba => Console.WriteLine(ba.ToString()));

        }
    }
}
