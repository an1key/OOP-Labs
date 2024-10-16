namespace Lab2;

using System.Collections.Generic;
using System;
using Lab2;
public class ATM
{
    private List<Account> accounts = new List<Account>();

    public void AddAccount(Account account)
    {
        accounts.Add(account);
    }

    public bool Transfer(Account from, Account to, decimal amount)
    {
        if (from.Withdraw(amount))
        {
            to.Deposit(amount);
            Console.WriteLine($"Перевод: {amount} от {from.GetType().Name} к {to.GetType().Name}");
            return true;
        }

        return false;
    }
    
}