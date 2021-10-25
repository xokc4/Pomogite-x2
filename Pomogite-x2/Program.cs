using Pomogite_x2.StructurCompany;
using System;

namespace Pomogite_x2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\poc18\OneDrive\Рабочий стол\задание4\Company.xml";
            Company company = new Company(path);
            //вывод компании с файла
            company.PrintOld();
            // вывод измененной компании
            company.PrintNew();
        }
    }
}
