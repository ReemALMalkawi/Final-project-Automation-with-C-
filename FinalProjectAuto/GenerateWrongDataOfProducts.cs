using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAuto
{
    public class GenerateWrongDataOfProducts
    {
        public static string CreateWrongPrice()
        {
            string[] price = { "mk", "*-7", "&v" };
            Random random = new Random();
            int rnd = random.Next(0, price.Length);
            string priceOfProduct = price[rnd];
            return priceOfProduct;
        }

        public static string CreateWrongImage()
        {
            string[] Image = { @"C:\Users\USER\Desktop\TAHALUF\slids\FinalProject\Password.pdf" };
            Random random = new Random();
            int rnd = random.Next(0, Image.Length);
            string ImageOfProduct = Image[rnd];
            return ImageOfProduct;
        }
    }
}
