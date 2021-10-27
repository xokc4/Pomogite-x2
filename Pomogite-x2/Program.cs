using Pomogite_x2.StructurCompany;
using System;

namespace Pomogite_x2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @".\Company.xml";
            Company company = new Company();
            company = company.DeserializeXml(path);
            company.PrintNew(company);
        }
    }
}
