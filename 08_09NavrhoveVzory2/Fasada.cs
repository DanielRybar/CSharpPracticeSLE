using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_09NavrhoveVzory2
{
    // Rozhraní pro služby pro správu účtů
    public interface IAccountService
    {
        void CreateAccount(string name, string email, string password);
        void DeleteAccount(string email, string password);
        void UpdateAccount(string email, string password, string newName);
    }

    // Rozhraní pro transakční služby
    public interface ITransactionService
    {
        void Deposit(string email, string password, decimal amount);
        void Withdraw(string email, string password, decimal amount);
        void Transfer(string fromEmail, string fromPassword, string toEmail, decimal amount);
    }

    // Rozhraní pro služby pro ověřování totožnosti
    public interface IIdentityService
    {
        bool VerifyIdentity(string email, string password);
    }

    // Fasáda pro bankovní aplikaci
    public class BankFacade
    {
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;
        private readonly IIdentityService _identityService;

        public BankFacade()
        {
            // nutné vytvořit třídy s další implementací
            //_accountService = new AccountService();
            //_transactionService = new TransactionService();
            //_identityService = new IdentityService();
        }

        public void CreateAccount(string name, string email, string password)
        {
            _accountService.CreateAccount(name, email, password);
        }

        public void DeleteAccount(string email, string password)
        {
            _accountService.DeleteAccount(email, password);
        }

        public void UpdateAccount(string email, string password, string newName)
        {
            _accountService.UpdateAccount(email, password, newName);
        }

        // další metody ...
    }
}