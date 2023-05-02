using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAuto
{
    public class LogInAsAdminToApprovalOrRejectRequestRegister
    {
        public static void TestLogin()
        {
            TestSetup.NavigateToURL();
            IWebElement loginElemnet = TestSetup.driver.FindElement(By.XPath("//div[@class='social flex-w flex-l-m p-r-20']//a[normalize-space()='Login']"));
            TestSetup.Highlight(loginElemnet);
            loginElemnet.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement signInElement = TestSetup.driver.FindElement(By.XPath("//p[@class='lead fw-normal mb-0 me-3']"));
            string signInText = signInElement.GetAttribute("innerText");
            System.Threading.Thread.Sleep(2000);
            if (signInText == "Login")
            {
                Console.WriteLine("Navigate to login page correctly");
            }
            else
            {
                throw new Exception("button login dosen't wrok");
            }
        }
        public static void LogInMethod(string username, string password)
        {
            TestLogin();
            IWebElement usernameElement = TestSetup.driver.FindElement(By.XPath("//input[@id='Email']"));
            TestSetup.Highlight(usernameElement);
            usernameElement.SendKeys(username);
            System.Threading.Thread.Sleep(1000);

            IWebElement passwordElement = TestSetup.driver.FindElement(By.XPath("//input[@id='myPass1']"));
            TestSetup.Highlight(usernameElement);
            passwordElement.SendKeys(password);
            System.Threading.Thread.Sleep(1000);

            IWebElement loginButtonElement = TestSetup.driver.FindElement(By.XPath("//button[normalize-space()='Login']"));
            TestSetup.Highlight(loginButtonElement);
            loginButtonElement.Click();
            System.Threading.Thread.Sleep(3000);
        }
        public static bool PositiveLoginAsAdmin(string username, string password)
        {
            LogInMethod(username, password);
            IWebElement StatisticsElement = TestSetup.driver.FindElement(By.XPath("//h1[normalize-space()='Statistics']"));
            string StatisticsText = StatisticsElement.GetAttribute("innerText");
            if (StatisticsText == "Statistics")
            {
                Console.WriteLine("Admin login successfully(pass)");
                return true;
            }
            else
            {
                return false;
                //throw new Exception("Admin does not login successfully(Fail)");
            }
        }
        public static bool AdminApprovalRequestRegisterFromVendor(string username,string password)
        {
            PositiveLoginAsAdmin(username, password);
            IWebElement ReviewElement = TestSetup.driver.FindElement(By.XPath("//a[@class='nav-link nav-group-toggle']"));
            TestSetup.Highlight(ReviewElement);
            ReviewElement.Click();
            System.Threading.Thread.Sleep(1000);

            IWebElement RequestVendorElement = TestSetup.driver.FindElement(By.XPath("//a[normalize-space()='Request Vendor']"));
            TestSetup.Highlight(RequestVendorElement);
            RequestVendorElement.Click();
            System.Threading.Thread.Sleep(1000);

            IWebElement DashElement = TestSetup.driver.FindElement(By.XPath("//button[@type='button']//i[@class='bi bi-justify']"));
            TestSetup.Highlight(DashElement);
            DashElement.Click();
            System.Threading.Thread.Sleep(1000);

            IWebElement EmailElement = TestSetup.driver.FindElement(By.XPath("//td[normalize-space()='reemmalkawi012@gmail.com']"));
            string emailText = EmailElement.GetAttribute("innerText");
            if(emailText == "reemmalkawi012@gmail.com")
            {
                IWebElement ApprovalElement = TestSetup.driver.FindElement(By.XPath("//a[normalize-space()='Approval']"));
                TestSetup.Highlight(ApprovalElement);
                ApprovalElement.Click();
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Send approval message to vendor email");

                IWebElement LogOutElement = TestSetup.driver.FindElement(By.XPath("//div[@aria-label='scrollable content']//div//li//a[@href='/User/LogOut']"));
                TestSetup.Highlight(LogOutElement);
                LogOutElement.Click();
                System.Threading.Thread.Sleep(1000);

                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool AdminRejectRequestRegisterFromVendor(string username, string password)
        {
            PositiveLoginAsAdmin(username, password);
            IWebElement ReviewElement = TestSetup.driver.FindElement(By.XPath("//a[@class='nav-link nav-group-toggle']"));
            TestSetup.Highlight(ReviewElement);
            ReviewElement.Click();
            System.Threading.Thread.Sleep(1000);

            IWebElement RequestVendorElement = TestSetup.driver.FindElement(By.XPath("//a[normalize-space()='Request Vendor']"));
            TestSetup.Highlight(RequestVendorElement);
            RequestVendorElement.Click();
            System.Threading.Thread.Sleep(1000);

            IWebElement DashElement = TestSetup.driver.FindElement(By.XPath("//button[@type='button']//i[@class='bi bi-justify']"));
            TestSetup.Highlight(DashElement);
            DashElement.Click();
            System.Threading.Thread.Sleep(1000);

            IWebElement EmailElement = TestSetup.driver.FindElement(By.XPath("//td[normalize-space()='reemmalkawi012@gmail.com']"));
            string emailText = EmailElement.GetAttribute("innerText");
            if (emailText == "reemmalkawi012@gmail.com")
            {
                IWebElement RejectElement = TestSetup.driver.FindElement(By.XPath("//a[normalize-space()='Reject']"));
                TestSetup.Highlight(RejectElement);
                RejectElement.Click();
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Send reject message to vendor email");

                IWebElement LogOutElement = TestSetup.driver.FindElement(By.XPath("//div[@aria-label='scrollable content']//div//li//a[@href='/User/LogOut']"));
                TestSetup.Highlight(LogOutElement);
                LogOutElement.Click();
                System.Threading.Thread.Sleep(1000);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
