using NUnit.Framework;
using NUnit.Framework.Legacy;
using Lab2;

namespace ATMTests
{
    [TestFixture]
    public class ATMTests
    {
        private CurrentAccount _currentAccount;
        private DebitAccount _debitAccount;
        private CreditAccount _creditAccount;
        private ATM _atm;
        

        // Тест 1: Депозит на текущий счет
        [Test]
        public void Deposit_IntoCurrentAccount_IncreasesBalance()
        {
            _currentAccount = new CurrentAccount(500000);
            
            _currentAccount.Deposit(10000);
            
            ClassicAssert.AreEqual(510000, _currentAccount.Balance);
        }

        // Тест 2: Снятие с текущего счета
        [Test]
        public void Withdraw_FromCurrentAccount_DecreasesBalance()
        {
            _currentAccount = new CurrentAccount(500000);
           // 858618
            bool result = _currentAccount.Withdraw(10000);
            
            ClassicAssert.IsTrue(result);
            ClassicAssert.AreEqual(490000, _currentAccount.Balance);
        }

        // Тест 3: Снятие более 30000 за один раз запрещено
        [Test]
        public void Withdraw_Over30000_IsNotAllowed()
        {
            _currentAccount = new CurrentAccount(500000);
            
            bool result = _currentAccount.Withdraw(35000);
            
            ClassicAssert.IsFalse(result);
            ClassicAssert.AreEqual(500000, _currentAccount.Balance);
        }

        // Тест 4: Депозит более 1 000 000 на текущий счет приводит к бонусу на дебетовый счет
        [Test]
        public void Deposit_OverMillion_AutoBonusToDebitAccount()
        {
            _debitAccount = new DebitAccount(0);
            
            _debitAccount.Deposit(1000001);
            
            ClassicAssert.AreEqual(1002001, _debitAccount.Balance); // бонус +2000 к дебет-аккаунту
        }

        // Тест 5: Перевод между счетами успешен
        [Test]
        public void Transfer_BetweenAccounts_IsSuccessful()
        {
            _currentAccount = new CurrentAccount(500000);
            _debitAccount = new DebitAccount(10000);
            _atm = new ATM();
            _atm.AddAccount(_currentAccount);
            _atm.AddAccount(_debitAccount);
            
            _atm.Transfer(_currentAccount, _debitAccount, 5000);
            
            ClassicAssert.AreEqual(495000, _currentAccount.Balance);
            ClassicAssert.AreEqual(15000, _debitAccount.Balance);
        }

        // Тест 6: Перевод не возможен при недостатке средств
        [Test]
        public void Transfer_InsufficientFunds_IsUnsuccessful()
        {
            _currentAccount = new CurrentAccount(500000);
            _debitAccount = new DebitAccount(10000);
            _atm = new ATM();
            _atm.AddAccount(_currentAccount);
            _atm.AddAccount(_debitAccount);

            bool result = _atm.Transfer(_currentAccount, _debitAccount, 600000);
            
            ClassicAssert.IsFalse(result);
            ClassicAssert.AreEqual(500000, _currentAccount.Balance);
        }

        // Тест 7: Запрет на работу с дебетовым счетом при большом долге на кредитном счете
        [Test]
        public void DebitAccountBlocked_WhenCreditBalanceUnderLimit()
        {
            _debitAccount = new DebitAccount(10000);
            _creditAccount = new CreditAccount(-10000);

            _creditAccount.Withdraw(15000); // Баланс становится -25000
            
            ClassicAssert.AreEqual(10000, _debitAccount.Balance); // Операции с дебетом не разрешены
        }

        // Тест 8: Снятие с кредитного счета возможно, если долг не превышает -20 000
        [Test]
        public void WithdrawFromCreditAccount_AllowedIfBalanceAboveLimit()
        {
            _creditAccount = new CreditAccount(-10000);

            bool result = _creditAccount.Withdraw(5000); // Баланс станет -15000
            
            ClassicAssert.IsTrue(result);
            ClassicAssert.AreEqual(-15000, _creditAccount.Balance);
        }

        // Тест 9: Снятие с кредитного счета запрещено, если баланс будет меньше -20000
        [Test]
        public void WithdrawFromCreditAccount_NotAllowedIfOverLimit()
        {
            _creditAccount = new CreditAccount(-10000);
            
            bool result = _creditAccount.Withdraw(15000); // Попытка сделать баланс -25000
            
            ClassicAssert.IsFalse(result);
            ClassicAssert.AreEqual(-10000, _creditAccount.Balance);
        }

        // Тест 10: Общий баланс всех счетов
        [Test]
        public void TotalBalance_AllAccounts_UpdatesCorrectly()
        {
            _currentAccount = new CurrentAccount(0);
            _debitAccount = new DebitAccount(10000);
            _creditAccount = new CreditAccount(0);
            
            _currentAccount.Deposit(10000);
            _debitAccount.Withdraw(5000);
            _creditAccount.Withdraw(3000);
            
            ClassicAssert.AreEqual(12000, Account.TotalBalance); // Проверка общего баланса
        }
    }
}
