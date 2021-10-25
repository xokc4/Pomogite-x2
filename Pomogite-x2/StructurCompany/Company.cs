using Pomogite_x2.PeoplePost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pomogite_x2.StructurCompany
{
   public class Company
    {
        // названия кмпании
        public string NameCompany { get; set; }
        //коллекция департаментов
        public List<Departament> Departaments { get; set; }
        //коллекция студентов
        public List<Student> Students = new List<Student>();
        //коллекция работников
        public List<Worker> Workers = new List<Worker>();
        //коллекция новой компании с изменеии зарплаты
        public List<Company> company = new List<Company>();
        //конструктор создания компании
        public Company()
        {

        }
        public Company(string nameCompany, List<Departament> departaments, List<Worker> workers, List<Student> students)
        {
            this.NameCompany = nameCompany;
            this.Departaments = departaments;
            this.Workers = workers;
            this.Students = students;
        }
        public Company(string path)
        {
            company = DeserializeXml(path);
        }
        /// <summary>
        /// вывод компании с файла
        /// </summary>
        public void PrintOld()
        {
            foreach(var item in company)
            {
                Console.WriteLine(item.ToString());
                foreach (var dep in item.Departaments)
                {
                    Console.WriteLine(dep.ToString());

                    foreach (var wor in item.Workers)
                    {
                        if(dep.ID ==wor.IdDepart)
                            Console.WriteLine(wor.ToString());
                    }
                    foreach (var stud in item.Students)
                    {
                        if(dep.ID == stud.IdDepart)
                        Console.WriteLine(stud.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// вывод измененной компании
        /// </summary>
            public void PrintNew()
            {
                List<Company> companyNew = new List<Company>();
                List<Departament> departaments = new List<Departament>();
                List<Student> sTud = new List<Student>();
                List<Worker> work = new List<Worker>();
                // создание новой компании с информацией с файла 
                foreach (var item in company)// вывод компании
                {
                foreach (var wor in item.Workers)
                {
                    
                    work.Add(new Worker(wor.Name, wor.LastName, wor.Age, wor.Salary, wor.IdDepart, wor.IdGetDep));
                }
                foreach (var stud in item.Students)
                {
                    sTud.Add(new Student(stud.Name, stud.LastName, stud.Age, stud.Salary, stud.IdDepart, stud.IdGetDep));
                }
                foreach (var dep in item.Departaments)
                {
                    departaments.Add(new Departament(dep.NameDepartament, dep.Quantity, dep.ID, dep.IdGetDep));// запись департаментов
                }
                    companyNew.Add(new Company(item.NameCompany, departaments, work, sTud));// запись компании
                } //вывод информации с файла
            Console.WriteLine();
            Console.WriteLine("измененная компания");
            Console.WriteLine();
            //вывод новой компании
            foreach (var neu in companyNew)// вывод компании
              {
                Console.WriteLine(neu.ToString());
                 foreach (var dep in neu.Departaments)
                 {
                    Console.WriteLine(dep.ToString());
                    foreach (var wor in neu.Workers)
                    {
                        if(dep.ID == wor.IdDepart)
                        Console.WriteLine(wor.ToString());
                    }
                    foreach (var stud in neu.Students)
                    {
                        if (dep.ID == stud.IdDepart)
                            Console.WriteLine(stud.ToString());
                    }
                 }
              } // вывод новой компании 
            }
        /// <summary>
        /// происходит десериализация файла
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<Company> DeserializeXml(string path)// десериализации Xml
        {

            List<Company> сompany = new List<Company>();

            // создания сериализации для листа
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Company>));

              Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);// создания потока

            сompany = xmlSerializer.Deserialize(stream) as List<Company>;//десериализация

            stream.Close();// закрытие потока

            return сompany;
        }
        //вывод информации
        public new string ToString()
        {
            return $"Имя компании: {NameCompany}";
        }
    }
}
