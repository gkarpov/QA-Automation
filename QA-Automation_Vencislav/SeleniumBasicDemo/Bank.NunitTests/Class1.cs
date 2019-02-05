namespace Bank.BankNunitTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
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
            BankAcount myacc = new BankAcount(200m);

        }
    }


}