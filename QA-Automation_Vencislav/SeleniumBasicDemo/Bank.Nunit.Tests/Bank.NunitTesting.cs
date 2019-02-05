namespace Bank.BankNunitTests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class TestBankAccount
    {
        [Test]
        public void PositiveSumInsBankAccount()
        {
            BankAcount myacc = new BankAcount(200m);

            Assert.AreEqual(200m, myacc.Amount);
        }

        [Test]
        public void NegativeSumInsBankAccount()
        {
            BankAcount myacc = new BankAcount(-2m);

            var ex  = Assert.Throws<ArgumentException>(() => myacc.Withdraw(300m));
            Assert.That(ex.Message, Is.EqualTo("Actual exception message"));
        }
    }


}