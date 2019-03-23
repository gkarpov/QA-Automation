namespace Bank.Nunit
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void AcountInitialize_WithPositiveValue_ShouldPass()
        {
            BankAcount acount = new BankAcount(2000m);

            Assert.AreEqual(2000m, acount.Amount);
        }

        [Test]
        public void AcountInitialize_WithNegaiveValue_ShouldThrowExeption()
        {
            BankAcount acount = new BankAcount(-1m);

            Assert.Throws<ArgumentException>(() => acount.Withdraw(300m));
        }

        [Test]
        public void AcountWithdraw_WithMoreMoney_ShouldThrowException()
        {
            BankAcount acount = new BankAcount(200m);

            Assert.Throws<ArgumentException>(() => acount.Withdraw(300m));
        }

        [Test]
        public void AcountDeposit_WithNegativevalue_ShouldThrowException()
        {
            BankAcount acount = new BankAcount(200m);

            Assert.Throws<ArgumentException>(() => acount.Deposit(-300m));
        }
    }
}
