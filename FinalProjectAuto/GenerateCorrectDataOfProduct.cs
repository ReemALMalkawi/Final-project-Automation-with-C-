using OpenQA.Selenium.DevTools.V101.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAuto
{
    public class GenerateCorrectDataOfProduct
    {
        public static string CreateNameOfProduct()
        {
            string[] NameOfProduct = { "Knitting", "Carpenter", "Smith" , "Carpenter43", "Smith*-" };
            Random random = new Random();
            int rnd = random.Next(0, NameOfProduct.Length);
            string nameOfProduct = NameOfProduct[rnd];
            return nameOfProduct;
        }
        public static string CreateCategoryOfProduct()
        {
            string[] CategoryOfProduct = { "WoodWork", "Ceramic", "Blacksmith" };
            Random random = new Random();
            int rnd = random.Next(0, CategoryOfProduct.Length);
            string categoryOfProduct = CategoryOfProduct[rnd];
            return categoryOfProduct;
        }
        public static string CreateSaleOfProduct()
        {
            string[] SaleOfProduct = { "20%", "15%", "10%","30%","50%","60%" };
            Random random = new Random();
            int rnd = random.Next(0, SaleOfProduct.Length);
            string saleOfProduct = SaleOfProduct[rnd];
            return saleOfProduct;
        }
        public static string CreateDescription()
        {
            string[] Description = { "Hand Made","Amazing" };
            Random random = new Random();
            int rnd = random.Next(0, Description.Length);
            string DescriptionOfProduct = Description[rnd];
            return DescriptionOfProduct;
        }
        public static string CreatePrice()
        {
            string[] price = { "30", "28", "34" };
            Random random = new Random();
            int rnd = random.Next(0, price.Length);
            string priceOfProduct = price[rnd];
            return priceOfProduct;
        }
        
        public static string CreateImage()
        {
            string [] Image = { @"C:\Users\USER\Desktop\TAHALUF\slids\FinalProject/images.jfif"};
            Random random = new Random();
            int rnd = random.Next(0, Image.Length);
            string ImageOfProduct = Image[rnd];
            return ImageOfProduct;
        }
    }
}
