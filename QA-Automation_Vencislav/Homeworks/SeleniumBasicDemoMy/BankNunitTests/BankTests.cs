namespace Bank.BankTests
{
    using System;
    using NUnit.Compatibility;
    using NUnit.Framework;

    public class BankNUnitTests
    {
        [Test]
        public void BankAccount_PositiveAmount()
        {
            BankAcount _myacc = new BankAcount(100m);

            Assert.AreEqual(100m, _myacc.Amount);
        }

        [Test]
        public void BankAccount_NegativeAmount()
        {
            Assert.Throws<ArgumentException>(() => new BankAcount(-1m));
        }

        [Test]
        public void BankAccount_PositiveDeposite()
        {
            BankAcount _myacc = new BankAcount(100m);

            _myacc.Deposit(100m);

            Assert.AreEqual(200m, _myacc.Amount);
        }

        [Test]
        public void BankAccount_NegativeDeposite()
        {


            BankAcount _myacc = new BankAcount(100m);

            Assert.Throws<ArgumentException>(() => _myacc.Deposit(-1m));

        }

        [Test]
        public void BankAccount_NegativeWithdraw()
        {
            BankAcount _myacc = new BankAcount(100m);

            Assert.Throws<ArgumentException>(() => _myacc.Withdraw(-1m));
        }

        [Test]
        public void BankAccount_PositiveWithdrawLittle()
        {
            BankAcount _myacc = new BankAcount(1000m);

            _myacc.Withdraw(100m);

            Assert.AreEqual(1000m-105, _myacc.Amount);
        }

        [Test]
        public void BankAccount_PositiveWithdrawBig()
        {
            BankAcount _myacc = new BankAcount(10000m);

            _myacc.Withdraw(1000m);

            Assert.AreEqual(10000m-1020, _myacc.Amount);
        }

        [Test]
        public void BankAccount_PositiveWithdrawLittleOver()
        {
            BankAcount _myacc = new BankAcount(1000m);

            Assert.Throws<ArgumentException>(() => _myacc.Withdraw(990));
        }

        [Test]
        public void BankAccount_PositiveWithdrawBigOver()
        {
            BankAcount _myacc = new BankAcount(10000m);

            Assert.Throws<ArgumentException>(() => _myacc.Withdraw(9990));
        }


    }
}
