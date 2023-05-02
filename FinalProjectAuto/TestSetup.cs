using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalProjectAuto
{
    public class TestSetup
    {
        public static IWebDriver driver = new ChromeDriver();// to open browser
        public static string URL = "https://localhost:44349/ ";// url to open
        public static string excelPath = @"C:\Users\USER\Desktop\TAHALUF\slids\FinalProject\ExcelFianlAuto3.xlsx";
        public static int NumOfRegisterAsVendor = 0;
        public static int NumOfAddProduct = 0;
        //public static int numOfTestCases = 0;
        public static void NavigateToURL()
        {
            driver.Manage().Window.Size = new Size(1300, 850);//to open browser window
            driver.Navigate().GoToUrl(URL);//to open the selected address            
        }
        public static void Highlight(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;// reach to chrome driver and write js
            executor.ExecuteScript("arguments[0].setAttribute('style','background:lightblue !important')", element); //to write js code on HTML element
            System.Threading.Thread.Sleep(2000);
            executor.ExecuteScript("arguments[0].setAttribute('style','border:solid 1px white !important')", element); //to write js code on HTML element
        }
        //public static int NumOfTestCases()
        //{           
        //    numOfTestCases++;
        //    return numOfTestCases;
        //}
        public static int NumOfTestCasesRegisterAsVendor()
        {
            NumOfRegisterAsVendor++;
            return NumOfRegisterAsVendor;
        }
        public static int NumOfTestCasesAddProduct()
        {
           NumOfAddProduct ++;
           return NumOfAddProduct;
        }
}
}
