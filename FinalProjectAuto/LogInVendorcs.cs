using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAuto
{
    public class LogInVendorcs
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
        public static bool LoginAsVendorBeforsendApprovalOrRejectMessage(string username, string password)
        {
            LogInMethod(username, password);
            IWebElement messageElement = TestSetup.driver.FindElement(By.XPath("//li[normalize-space()='The account is under study by the administrator']"));
            string messageText = messageElement.GetAttribute("innerText");
            if (messageText == "The account is under study by the administrator")
            {
                Console.WriteLine("Constraint of Vendor Can not login befor Approval Or Reject from admin works successfully(pass)");
                return true;
            }
            else
            {
                return false;
                //throw new Exception("Constraint of Vendor Can not login befor Approval Or Reject from admin does not work successfully(Fail)");
            }
        }
        public static bool LoginAsVendorAftersendRejectMessage(string username, string password)
        {
            LogInMethod(username, password);
            IWebElement messageElement = TestSetup.driver.FindElement(By.XPath("//li[normalize-space()='The email entered is not registered in the system']"));
            string messageText = messageElement.GetAttribute("innerText");
            if (messageText == "The email entered is not registered in the system")
            {
                Console.WriteLine("Constraint of Vendor Can not login after Reject from admin works successfully(pass)");
                return true;
            }
            else
            {
                return false;
                //throw new Exception("Constraint of Vendor Can not login after Reject from admin does not work successfully(Fail)");
            }
        }
        public static bool LoginAsVendorAftersendApprovalMessage(string username, string password)
        {
            LogInMethod(username, password);
            IWebElement wlcElement = TestSetup.driver.FindElement(By.XPath("//a[normalize-space()='Herfa']"));
            string wlcText = wlcElement.GetAttribute("innerText");
            if (wlcText == "Herfa")
            {
                Console.WriteLine("Constraint of Vendor Can login after Approval from admin works successfully(pass)");
                return true;
            }
            else
            {
                return false;
                //throw new Exception("Constraint of Vendor Can login after Approval from admin does not work successfully(Fail)");
            }
        }

    }
}
