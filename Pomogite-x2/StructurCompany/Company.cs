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
        public List<Departament> Departaments = new List<Departament>();
        //коллекция студентов
        public List<Student> Students = new List<Student>();
        //коллекция работников
        public List<Worker> Workers = new List<Worker>();
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
        /// <summary>
        /// вывод измененной компании
        /// </summary>
            public void PrintNew(Company company)
            {
            // создание новой компании с информацией с файла 
            List<Worker> workers = new List<Worker>();
            List<Student> students = new List<Student>();
            List<Departament> departaments = new List<Departament>();
                foreach (var wor in company.Workers)
                {
                    workers.Add(new Worker(wor.Name, wor.LastName, wor.Age, wor.Salary, wor.IdDepart));
                }
                foreach (var stud in company.Students)
                {
                    students.Add(new Student(stud.Name, stud.LastName, stud.Age, stud.Salary, stud.IdDepart));
                }
                foreach (var dep in company.Departaments)
                {
                    departaments.Add(new Departament(dep.NameDepartament, dep.Quantity, dep.ID));// запись департаментов
                }
                Company companyNew = new Company(company.NameCompany, departaments, workers, students);// запись компании
                                                                                                       
                                                                                                       //вывод новой компании
                Console.WriteLine(companyNew.NameCompany);
                foreach (var dep in companyNew.Departaments)
                 {
                    Console.WriteLine(dep.ToString());
                    foreach (var wor in companyNew.Workers)
                    {
                        if(dep.ID == wor.IdDepart)
                        Console.WriteLine(wor.ToString());
                    }
                    foreach (var stud in companyNew.Students)
                    {
                        if (dep.ID == stud.IdDepart)
                            Console.WriteLine(stud.ToString());
                    }
                 }
            }
        /// <summary>
        /// происходит десериализация файла
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public  Company DeserializeXml(string path)// десериализации Xml
        {

            Company сompany = new Company();

            // создания сериализации для листа
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Company));

              Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);// создания потока

            сompany = xmlSerializer.Deserialize(stream) as Company;//десериализация

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
