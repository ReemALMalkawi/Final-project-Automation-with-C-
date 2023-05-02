using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAuto
{
    [TestClass]
    public class RegisteringAsVendor
    {
     
        public static void TestRegiser()
        {
            TestSetup.NavigateToURL();
            IWebElement signUpElement = TestSetup.driver.FindElement(By.XPath("//div[@class='social flex-w flex-l-m p-r-20']//a[normalize-space()='SignUp']"));
            TestSetup.Highlight(signUpElement);
            signUpElement.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement registerElement = TestSetup.driver.FindElement(By.XPath("//h2[normalize-space()='Register as']"));
            string signUpText = registerElement.GetAttribute("innerText");
            if (signUpText == "Register as")
            {
                Console.WriteLine("SignUp button wroks correctly (pass)");
            }
            else
            {
                throw new Exception("SignUp button doesn't wrok  (fail)");
            }

        }
        public static void TestRegisterAsVendor()
        {
            TestRegiser();
            IWebElement vendorElement = TestSetup.driver.FindElement(By.XPath("//a[@href='/Auth/RegisterVendor']"));
            TestSetup.Highlight(vendorElement);
            vendorElement.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement registerElement = TestSetup.driver.FindElement(By.XPath("//p[@class='lead fw-normal mb-0 me-3']"));
            string signUpText = registerElement.GetAttribute("innerText");
            if (signUpText == "Request to create an account as Vendor")
            {
                Console.WriteLine("Vendor wroks correctly (pass)");
            }
            else
            {
                throw new Exception("Vendor doesn't wrok  (fail)");
            }
        }
        public static void RegisterMethod(User user)
        {
            TestRegisterAsVendor();
            IWebElement fNameElement = TestSetup.driver.FindElement(By.XPath("//input[@id='Fname']"));
            TestSetup.Highlight(fNameElement);
            fNameElement.SendKeys(user.FName);
            System.Threading.Thread.Sleep(1000);

            IWebElement lNameElement = TestSetup.driver.FindElement(By.XPath("//input[@id='Lname']"));
            TestSetup.Highlight(lNameElement);
            lNameElement.SendKeys(user.LName);
            System.Threading.Thread.Sleep(1000);

            // here, in gender we have two choices (Male - Female)
            if (user.Gender.ToLower() == "female")//female / FEMALE / FeMAle
            {
                IWebElement femaleElement = TestSetup.driver.FindElement(By.XPath("//div[@class='form-outline mb-2 text-black']//input[1]"));
                TestSetup.Highlight(femaleElement);
                femaleElement.Click();
                System.Threading.Thread.Sleep(1000);
            }
            else if (user.Gender.ToUpper() == "MALE")//male  // Male
            {
                IWebElement maleElement = TestSetup.driver.FindElement(By.XPath("//div[@class='form-outline mb-2 text-black']//input[1]"));
                TestSetup.Highlight(maleElement);
                maleElement.Click();
                System.Threading.Thread.Sleep(1000);
            }
            IWebElement dateOfBirthdayElement = TestSetup.driver.FindElement(By.XPath("//input[@id='Dateofbirth']"));
            TestSetup.Highlight(dateOfBirthdayElement);
            TestSetup.driver.FindElement(By.XPath("//input[@id='Dateofbirth']")).Click();
            dateOfBirthdayElement.SendKeys(user.DateOfBirth);
            System.Threading.Thread.Sleep(1000);

            IWebElement phoneNumberElement = TestSetup.driver.FindElement(By.XPath("//input[@id='Phonenumber']"));
            TestSetup.Highlight(phoneNumberElement);
            phoneNumberElement.SendKeys(user.PhoneNumber);
            System.Threading.Thread.Sleep(1000);

            IWebElement emailElement = TestSetup.driver.FindElement(By.XPath("//input[@id='Email']"));
            TestSetup.Highlight(emailElement);
            emailElement.SendKeys(user.Email);
            System.Threading.Thread.Sleep(1000);

            IWebElement passwordElement = TestSetup.driver.FindElement(By.XPath("//input[@id='myPass']"));
            TestSetup.Highlight(passwordElement);
            passwordElement.SendKeys(user.Password);
            System.Threading.Thread.Sleep(1000);

            IWebElement passConfimationElement = TestSetup.driver.FindElement(By.XPath("//input[@id='myPass2']"));
            TestSetup.Highlight(passConfimationElement);
            passConfimationElement.SendKeys(user.PasswordConfirmation);
            System.Threading.Thread.Sleep(1000);

            IWebElement submitBtnElement = TestSetup.driver.FindElement(By.XPath("//button[normalize-space()='Submit']"));
            TestSetup.Highlight(submitBtnElement);
            submitBtnElement.Click();
            System.Threading.Thread.Sleep(2000);
        }
        public static bool PositiveRegisterBeforInsertVerificationCode(User user)
        {
            RegisterMethod(user);

            IWebElement verificationElement = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string TextVerification = verificationElement.GetAttribute("innerText");
            if (TextVerification == "Verification:")
            {
                Console.WriteLine("Data insert by user is correct(Pass)");
                return true;
            }
            else
            {
                //throw new Exception("Data insert by user is not correct(Fail)");
                return false;
            }
        }
        public static void PositiveRegisterAfterInsertVerificationCode(User user)
        {
            
            if (PositiveRegisterBeforInsertVerificationCode(user) == true)
            {               
                //read verificatio code from email
                ((IJavaScriptExecutor)TestSetup.driver).ExecuteScript("window.open();");//to open new window
                TestSetup.driver.SwitchTo().Window(TestSetup.driver.WindowHandles.Last());//switch to new tab
                TestSetup.driver.Navigate().GoToUrl("https://accounts.google.com/v3/signin/identifier?dsh=S-754279927%3A1669842300869166&authuser=0&continue=https%3A%2F%2Fmail.google.com&ec=GAlAFw&hl=ar&service=mail&flowName=GlifWebSignIn&flowEntry=AddSession");
                IWebElement BoxUserName = TestSetup.driver.FindElement(By.XPath("//input[@id='identifierId']"));
                TestSetup.Highlight(BoxUserName);
                BoxUserName.SendKeys("reemmalkawi012@gmail.com");
                System.Threading.Thread.Sleep(2000);

                IWebElement nextElement = TestSetup.driver.FindElement(By.XPath("//span[contains(text(),'التالي')]"));
                TestSetup.Highlight(nextElement);
                nextElement.Click();
                System.Threading.Thread.Sleep(5000);

                IWebElement BoxPass = TestSetup.driver.FindElement(By.XPath("//input[@name='Passwd']"));
                TestSetup.Highlight(BoxPass);
                BoxPass.SendKeys("Reem2321999*");
                System.Threading.Thread.Sleep(2000);

                IWebElement next2Element = TestSetup.driver.FindElement(By.XPath("//span[contains(text(),'التالي')]"));
                TestSetup.Highlight(next2Element);
                next2Element.Click();
                System.Threading.Thread.Sleep(10000);

                IWebElement herfaElement = TestSetup.driver.FindElement(By.XPath("//td[@class='yX xY ']"));
                TestSetup.Highlight(herfaElement);
                herfaElement.Click();//click on specific email
                System.Threading.Thread.Sleep(3000);

                //Read all email from Herfa contains verification code
                ReadOnlyCollection<IWebElement> emailElement = TestSetup.driver.FindElements(By.XPath("(//h4)"));
                int numOfMessage = emailElement.Count();          
                IWebElement emailLastElement = TestSetup.driver.FindElement(By.XPath("(//h4)" + ("["+numOfMessage+"]")));
                TestSetup.Highlight(emailLastElement);
                emailLastElement.Click();
                System.Threading.Thread.Sleep(2000);

                string emailText = emailLastElement.GetAttribute("innerText");
                string codeText = emailText.Trim('V','e','r','i','f','i','c','a','t','i','o','n',' ','C','o','d','e','-','-',' ','>',' ');
                System.Threading.Thread.Sleep(2000);
                


                TestSetup.driver.SwitchTo().Window(TestSetup.driver.WindowHandles.First());//Return to first tab 
                System.Threading.Thread.Sleep(2000);

                //Write verification code in Box
                IWebElement boxVerificationElement = TestSetup.driver.FindElement(By.XPath("//input[@name='verificationCodeEntrance']"));
                TestSetup.Highlight(boxVerificationElement);
                boxVerificationElement.SendKeys(codeText);
                System.Threading.Thread.Sleep(3000);

                //click submit
                IWebElement submitBtnElement = TestSetup.driver.FindElement(By.XPath("//button[@class='btn btn-danger btn-sm']"));
                TestSetup.Highlight(submitBtnElement);
                submitBtnElement.Click();
                System.Threading.Thread.Sleep(2000);
            
            }
            else
            {
                Console.WriteLine("Data insert by user is wrong(Fail)");
           
            }
        }
        public static bool RegisterAfterInsertVerificationCodeThenClickedSubmit(User user)
        {
            PositiveRegisterAfterInsertVerificationCode(user);
            IWebElement successedLebalElement = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string TextSuccessed = successedLebalElement.GetAttribute("innerText");
            if (TextSuccessed == "Succeeded:")
            {
                Console.WriteLine("User insert Verification code Rightly(Pass)");
                IWebElement cancelbtnElement = TestSetup.driver.FindElement(By.XPath("//button[normalize-space()='Cancel']"));
                TestSetup.Highlight(cancelbtnElement);
                cancelbtnElement.Click();
                System.Threading.Thread.Sleep(2000);
                IWebElement registerElement = TestSetup.driver.FindElement(By.XPath("//p[@class='lead fw-normal mb-0 me-3']"));
                string signUpText = registerElement.GetAttribute("innerText");
                if (signUpText == "Request to create an account as Vendor")
                {
                    Console.WriteLine("Cancel button wroks correctly (pass)");
                    return true;
                }
                else
                {
                    Console.WriteLine("Cancel button doesn't wrok  (fail)");
                    return false;
                }

            }
            else
            {
                Console.WriteLine("Verification code insert by user is wrong(Fail)");
                return false;
            }
        }
        public static bool PositiveRegisterAfterInsertWrongVerificationCode(User user)
        {
            RegisterMethod(user);
            if (PositiveRegisterBeforInsertVerificationCode(user) == true)
            {
                IWebElement boxVerificationElement = TestSetup.driver.FindElement(By.XPath("//input[@name='verificationCodeEntrance']"));
                TestSetup.Highlight(boxVerificationElement);
                boxVerificationElement.SendKeys("0000");
                System.Threading.Thread.Sleep(2000);

                
                IWebElement submitBtnElement = TestSetup.driver.FindElement(By.XPath("//button[@class='btn btn-danger btn-sm']"));
                TestSetup.Highlight(submitBtnElement);
                submitBtnElement.Click();
                System.Threading.Thread.Sleep(2000);

                IWebElement HerfaElement = TestSetup.driver.FindElement(By.XPath("//p[@class='alert alert-danger text-black text-center']"));
                string HerfaText = HerfaElement.GetAttribute("innerText");
                if(HerfaText == "Registration failed. Wrong code entered")
                {
                    Console.WriteLine("The registration request has not been sent(Pass)");
                    return true;
                }
                else
                {
                    Console.WriteLine("The registration request has been sent(Fail)");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Data insert by user is wrong(Fail)");
                return false;
            }
        }
        public static bool AfterSendRequestAdminApprovalIt(User user)
        {
            PositiveRegisterAfterInsertVerificationCode(user);           
            if(LogInAsAdminToApprovalOrRejectRequestRegister.AdminApprovalRequestRegisterFromVendor("AhmOmari@outlook.com", "Test.123")== true)
            {
                Console.WriteLine("Admin Approval Request Register from vendor(Pass)");
                return true;
            }           
            else
            {
                return false;
            }
        }
        public static bool AfterSendRequestAdminRejectIt(User user)
        {
            PositiveRegisterAfterInsertVerificationCode(user);
            if (LogInAsAdminToApprovalOrRejectRequestRegister.AdminRejectRequestRegisterFromVendor("AhmOmari@outlook.com", "Test.123") == true)
            {
                Console.WriteLine("Admin Reject Request Register from vendor(Pass)");
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool LogInAsVendorAfterApprovalFromAdmin(User user)
        {
            if (AfterSendRequestAdminApprovalIt(user) == true)
            {
                if (LogInVendorcs.LoginAsVendorAftersendApprovalMessage(user.Email,user.Password) == true)
                {
                    Console.WriteLine("Constraint of vendor after approval from admin works successfully(Pass)");
                    return true;
                }
                {
                    Console.WriteLine("Constraint of vendor after approval from admin does not work successfully(Fail)");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool LogInAsVendorAfterRejectFromAdmin(User user)
        {
            if (AfterSendRequestAdminRejectIt(user) == true)
            {
                if (LogInVendorcs.LoginAsVendorAftersendRejectMessage(user.Email, user.Password) == true)
                {
                    Console.WriteLine("Constraint of vendor after reject from admin works successfully(Pass)");
                    return true;
                }
                {
                    Console.WriteLine("Constraint of vendor after reject from admin does not work successfully(Fail)");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool LogInAsVendorBeforRejectOrApprovalFromAdmin(User user)
        {
            PositiveRegisterAfterInsertVerificationCode(user);
            if (LogInVendorcs.LoginAsVendorBeforsendApprovalOrRejectMessage(user.Email, user.Password) == true)
            {
                Console.WriteLine("Constraint of vendor can not login befor approval or reject from admin works successfully(Pass)");
                return true;
            }
            {
                 Console.WriteLine("Constraint of vendor can not login befor approval or reject from admin does not work successfully(Fail)");
                 return false;
            }
        }
        public static bool RegisterWithAllFeildIsEmpty(User user)
        {
            RegisterMethod(user);
            IWebElement SignUpElement = TestSetup.driver.FindElement(By.XPath("//p[@class='lead fw-normal mb-0 me-3']"));
            string TextSignUp = SignUpElement.GetAttribute("innerText");
            if (TextSignUp == "Request to create an account as Vendor")
            {
                Console.WriteLine("User Can't Register (Pass)");
                return true;
            }
            else
            {
                return false;
                //throw new Exception("User Can Register (Fail)");
            }
        }
        public static bool RegisterWithEmailWrongMissingDot(User user)
        {
            RegisterMethod(user);
            IWebElement VerificationElement = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string TextVerification = VerificationElement.GetAttribute("innerText");
            if (TextVerification == "Verification:")
            {
                Console.WriteLine("User Can Register (Fail)");
                return true;
            }
            else
            {
                return false;
                
            }
        }
        public static bool RegisterWithEmailWrongMissingAt(User user)
        {
            RegisterMethod(user);
            IWebElement SignUpElement = TestSetup.driver.FindElement(By.XPath("//p[@class='lead fw-normal mb-0 me-3']"));
            string TextSignUp = SignUpElement.GetAttribute("innerText");
            if (TextSignUp == "Request to create an account as Vendor")
            {
                Console.WriteLine("User Can't Register (Pass)");
                return true;
            }
            else
            {
                return false;
                //throw new Exception("User Can Register (Fail)");
            }
        }
        public static bool RegisterUsingARegisteredEmail(User user)
        {
            RegisterMethod(user);
            IWebElement SignUpElement = TestSetup.driver.FindElement(By.XPath("//p[@class='lead fw-normal mb-0 me-3']"));
            string TextSignUp = SignUpElement.GetAttribute("innerText");
            if (TextSignUp == "Request to create an account as Vendor")
            {
                Console.WriteLine("User Can't Register (Pass)");
                return true;
            }
            else
            {
                return false;
                
            }
        }
        public static bool RegisterWithPhoneWrongLessThanTenDigits(User user)
        {
            RegisterMethod(user);
            IWebElement VerificationElement = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string TextVerification = VerificationElement.GetAttribute("innerText");
            if (TextVerification == "Verification:")
            {
                Console.WriteLine("User Can Register (Fail)");
                return true;
            }
            else
            {
                return false;
              
            }
        }
        public static bool RegisterWithPhoneWrongMoreThanTenDigits(User user)
        {
            RegisterMethod(user);
            IWebElement VerificationElement = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string TextVerification = VerificationElement.GetAttribute("innerText");
            if (TextVerification == "Verification:")
            {
                Console.WriteLine("User Can Register (Fail)");
                return true;
            }
            else
            {
                return false;
               
            }
        }
         public static bool RegisterWithWrongPhoneWithoutDialingCode(User user)
         {
            RegisterMethod(user);
            IWebElement VerificationElement = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string TextVerification = VerificationElement.GetAttribute("innerText");
            if (TextVerification == "Verification:")
            {
                Console.WriteLine("User Can Register (Fail)");
                return true;
            }
            else
            {
                return false;
               
            }
         }
        public static bool RegisterWithPasswordWrongWithoutDigit(User user)
        {
            RegisterMethod(user);
            IWebElement VerificationElement = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string TextVerification = VerificationElement.GetAttribute("innerText");
            if (TextVerification == "Verification:")
            {
                Console.WriteLine("User Can Register (Fail)");
                return true;
            }
            else
            {
                return false;
                
            }
        }
        public static bool RegisterWithPasswordWrongWithoutSymbol(User user)
        {
            RegisterMethod(user);
            IWebElement VerificationElement = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string TextVerification = VerificationElement.GetAttribute("innerText");
            if (TextVerification == "Verification:")
            {
                Console.WriteLine("User Can Register (Fail)");
                return true;
            }
            else
            {
                return false;
                
            }
        }
        public static bool RegisterWithPasswordWrongWithoutCapitalLetter(User user)
        {
            RegisterMethod(user);
            IWebElement VerificationElement = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string TextVerification = VerificationElement.GetAttribute("innerText");
            if (TextVerification == "Verification:")
            {
                Console.WriteLine("User Can Register (Fail)");
                return true;
            }
            else
            {
                return false;
               
            }
        }
        public static bool RegisterWithPasswordWrongWithoutSmallLetter(User user)
        {
            RegisterMethod(user);
            IWebElement VerificationElement = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string TextVerification = VerificationElement.GetAttribute("innerText");
            if (TextVerification == "Verification:")
            {
                Console.WriteLine("User Can Register (Fail)");
                return true;
            }
            else
            {
                return false;
                
            }
        }
        public static bool RegisterWithPasswordWrongLessThanSixElements(User user)
        {
            RegisterMethod(user);
            IWebElement VerificationElement = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string TextVerification = VerificationElement.GetAttribute("innerText");
            if (TextVerification == "Verification:")
            {
                Console.WriteLine("User Can Register (Fail)");
                return true;
            }
            else
            {
                return false;
                
            }
        }
        public static bool RegisterWithPasswordWrongMoreThanTwentyElements(User user)
        {
            RegisterMethod(user);
            IWebElement VerificationElement = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string TextVerification = VerificationElement.GetAttribute("innerText");
            if (TextVerification == "Verification:")
            {
                Console.WriteLine("User Can Register (Fail)");
                return true;
            }
            else
            {
                return false;
               
            }
        }
        public static bool RegistrationWithPasswordsDoNotMatch(User user)
        {
            RegisterMethod(user);
            IWebElement MessageElement = TestSetup.driver.FindElement(By.XPath("//li[normalize-space()='Passwords do not match']"));
            string TextMessage = MessageElement.GetAttribute("innerText");
            if (TextMessage == "Passwords do not match")
            {
                Console.WriteLine("User Can't Register (Pass)");
                return true;
            }
            else
            {
                return false;
                //throw new Exception("User Can Register (Fail)");
            }
        }
        public static bool RegistrationWithRegisteredPhone(User user)
        {
            RegisterMethod(user);
            IWebElement SignUpElement = TestSetup.driver.FindElement(By.XPath("//li[contains(text(),'The Phone Number entered is already registered in ')]"));
            string TextSignUp = SignUpElement.GetAttribute("innerText");
            if (TextSignUp == "The Phone Number entered is already registered in the system")
            {
                Console.WriteLine("User Can't Register (Pass)");
                return true;
            }
            else
            {
                return false;
                //throw new Exception("User Can Register (Fail)");
            }
        }
        public static bool RegisterWithAgeWrongLessThanSixteenYears(User user)
        {
            RegisterMethod(user);
            IWebElement SignUpElement = TestSetup.driver.FindElement(By.XPath("//li[normalize-space()='Age under the legal age']"));
            string TextSignUp = SignUpElement.GetAttribute("innerText");
            if (TextSignUp == "Age under the legal age")
            {
                Console.WriteLine("User Can't Register (Pass)");
                return true;
            }
            else
            {
                return false;
                //throw new Exception("User Can Register (Fail)");
            }
        }
        [TestMethod]
        public void RunRegisterWithAgeWrongLessThanSixteenYears()
        {
            System.Threading.Thread.Sleep(1000);
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();   
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthWrongIsLessThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1, random.Next(2, 3));
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(9, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(9, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegisterWithAgeWrongLessThanSixteenYears(user) == true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 24, "User can not complete registration successfully");
                excel.WriteOnExcel(9, 24, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 24, "User can complete registration successfully");
                excel.WriteOnExcel(9, 24, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 24);
                string readActualResult = excel.ReadFromExcel(8, 24);
                string readSummary = excel.ReadFromExcel(4, 24);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();


                excel.OpenExcel(TestSetup.excelPath, 3);

                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunRegisterAfterInsertVerificationCodeThenClickedSubmit()
        {
            System.Threading.Thread.Sleep(1000);
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it
            
            user.PhoneNumber = excel.ReadFromExcel(4,random.Next(2,16));
            user.Email = excel.ReadFromExcel(1, random.Next(4,5));
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(9, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(9, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if(RegisterAfterInsertVerificationCodeThenClickedSubmit(user)== true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 4, "The registration request has been sent successfully(Pass)");
                excel.WriteOnExcel(9, 4, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 4, "The registration request has not been sent successfully(Fail)");
                excel.WriteOnExcel(9, 4, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 4);
                string readActualResult = excel.ReadFromExcel(8, 4);
                string readSummary = excel.ReadFromExcel(4, 4);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();


                excel.OpenExcel(TestSetup.excelPath, 3);

                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
            //li[normalize-space()='Age under the legal age']
        }
        [TestMethod]
        public void RunPositiveRegisterAfterInsertWrongVerificationCode()
        {
            System.Threading.Thread.Sleep(1000);
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1, 4);
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(9, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(9, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (PositiveRegisterAfterInsertWrongVerificationCode(user)==true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 5, "The registration request has not been sent");
                excel.WriteOnExcel(9, 5, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 5, "The registration request has been sent");
                excel.WriteOnExcel(9, 5, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 5);
                string readActualResult = excel.ReadFromExcel(8, 5);
                string readSummary = excel.ReadFromExcel(4, 5);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();


                excel.OpenExcel(TestSetup.excelPath, 3);

                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        
        
        [TestMethod]
        public void RunPositiveRegisterAfterSendRequestBeforApprovalOrRejectFromAdmin()
        {
            System.Threading.Thread.Sleep(1000);
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1, 4);
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(9, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(9, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (LogInAsVendorBeforRejectOrApprovalFromAdmin(user) == true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 8, "Vendor can not login successfully");
                excel.WriteOnExcel(9, 8, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 8, "Vendor can login successfully");
                excel.WriteOnExcel(9, 8, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 8);
                string readActualResult = excel.ReadFromExcel(8, 8);
                string readSummary = excel.ReadFromExcel(4, 8);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();


                excel.OpenExcel(TestSetup.excelPath, 3);

                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunPositiveRegisterAfterSendRequestAndApprovalItFromAdmin()
        {
            System.Threading.Thread.Sleep(1000);
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1, 4);
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(9, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(9, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (LogInAsVendorAfterApprovalFromAdmin(user) == true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 6, "Vendor can login successfully");
                excel.WriteOnExcel(9, 6, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 6, "Vendor can not login successfully");
                excel.WriteOnExcel(9, 6, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 6);
                string readActualResult = excel.ReadFromExcel(8, 6);
                string readSummary = excel.ReadFromExcel(4, 6);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();


                excel.OpenExcel(TestSetup.excelPath, 3);

                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }

        [TestMethod]
        public void RunPositiveRegisterAfterSendRequestAndRejectItFromAdmin()
        {
            System.Threading.Thread.Sleep(1000);
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1, 4);
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(9, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(9, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (LogInAsVendorAfterRejectFromAdmin(user) == true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 7, "Vendor can not login successfully");
                excel.WriteOnExcel(9, 7, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 7, "Vendor can login successfully");
                excel.WriteOnExcel(9, 7, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 7);
                string readActualResult = excel.ReadFromExcel(8, 7);
                string readSummary = excel.ReadFromExcel(4, 7);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();


                excel.OpenExcel(TestSetup.excelPath, 3);

                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunNegativeRegisterWithAllFieldsEmpty()
        {
            System.Threading.Thread.Sleep(1000);
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            TestSetup.NumOfRegisterAsVendor = 0;
            TestSetup.NumOfTestCasesRegisterAsVendor();
            user.FName = "";
            user.LName = "";
            user.Gender = "";
            user.DateOfBirth ="";                     
            user.PhoneNumber = "";
            user.Email = "";          
            user.Password = "";
            user.PasswordConfirmation = "";
            System.Threading.Thread.Sleep(2000);
            
            if (RegisterWithAllFeildIsEmpty(user) == true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 9, "User cannot complete registration successfully");
                excel.WriteOnExcel(9, 9, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 9, "User can complete registration successfully");
                excel.WriteOnExcel(9, 9, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 9);
                string readActualResult = excel.ReadFromExcel(8, 9);
                string readSummary = excel.ReadFromExcel(4, 9);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

                
                excel.OpenExcel(TestSetup.excelPath, 3);
                
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunRegisterWithWrongEmailMissingDot()
        {
            System.Threading.Thread.Sleep(1000);
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(2, random.Next(2, 15));
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(9, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(9, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegisterWithEmailWrongMissingDot(user) == false)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 10, "User can not complete registration successfully");
                excel.WriteOnExcel(9, 10, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 10, "User can complete registration successfully");
                excel.WriteOnExcel(9, 10, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 10);
                string readActualResult = excel.ReadFromExcel(8, 10);
                string readSummary = excel.ReadFromExcel(4, 10);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

                
                excel.OpenExcel(TestSetup.excelPath, 3);
                
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunRegisterWithWrongEmailMissingat()
        {
            System.Threading.Thread.Sleep(1000);
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(3, random.Next(2, 15));
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(9, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(9, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegisterWithEmailWrongMissingAt(user) == true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 11, "User can not complete registration successfully");
                excel.WriteOnExcel(9, 11, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 11, "User can complete registration successfully");
                excel.WriteOnExcel(9, 11, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 11);
                string readActualResult = excel.ReadFromExcel(8, 11);
                string readSummary = excel.ReadFromExcel(4, 11);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

               
                excel.OpenExcel(TestSetup.excelPath, 3);
                
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunRegisterUsingARegisteredEmail()
        {
            System.Threading.Thread.Sleep(1000);
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
           
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1,3);
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(9, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(9, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegisterWithEmailWrongMissingAt(user) == true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 12, "User can not complete registration successfully");
                excel.WriteOnExcel(9, 12, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 12, "User can complete registration successfully");
                excel.WriteOnExcel(9, 12, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 12);
                string readActualResult = excel.ReadFromExcel(8, 12);
                string readSummary = excel.ReadFromExcel(4, 12);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

                
                excel.OpenExcel(TestSetup.excelPath, 3);
                
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunRegisterWithWrongPhoneLessThanTenDigits()
        {
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
           
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(6, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1,5);
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(9, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(9, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegisterWithPhoneWrongLessThanTenDigits(user) == false)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 13, "User can not complete registration successfully");
                excel.WriteOnExcel(9, 13, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 13, "User can complete registration successfully");
                excel.WriteOnExcel(9, 13, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 13);
                string readActualResult = excel.ReadFromExcel(8, 13);
                string readSummary = excel.ReadFromExcel(4, 13);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

               
                excel.OpenExcel(TestSetup.excelPath, 3);
                
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunRegisterWithWrongPhoneMoreThanTenDigits()
        {
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(7, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1, 5);
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(9, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(9, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegisterWithPhoneWrongMoreThanTenDigits(user) == false)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 14, "User can not complete registration successfully");
                excel.WriteOnExcel(9, 14, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 14, "User can complete registration successfully");
                excel.WriteOnExcel(9, 14, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 14);
                string readActualResult = excel.ReadFromExcel(8, 14);
                string readSummary = excel.ReadFromExcel(4, 14);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

               
                excel.OpenExcel(TestSetup.excelPath, 3);
               
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunRegisterWithWrongPhoneWithoutDialingCode()
        {
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(5, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1, 5);
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(9, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(9, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegisterWithWrongPhoneWithoutDialingCode(user) == false)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 15, "User can not complete registration successfully");
                excel.WriteOnExcel(9, 15, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 15, "User can complete registration successfully");
                excel.WriteOnExcel(9, 15, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 15);
                string readActualResult = excel.ReadFromExcel(8, 15);
                string readSummary = excel.ReadFromExcel(4, 15);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

                
                excel.OpenExcel(TestSetup.excelPath, 3);
                
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunRegisterWithPasswordWrongWithoutDigit()
        {
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
           
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1, random.Next(5, 6));
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(11, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(11, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegisterWithPasswordWrongWithoutDigit(user) == false)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 16, "User can not complete registration successfully");
                excel.WriteOnExcel(9, 16, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 16, "User can complete registration successfully");
                excel.WriteOnExcel(9, 16, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 16);
                string readActualResult = excel.ReadFromExcel(8, 16);
                string readSummary = excel.ReadFromExcel(4, 16);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

               
                excel.OpenExcel(TestSetup.excelPath, 3);
               
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunRegisterWithPasswordWrongWithoutSymbol()
        {
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1, random.Next(5, 6));
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(10, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(10, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegisterWithPasswordWrongWithoutSymbol(user) == false)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 17, "User can not complete registration successfully");
                excel.WriteOnExcel(9, 17, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 17, "User can complete registration successfully");
                excel.WriteOnExcel(9, 17, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 17);
                string readActualResult = excel.ReadFromExcel(8, 17);
                string readSummary = excel.ReadFromExcel(4, 17);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

               
                excel.OpenExcel(TestSetup.excelPath, 3);
                
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunRegisterWithPasswordWrongWithoutCapitalLetter()
        {
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
           
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1, random.Next(5, 6));
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(12, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(12, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegisterWithPasswordWrongWithoutCapitalLetter(user) == false)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 18, "User can not complete registration successfully");
                excel.WriteOnExcel(9, 18, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 18, "User can complete registration successfully");
                excel.WriteOnExcel(9, 18, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 18);
                string readActualResult = excel.ReadFromExcel(8, 18);
                string readSummary = excel.ReadFromExcel(4, 18);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

                
                excel.OpenExcel(TestSetup.excelPath, 3);
                
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunRegisterWithPasswordWrongWithoutSmallLetter()
        {
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
           
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1, random.Next(5, 6));
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(13, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(13, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegisterWithPasswordWrongWithoutSmallLetter(user) == false)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 19, "User can not complete registration successfully");
                excel.WriteOnExcel(9, 19, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 19, "User can complete registration successfully");
                excel.WriteOnExcel(9, 19, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 19);
                string readActualResult = excel.ReadFromExcel(8, 19);
                string readSummary = excel.ReadFromExcel(4, 19);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

                
                excel.OpenExcel(TestSetup.excelPath, 3);
                
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunRegisterWithPasswordWrongLessThanSixElements()
        {
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1, random.Next(5,6));
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(14, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(14, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegisterWithPasswordWrongLessThanSixElements(user) == false)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 20, "User can not complete registration successfully");
                excel.WriteOnExcel(9, 20, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 20, "User can complete registration successfully");
                excel.WriteOnExcel(9, 20, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 20);
                string readActualResult = excel.ReadFromExcel(8, 20);
                string readSummary = excel.ReadFromExcel(4, 20);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

                
                excel.OpenExcel(TestSetup.excelPath, 3);
                
                
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();
            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunRegisterWithPasswordWrongMoreThanTwentyElements()
        {
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1, random.Next(5, 6));
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(15, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(15, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegisterWithPasswordWrongMoreThanTwentyElements(user) == false)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 21, "User can not complete registration successfully");
                excel.WriteOnExcel(9, 21, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 21, "User can complete registration successfully");
                excel.WriteOnExcel(9, 21, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 21);
                string readActualResult = excel.ReadFromExcel(8, 21);
                string readSummary = excel.ReadFromExcel(4, 21);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

                
                excel.OpenExcel(TestSetup.excelPath, 3);
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();

            }
            System.Threading.Thread.Sleep(2000);
        }
        [TestMethod]
        public void RunRegistrationWithPasswordsDoNotMatch()
        {
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
           
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = excel.ReadFromExcel(4, random.Next(2, 16));
            user.Email = excel.ReadFromExcel(1, random.Next(5, 6));
            user.Password = excel.ReadFromExcel(8, random.Next(2, 16));
            user.PasswordConfirmation = excel.ReadFromExcel(9, random.Next(2, 16));
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegistrationWithPasswordsDoNotMatch(user) == true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 22, "User can not complete registration successfully");
                excel.WriteOnExcel(9, 22, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 22, "User can complete registration successfully");
                excel.WriteOnExcel(9, 22, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 22);
                string readActualResult = excel.ReadFromExcel(8, 22);
                string readSummary = excel.ReadFromExcel(4, 22);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

                
                excel.OpenExcel(TestSetup.excelPath, 3);
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();

            }
            System.Threading.Thread.Sleep(2000);
        }
       
        [TestMethod]
        public void RunRegistrationWithRegisteredPhone()
        {
            User user = new User();
            Random random = new Random();
            Excel excel = new Excel();
            
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            TestSetup.NumOfTestCasesRegisterAsVendor();
            user.FName = GenerateCorrectUserData.CreateFName();
            user.LName = GenerateCorrectUserData.CreateLName();
            user.Gender = GenerateCorrectUserData.CreateGender();
            user.DateOfBirth = GenerateCorrectUserData.DateOfBirthRightIsEqualToOrGreaterThanSixteenYears();
            System.Threading.Thread.Sleep(2000);
            //1-open excel
            excel.OpenExcel(TestSetup.excelPath, 4);
            //2-read from it

            user.PhoneNumber = "0789456123";
            user.Email = excel.ReadFromExcel(1,5);
            int Rowrnd = random.Next(2, 16);
            user.Password = excel.ReadFromExcel(8, Rowrnd);
            user.PasswordConfirmation = excel.ReadFromExcel(8, Rowrnd);
            System.Threading.Thread.Sleep(2000);
            //3-close it
            excel.CloseExcel();
            if (RegistrationWithRegisteredPhone(user) == true)
            {
               excel.OpenExcel(TestSetup.excelPath, 2);
               excel.WriteOnExcel(8, 23, "User can not complete registration successfully");
               excel.WriteOnExcel(9, 23, "Pass");
               excel.CloseExcel();
            }
            else
            {
               excel.OpenExcel(TestSetup.excelPath, 2);
               excel.WriteOnExcel(8, 23, "User can complete registration successfully");
               excel.WriteOnExcel(9, 23, "Fail");
               excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 23);
                string readActualResult = excel.ReadFromExcel(8, 23);
                string readSummary = excel.ReadFromExcel(4, 23);
                dataOfBugRepoert.ExpectedResult = readExpectedResult;
                dataOfBugRepoert.ActualResult = readActualResult;
                dataOfBugRepoert.Summary = readSummary;
                dataOfBugRepoert.OperatingSystem = "Windows 10";
                dataOfBugRepoert.Browser = "Chrome";
                excel.CloseExcel();

                
                excel.OpenExcel(TestSetup.excelPath, 3);
                
                excel.WriteOnFirstEmptyColumn(8, dataOfBugRepoert.Summary);
                excel.WriteOnFirstEmptyColumn(12, dataOfBugRepoert.OperatingSystem);
                excel.WriteOnFirstEmptyColumn(13, dataOfBugRepoert.Browser);
                excel.WriteOnFirstEmptyColumn(15, dataOfBugRepoert.ExpectedResult);
                excel.WriteOnFirstEmptyColumn(16, dataOfBugRepoert.ActualResult);
                excel.CloseExcel();

            }
            System.Threading.Thread.Sleep(2000);

            //WriteSummaryReport
            excel.OpenExcel(TestSetup.excelPath, 1);
            excel.WriteOnExcel(6, 6, Convert.ToString(TestSetup.NumOfTestCasesRegisterAsVendor()- 1));
            excel.CloseExcel();
        }
    }

}
