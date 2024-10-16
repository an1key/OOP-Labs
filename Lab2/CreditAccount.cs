namespace Lab2;
using Lab2;
public sealed class CreditAccount : Account
{
    public CreditAccount(decimal initialBalance) : base(initialBalance) { }

    public override bool Withdraw(decimal amount)
    {
        if (Balance - amount < -20000)
        {
            Console.WriteLine("Нельзя снимать, если баланс кредитного счета менее -20000.");
            return false;
        }
        return base.Withdraw(amount);
    }
}