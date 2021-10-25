using Pomogite_x2.StructurCompany;
using System;

namespace Pomogite_x2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Company.xml";
            Company company = new Company(path);
            //вывод компании с файла
            company.PrintOld();
            // вывод измененной компании
            company.PrintNew();
        }
    }
}
