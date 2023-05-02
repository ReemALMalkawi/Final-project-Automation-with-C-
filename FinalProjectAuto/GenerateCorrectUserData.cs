using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAuto
{
    public class GenerateCorrectUserData
    {
        public static string CreateFName()
        {
            string[] fNames = { "Reem", "Farah", "Alaa", "Malak" };
            Random random = new Random();
            int rnd = random.Next(0, fNames.Length);
            string fName = fNames[rnd];
            return fName;
        }
        public static string DateOfBirthRightIsEqualToOrGreaterThanSixteenYears()
        {
            string DateRight = "";
            Random random = new Random();
            string[] Years = { "1999", "2001", "1997", "1995","2002","1989","1975" };
            string[] Months = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            string[] Days = { "1","2","14","17","20","22","25","28","24"};
            int rnd = random.Next(0, Years.Length);
            int rnd1 = random.Next(0, Months.Length);
            int rnd2 = random.Next(0, Days.Length);
            DateRight = Months[rnd1] + "/" + Days[rnd2] + "/" + Years[rnd];
            return DateRight;
        }
        public static string DateOfBirthWrongIsLessThanSixteenYears()
        {
            string DateWrong = "";
            Random random = new Random();
            string[] Years = { "2005", "2007", "2008", "2004", "2009", "2010", "2011" };
            string[] Months = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
            string[] Days = { "01", "02", "14", "17", "20", "22", "25", "28", "24" };

            int rnd = random.Next(0, Years.Length);
            int rnd1 = random.Next(0, Months.Length);
            int rnd2 = random.Next(0, Days.Length);
            DateWrong = Months[rnd1] + "/" + Days[rnd2] +"/" + Years[rnd];
            return DateWrong;
        }

        public static string CreateLName()
        {
            string[] lNames = { "Ahmad", "Mohammad", "Ali", "Amen" };
            Random random = new Random();
            int rnd = random.Next(0, lNames.Length);
            string lName = lNames[rnd];
            return lName;
        }
        public static string CreateGender()
        {
            string[] Gneders = { "Male", "Female" };
            Random random = new Random();
            int rnd = random.Next(0, Gneders.Length);
            string Gneder = Gneders[rnd];
            return Gneder;
        }
    }
}
