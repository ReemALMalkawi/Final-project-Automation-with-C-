using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace FinalProjectAuto
{
    
    [TestClass]
    public class AddProduct
    {
       
        public static void LogInBtnTest()
        {
            TestSetup.NavigateToURL();
            IWebElement signUpElement = TestSetup.driver.FindElement(By.XPath("//div[@class='social flex-w flex-l-m p-r-20']//a[normalize-space()='Login']"));
            TestSetup.Highlight(signUpElement);
            signUpElement.Click();
            System.Threading.Thread.Sleep(2000);
            IWebElement logInElement = TestSetup.driver.FindElement(By.XPath("//p[@class='lead fw-normal mb-0 me-3']"));
            string logInText = logInElement.GetAttribute("innerText");
            if (logInText == "Login")
            {
                Console.WriteLine("LogIn button wroks correctly (pass)");
            }
            else
            {
                Console.WriteLine("LogIn button doesn't wrok  (fail)");
            }
        }
        public static void TestLogInAsVendor()
        {
            LogInBtnTest();
            IWebElement emailElement = TestSetup.driver.FindElement(By.XPath("//input[@id='Email']"));
            TestSetup.Highlight(emailElement);
            emailElement.SendKeys("rahafmalkawi5820040@gmail.com");
            System.Threading.Thread.Sleep(1000);

            IWebElement passElement = TestSetup.driver.FindElement(By.XPath("//input[@id='myPass1']"));
            TestSetup.Highlight(passElement);
            passElement.SendKeys("Rahaf2004*");
            System.Threading.Thread.Sleep(1000);

            IWebElement LogInBtnElement = TestSetup.driver.FindElement(By.XPath("//button[normalize-space()='Login']"));
            TestSetup.Highlight(LogInBtnElement);
            LogInBtnElement.Click();
            System.Threading.Thread.Sleep(2000);
        }
        public static void PositiveLogIn()
        {
            TestLogInAsVendor();
            IWebElement wlcElement = TestSetup.driver.FindElement(By.XPath("//div[@class='wrap-btn-slide1 animated visible-false slideInUp visible-true']//a[@class='btn1 flex-c-m size1 txt3 trans-0-4'][normalize-space()='Get Started']"));
            string wlcText = wlcElement.GetAttribute("innerText");
            if (wlcText == "Get Started")
            {
                Console.WriteLine("Registered users can login successfully(pass)");
                IWebElement profileElement = TestSetup.driver.FindElement(By.XPath("//div[@class='social flex-w flex-l-m p-r-20']//div[@id='dropdownaa']//button[@id='dropdownMenuButton']//a[@href='#']"));
                TestSetup.Highlight(profileElement);
                profileElement.Click();
                System.Threading.Thread.Sleep(2000);

                IWebElement MyProductsElement = TestSetup.driver.FindElement(By.XPath("//div[@class='dropdown-menu text-danger show']//a[1]"));
                TestSetup.Highlight(MyProductsElement);
                MyProductsElement.Click();
                System.Threading.Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Registered users can't login successfully(Fail)");
                
            }

        }
        public static void MyProductsPageTest()
        {
            PositiveLogIn();
            IWebElement ProfileElement = TestSetup.driver.FindElement(By.XPath("//div[@class='social flex-w flex-l-m p-r-20']//button[@id='dropdownMenuButton']"));
            TestSetup.Highlight(ProfileElement);
            ProfileElement.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement MyProductsElement = TestSetup.driver.FindElement(By.XPath("//body//header//a[3]"));
            TestSetup.Highlight(MyProductsElement);
            MyProductsElement.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement AddnewProductsElement = TestSetup.driver.FindElement(By.XPath("//a[normalize-space()='Add New Product']"));
            TestSetup.Highlight(AddnewProductsElement);
            AddnewProductsElement.Click();
            System.Threading.Thread.Sleep(2000);

            IWebElement AddNewProductPageElement = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string AddNewProductPageText = AddNewProductPageElement.GetAttribute("innerText");
            if(AddNewProductPageText == "Add New Product:")
            {
                Console.WriteLine("Add New Product Button is working(Pass)");
            }
            else
            {
                Console.WriteLine("Add New Product Button is not working(Fail)");
            }
        }
        public static void AddNewProductMethod(DataOfProduct dataOfProduct)
        {
            MyProductsPageTest();
            IWebElement NameElement = TestSetup.driver.FindElement(By.XPath("//input[@placeholder='Enter the product name']"));
            TestSetup.Highlight(NameElement);
            NameElement.SendKeys(dataOfProduct.Name);
            System.Threading.Thread.Sleep(1000);

            IWebElement DescriptionElement = TestSetup.driver.FindElement(By.XPath("//textarea[@name='description']"));
            TestSetup.Highlight(DescriptionElement);
            DescriptionElement.SendKeys(dataOfProduct.Description);
            System.Threading.Thread.Sleep(1000);

            //upload image
            IWebElement loadImageElement = TestSetup.driver.FindElement(By.XPath("//input[@name='imageFile']"));
            loadImageElement.SendKeys(dataOfProduct.Image);
            TestSetup.Highlight(loadImageElement);
            System.Threading.Thread.Sleep(2000);

            IWebElement CategoryElement = TestSetup.driver.FindElement(By.XPath("//select[@name='categoryId']"));
            TestSetup.Highlight(CategoryElement);
            CategoryElement.SendKeys(dataOfProduct.Category);
            System.Threading.Thread.Sleep(1000);

            IWebElement PriceElement = TestSetup.driver.FindElement(By.XPath("//input[@placeholder='Enter the product price']"));
            TestSetup.Highlight(PriceElement);
            PriceElement.SendKeys(dataOfProduct.Price);
            System.Threading.Thread.Sleep(1000);


            IWebElement SaleElement = TestSetup.driver.FindElement(By.XPath("//select[@name='Sale']"));
            TestSetup.Highlight(SaleElement);
            SaleElement.SendKeys(dataOfProduct.Sale);
            System.Threading.Thread.Sleep(1000);
           

            IWebElement addBtnElement = TestSetup.driver.FindElement(By.XPath("//button[normalize-space()='Add']"));
            TestSetup.Highlight(addBtnElement);
            addBtnElement.Click();
            System.Threading.Thread.Sleep(2000);
        }
        public static bool positiveAddProduct(DataOfProduct dataOfProduct)
        {
            AddNewProductMethod(dataOfProduct);
            
            IWebElement addedSuccessfully = TestSetup.driver.FindElement(By.XPath("//div[@role='alert']"));
            string addedSuccessfullyText = addedSuccessfully.GetAttribute("innerText");
            if(addedSuccessfullyText == "Product Added Successfully")
            {
                Console.WriteLine("Added Product by vendor successfully(Pass)");
                return true;
            }
            else
            {
                Console.WriteLine("Not added New Product(Fail)");
                return false;
            }
        }
        public static bool AddProductWithNameFiedlIsEmpty(DataOfProduct dataOfProduct)
        {
            AddNewProductMethod(dataOfProduct);
            IWebElement addedNotSuccessfully = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string addedNotSuccessfullyText = addedNotSuccessfully.GetAttribute("innerText");
            if (addedNotSuccessfullyText == "Add New Product:")
            {
                Console.WriteLine("Added New Product by vendor does not successfully(Pass)");
                return true;
            }
            else
            {
                Console.WriteLine("added New Product by vendor(Fail)");
                return false;
            }
        }
        public static bool AddProductWithWrongFormatPrice(DataOfProduct dataOfProduct)
        {
            AddNewProductMethod(dataOfProduct);
            IWebElement addedSuccessfully = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string addedSuccessfullyText = addedSuccessfully.GetAttribute("innerText");
            if (addedSuccessfullyText == "Add New Product:")
            {
                Console.WriteLine("Added New Product by vendor does not successfully(Pass)");
                return true;
            }
            else
            {
                Console.WriteLine("added New Product by vendor(Fail)");
                return false;
            }
        }
        public static bool AddProductWithPriceFiedlIsEmpty(DataOfProduct dataOfProduct)
        {
            AddNewProductMethod(dataOfProduct);
            IWebElement addedSuccessfully = TestSetup.driver.FindElement(By.XPath("//h5[@id='staticBackdropLabel']"));
            string addedSuccessfullyText = addedSuccessfully.GetAttribute("innerText");
            if (addedSuccessfullyText == "Add New Product:")
            {
                Console.WriteLine("Added New Product by vendor does not successfully(Pass)");
                return true;
            }
            else
            {
                Console.WriteLine("added New Product by vendor(Fail)");
                return false;
            }
        }
        public static bool AddProductWithIncorrectImage(DataOfProduct dataOfProduct)
        {
            AddNewProductMethod(dataOfProduct);
            
            IWebElement addedSuccessfully = TestSetup.driver.FindElement(By.XPath("//a[normalize-space()='Herfa']"));
            string addedSuccessfullyText = addedSuccessfully.GetAttribute("innerText");
            if (addedSuccessfullyText == "Herfa")
            {
                Console.WriteLine("Added Product by vendor successfully(Fail)");
                return true;
            }
            else
            {
                Console.WriteLine("Not added New Product(Pass)");
                return false;
            }
        }

        [TestMethod]
        public void RunPositiveAddProduct()
        {
            Excel excel = new Excel();
            DataOfProduct dataOfProduct = new DataOfProduct();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            TestSetup.NumOfTestCasesAddProduct();
           
            dataOfProduct.Name = GenerateCorrectDataOfProduct.CreateNameOfProduct();
            dataOfProduct.Description = GenerateCorrectDataOfProduct.CreateDescription();
            dataOfProduct.Image = GenerateCorrectDataOfProduct.CreateImage();
            dataOfProduct.Category = GenerateCorrectDataOfProduct.CreateCategoryOfProduct();
            dataOfProduct.Price = GenerateCorrectDataOfProduct.CreatePrice();
            dataOfProduct.Sale = GenerateCorrectDataOfProduct.CreateSaleOfProduct();

            if (positiveAddProduct(dataOfProduct) == true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 25, "Vendor added new product Successfully(Pass)");
                excel.WriteOnExcel(9, 25, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 25, "Vendor Can not Added New Product(Fail)");
                excel.WriteOnExcel(9, 25, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 25);
                string readActualResult = excel.ReadFromExcel(8, 25);
                string readSummary = excel.ReadFromExcel(4, 25);
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
            excel.WriteOnExcel(6, 7, Convert.ToString(TestSetup.NumOfTestCasesAddProduct()-1));
            excel.CloseExcel();
        }
        [TestMethod]
        public void RunAddProductWithNameFeildIsEmpty()
        {
            Excel excel = new Excel();
            DataOfProduct dataOfProduct = new DataOfProduct();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            
            TestSetup.NumOfTestCasesAddProduct();
            dataOfProduct.Name = "";
            dataOfProduct.Description = GenerateCorrectDataOfProduct.CreateDescription();
            dataOfProduct.Image = GenerateCorrectDataOfProduct.CreateImage();
            dataOfProduct.Category = GenerateCorrectDataOfProduct.CreateCategoryOfProduct();
            dataOfProduct.Price = GenerateCorrectDataOfProduct.CreatePrice();
            dataOfProduct.Sale = GenerateCorrectDataOfProduct.CreateSaleOfProduct();

            if (AddProductWithNameFiedlIsEmpty(dataOfProduct) == true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 26, "Vendor can not added new product Successfully(Pass)");
                excel.WriteOnExcel(9, 26, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 26, "Vendor Can Added New Product(Fail)");
                excel.WriteOnExcel(9, 26, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 26);
                string readActualResult = excel.ReadFromExcel(8, 26);
                string readSummary = excel.ReadFromExcel(4, 26);
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
        public void RunAddProductWithWrongFormatPrice()
        {
            Excel excel = new Excel();
            DataOfProduct dataOfProduct = new DataOfProduct();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            
            TestSetup.NumOfTestCasesAddProduct();
            dataOfProduct.Name = GenerateCorrectDataOfProduct.CreateNameOfProduct();
            dataOfProduct.Description = GenerateCorrectDataOfProduct.CreateDescription();
            dataOfProduct.Image = GenerateCorrectDataOfProduct.CreateImage();
            dataOfProduct.Category = GenerateCorrectDataOfProduct.CreateCategoryOfProduct();
            dataOfProduct.Price = GenerateWrongDataOfProducts.CreateWrongPrice();
            dataOfProduct.Sale = GenerateCorrectDataOfProduct.CreateSaleOfProduct();

            if (AddProductWithWrongFormatPrice(dataOfProduct) == true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 27, "Vendor can not added new product Successfully(Pass)");
                excel.WriteOnExcel(9, 27, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 27, "Vendor Can Added New Product(Fail)");
                excel.WriteOnExcel(9, 27, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 27);
                string readActualResult = excel.ReadFromExcel(8, 27);
                string readSummary = excel.ReadFromExcel(4, 27);
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
        public void RunAddProductWithPriceFieldIsEmpty()
        {
            Excel excel = new Excel();
            DataOfProduct dataOfProduct = new DataOfProduct();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
           
            TestSetup.NumOfTestCasesAddProduct();
            dataOfProduct.Name = GenerateCorrectDataOfProduct.CreateNameOfProduct();
            dataOfProduct.Description = GenerateCorrectDataOfProduct.CreateDescription();
            dataOfProduct.Image = GenerateCorrectDataOfProduct.CreateImage();
            dataOfProduct.Category = GenerateCorrectDataOfProduct.CreateCategoryOfProduct();
            dataOfProduct.Price = "";
            dataOfProduct.Sale = GenerateCorrectDataOfProduct.CreateSaleOfProduct();

            if (AddProductWithPriceFiedlIsEmpty(dataOfProduct) == true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 28, "Vendor can not added new product Successfully(Pass)");
                excel.WriteOnExcel(9, 28, "Pass");
                excel.CloseExcel();
            }
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 28, "Vendor Can Added New Product(Fail)");
                excel.WriteOnExcel(9, 28, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 28);
                string readActualResult = excel.ReadFromExcel(8, 28);
                string readSummary = excel.ReadFromExcel(4, 28);
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
        public void RunAddProductWithIncorrectImage()
        {
            Excel excel = new Excel();
            DataOfProduct dataOfProduct = new DataOfProduct();
            DataOfBugRepoert dataOfBugRepoert = new DataOfBugRepoert();
            
            TestSetup.NumOfAddProduct = 0;
            TestSetup.NumOfTestCasesAddProduct();
            dataOfProduct.Name = GenerateCorrectDataOfProduct.CreateNameOfProduct();
            dataOfProduct.Description = GenerateCorrectDataOfProduct.CreateDescription();
            dataOfProduct.Image = GenerateWrongDataOfProducts.CreateWrongImage();
            dataOfProduct.Category = GenerateCorrectDataOfProduct.CreateCategoryOfProduct();
            dataOfProduct.Price = GenerateCorrectDataOfProduct.CreatePrice();
            dataOfProduct.Sale = GenerateCorrectDataOfProduct.CreateSaleOfProduct();

            if (AddProductWithIncorrectImage(dataOfProduct) == true)
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 29, "Vendor added new product Successfully");
                excel.WriteOnExcel(9, 29, "Fail");
                excel.CloseExcel();

                excel.OpenExcel(TestSetup.excelPath, 2);
                string readExpectedResult = excel.ReadFromExcel(7, 29);
                string readActualResult = excel.ReadFromExcel(8, 29);
                string readSummary = excel.ReadFromExcel(4, 29);
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
            else
            {
                excel.OpenExcel(TestSetup.excelPath, 2);
                excel.WriteOnExcel(8, 29, "Vendor Can not Added New Product");
                excel.WriteOnExcel(9, 29, "Pass");
                excel.CloseExcel();               
            }
            System.Threading.Thread.Sleep(2000);
            
            
        }
        
    }
}
