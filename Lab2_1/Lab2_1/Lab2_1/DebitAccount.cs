namespace Lab2;
using Lab2;

public sealed class DebitAccount : Account
{
    public DebitAccount(decimal initialBalance) : base(initialBalance) { }

    public override bool Withdraw(decimal amount)
    {
        if (CreditAccount.CanBeUsed())
        {
            base.Withdraw(amount);
        }
        return false;

    }
    public override void Deposit(decimal amount)
    {
        base.Deposit(amount);
        if (amount > 1000000)
        {
            Balance += 2000; // автоматическое начисление +2000
            TotalBalance += 2000;
            Console.WriteLine($"Автоматическое начисление: +2000, баланс: {Balance}");
        }
    }
}