using System;

using System.Collections.Generic;

using System.Linq;

namespace LinqOnObjects
{

    internal class Person
    {
        private string _name;
        private int _height;
        private int _weight;

        private Gender gender;

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public int Height
        {
            get { return this._height; }
            set { this._height = value; }
        }

        public int Weight
        {
            get { return this._weight; }
            set { this._weight = value; }
        }

        public Gender Gender { get; set; }

        public Person(string name, int weight, int height, Gender gender)
        {
            this.Name = name;
            this.Height = height;
            this.Weight = weight;
            this.Gender = gender;
        }
    }

    internal enum Gender
    {
        Male,
        Female
    }

    public class LingQObjects
    {
        static void Main()
        {
            List<Person> people = new List<Person>()
            {
                new Person("Tod", 180, 70, Gender.Male),
                new Person("John", 170, 88, Gender.Male),
                new Person("Anna", 150, 48, Gender.Female),
                new Person("Kyle", 164, 77, Gender.Male),
                new Person("Anna", 164, 77, Gender.Female),
                new Person("Maria", 150, 55, Gender.Female),
                new Person("John", 160, 55, Gender.Female),
                 new Person("John", 161, 55, Gender.Female)
            };


            var grouped = (from person in people group person by person.Gender).ToList();


            var groupedPeople = people.Where(p => p.Height > 50).OrderBy(p => p.Height).GroupBy(p => new { p.Name, p.Height }).OrderBy(p => p.Count()).Select(p => p).ToList();

            //foreach (var group in groupedPeople)
            //{
            //    Console.WriteLine($"\nKey: {group.Key}");
            //    foreach (var item in group)
            //    {
            //        Console.WriteLine(item.Name);
            //    }


            //}



            grouped.ForEach(item => {
                Console.WriteLine($"Key: {item.Key}");
                item.ToList().ForEach(person =>
                Console.WriteLine($" -- {person.Name}")
                );
               } );

            groupedPeople.ForEach(item => {
                Console.WriteLine($"\nKey: {item.Key}");
                item.ToList().ForEach(person =>
                {
                    Console.WriteLine($"{item.Key} {person.Name} - Weight: {person.Weight}");
                }
                );
            });


            //groupedPeople.ForEach(group => {
            //    Console.WriteLine($"\nKey -- {group.Key}");

            //    var sorted = group.OrderBy(p => p.Name).ToList();

            //    sorted.ForEach(item => Console.WriteLine($"First write in line: {item.Name}"));

            //    foreach (var item in group)
            //    {
            //        Console.WriteLine($"Second Write with foreach: {item.Name}");
            //    }
            //});

            //PrintList(people);

            //List<Person> sortedPeople = (from person in people orderby person.Name select person).ToList();

            //Console.WriteLine();

            ////PrintList(sortedPeople);

            //List<Person> namesOver4 = (from person in people where person.Name.Length == 4 orderby 
            //                           person.Name,
            //                           person.Weight, person.Height select person).ToList();

            //Console.WriteLine();

            ////PrintList(namesOver4);
            ////List<Person> withLambda = (from person in people where (person.Weight > 50) select person).ToList();
            //List<Person> withLambda = people.Where(person => person.Weight > 50).ToList();

            //(string? personName, int? perosnWeight) = people.Where(person => person.Name.ToLower().Contains("n") && person.Height > 50).OrderByDescending(person => person.Name).Select(person => (person.Name, person.Weight)).First();//.ToString();

            //Console.WriteLine($"Name: {personName}, Weight {perosnWeight} ");

            //(string name, int weight) = (from person in people
            //                             where person.Name.Length == 4
            //                             orderby
            //                           person.Name,
            //                           person.Weight, person.Height
            //                             select (person.Name, person.Weight)).First();




        }

        static void PrintList(List<Person> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"Name: {item.Name}, Weight: {item.Weight}");
            }
        }

    }
}