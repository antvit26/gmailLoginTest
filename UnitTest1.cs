using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        //String textBox = "//*[@id='identifierId']";
        String textBox = "identifierId";
        String idNextButton = "//*[@id='identifierNext']/content/span";
        String password = "password";
        String passNextButton = "//*[@id='passwordNext']/content/span";

        [TestMethod]
        // This method is testing the user log in with correct username and Password.
        
        public void testLogin()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/");
            driver.FindElement(By.Id(textBox)).SendKeys("davisantony97");
            driver.FindElement(By.XPath(idNextButton)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Name(password)).SendKeys("Friday@97+25");
            driver.FindElement(By.XPath(passNextButton)).Click();

            driver.Quit();
        }

        [TestMethod] //This method is testing the user login with Right username and password.

        public void wrongPassword()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/");
            driver.FindElement(By.Id(textBox)).SendKeys("davisantony97");
            driver.FindElement(By.XPath(idNextButton)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Name(password)).SendKeys("Friday@97+");
            driver.FindElement(By.XPath(passNextButton)).Click();

           var errorMessage = driver.FindElement(By.XPath("//*[@id='password']/div[2]/div[2]/div"));
           Assert.AreEqual(errorMessage.Text.ToLower(), "Wrong password. Try again or click Forgot password to reset it.".ToLower());
           driver.Quit();
        }

       [TestMethod] //This method is testing the login with wrong username.

        public void testworngId ()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/");
            driver.FindElement(By.Id(textBox)).SendKeys("davi6654879568");
            driver.FindElement(By.XPath(idNextButton)).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            var errorMessage = driver.FindElement(By.XPath("//*[@id='view_container']/div/div/div[2]/div/div[1]/div/form/content/section/div/content/div[1]/div/div[2]/div[2]/div"));
            Assert.AreEqual(errorMessage.Text.ToLower(), "Couldn't find your Google Account".ToLower());
            driver.Quit();
                       
        }
    }
}
