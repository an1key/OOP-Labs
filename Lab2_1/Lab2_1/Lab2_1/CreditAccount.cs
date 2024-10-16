namespace Lab2;
using Lab2;
public sealed class CreditAccount : Account
{
    public CreditAccount(decimal initialBalance) : base(initialBalance) { }

    public static bool CanBeUsed()
    {
        if (TotalBalance < -20000) return false;
        return true;
    }
    public override bool Withdraw(decimal amount)
    {
        if (Balance - amount < -20000)
        {
            Console.WriteLine("Нельзя снимать, если баланс кредитного счета менее -20000.");
            return false;
        }
        if (amount > 30000)
        {
            Console.WriteLine("Нельзя снять более 30 000 за один сеанс.");
            return false;
        }
        if (amount > 0 && Balance - amount >= -20000)
        {
            Balance -= amount;
            TotalBalance -= amount;
            Console.WriteLine($"Снятие: {amount}, баланс: {Balance}");
            return true;
        }

        return false;
    }
}