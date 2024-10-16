namespace Lab2;

public abstract class Account
{
    public decimal Balance { get; protected set; }
    public static decimal TotalBalance { get; protected set; }

    public Account(decimal initialBalance)
    {
        Balance = initialBalance;
        TotalBalance += initialBalance;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            TotalBalance += amount;
            Console.WriteLine($"Депозит: {amount}, баланс: {Balance}");
        }
    }

    public virtual bool Withdraw(decimal amount)
    {
        if (amount > 30000)
        {
            Console.WriteLine("Нельзя снять более 30 000 за один сеанс.");
            return false;
        }

        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            TotalBalance -= amount;
            Console.WriteLine($"Снятие: {amount}, баланс: {Balance}");
            return true;
        }

        Console.WriteLine("Недостаточно средств.");
        return false;
    }
}