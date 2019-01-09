using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>()
            {
                new Person{ Name = "Vitaliy", Age = 21, ID = 66, Father = 23, Gender = 'm'},
                new Person{ Name = "Lena", Age = 45, ID = 23, Father = 34, Gender = 'w'},
                new Person{ Name = "Lock", Age = 70, ID = 23, Father = 29, Gender = 'm'},
                new Person{ Name = "John", Age = 56, ID = 29, Father = 22, Gender = 'm'},
                new Person{ Name = "Veronica", Age = 22, ID = 22, Father = 77, Gender = 'w'},
                new Person{ Name = "Ira", Age = 28, ID = 2, Father = 66, Gender = 'w'},
                new Person{ Name = "Maksim", Age = 66, ID = 23, Father = 59, Gender = 'm'}
            };

            var result = from p in persons
                         where p.Gender == 'm'
                         select p;
            var result1 = from p in persons
                         where p.Gender == 'w'
                         select p;
            foreach (var p in result)
            {
                
                 Console.WriteLine($"He is {p.Age} years old");
            }
            foreach (var p in result1)
            {

                Console.WriteLine($"She is {p.Age} years old");
            }

            var result2 = (from p in persons
                          where p.Gender == 'm' && p.Age > 40
                          select p).Count();
            var result3 = (from p in persons where p.Gender == 'w' && p.Age > 40 select p).Count();
            Console.WriteLine($"There are {result2} of men under 40 and {result3} of women under 40");

            var result4 = from p2 in persons
                          join p3 in persons on p2.Father equals p3.ID
                          join p4 in persons on p3.Father equals p4.ID
                          select new { Name1 = p2.Name, Name2 = p3.Name, Name3 = p4.Name };

            foreach (var item in result4)
                Console.WriteLine(item.Name1 + " - " + item.Name2 + " - " + item.Name3);
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }
        public int Father { get; set; }
        public char Gender { get; set; }
    }
}
