using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ACMEBowlingTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SeleniumTests tests = new SeleniumTests();
            tests.Initialize();
            tests.MyTestMethod();
            tests.MyTestMethod2();
            tests.CleanUp();
        }
    }

    public class SeleniumTests
    {
        internal IWebDriver driver;
        internal string baseURL;

        [TestInitialize]
        public void Initialize()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost:52907/";
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

        [TestMethod]
        public void MyTestMethod()
        {
            driver.Navigate().GoToUrl("/Home");
            Assert.AreEqual(driver.Title, "");
        }

        [TestMethod]
        public void MyTestMethod2()
        {
            driver.Navigate().GoToUrl("http://localhost:52907/Home/Index");

            driver.FindElement(By.Id("game_Id")).Clear();
            driver.FindElement(By.Id("game_Id")).SendKeys("0002");
            driver.FindElement(By.Id("btnEnter")).Click();

            string scoreData = driver.FindElement(By.Id("GameScore")).Text;

            Assert.AreEqual("20", scoreData);

        }
    }
}
