﻿// See https://aka.ms/new-console-template for more information
using Lab2;
namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем счета
            CurrentAccount current = new CurrentAccount(500000);
            DebitAccount debit = new DebitAccount(10000);
            CreditAccount credit = new CreditAccount(-10000);

            ATM atm = new ATM();
            atm.AddAccount(current);
            atm.AddAccount(debit);
            atm.AddAccount(credit);

            // Примеры операций
            current.Deposit(1200000); // Должно добавить +2000 на дебетовый счет
            atm.Transfer(current, debit, 15000);
            atm.CheckDebitAccountRestrictions(debit, credit);
        }
    }
}