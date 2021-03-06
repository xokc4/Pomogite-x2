using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomogite_x2.PeoplePost
{
   public class Student:People
   {
        public Student()
        {

        }
        public Student(string name, string lastName, int age, int salary, int idDepart) : base(name, lastName, age, salary, idDepart)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = SalaryWorks();
            this.IdDepart = idDepart;
        }

        //наследуемый коструктор для студента 

        //наследуемый вывод
        public new string ToString()
        {
            return $"имя студента: {Name} Фамилия: {LastName} Возраст: {Age} зарплата: {Salary} айди: {IdDepart}";
        }
   }
}
