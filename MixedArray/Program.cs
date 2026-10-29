using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqMixedArray
{

    internal interface Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Dog : Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Dog(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    internal class Cat : Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Cat(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }


    public class MixedLinQ
    {

        static public void Main()
        {
            object[] mix = { 1, "string", 'd', new List<int> { 1, 2, 3, 4 }, new List<int> { 5, 2, 3, 4 }, "dd", 's', "Hello Kitty", 1, 2, 3, 4 };

            var integers = (mix.OfType<int>()).ToList();

            var allIntegers = mix.Where(i => i is int).Cast<int>().ToList();

            Console.WriteLine(string.Join(", ", allIntegers));

            List<Animal> animals = new()
            {
                new Dog("Fluffy", 2),
                new Dog ("Wagter", 11),
            
                new Cat("Muffen", 4),
                new Cat ("Flower", 1)
            };

            List<Dog> doggies = animals.Where(a => a is Dog).Cast<Dog>().Where(a => a.Name == "Wagter").
                ToList();

            doggies.ForEach(p => Console.WriteLine(p.Name));

            List<Cat> catty = (from c in animals where c is Cat where (c as Cat).Name == "Flower" select c).Cast<Cat>().ToList();
            
            List<Cat> catty2 = (from c in animals where c is Cat 
                                let t = (c as Cat)
                                where t.Name == "Muffen"
                                where t.Age == 4
                                select c).Cast<Cat>().ToList();

            catty.ForEach(c => Console.WriteLine(c.Name));
            catty2.ForEach(c => Console.WriteLine(c.Name));

            List <Cat> catty3 = animals.OfType<Cat>().Cast<Cat>().Where(c => c.Name == "Muffen" && c.Age == 4 ).ToList() ;

            catty3.ForEach(c => Console.WriteLine($"Cat: {c.Name}, Age: {c.Age}"));
        }








    }














}

































//var innerJoin = (supplier.Join(buyer, s => s.Distict, b => b.Distict,
//                (s, b) => new
//                {
//                    SupplierName = s.Name,
//                    BuyerName = b.Name,
//                    District = s.Distict
//                })).ToList();



//var innerJoinSelect = (from b in buyer
//                       orderby b.Distict
//                       join s in supplier on b.Distict equals s.Distict
//                       select new
//                       {
//                           Supplier = s.Name,
//                           Buyer = b.Name,
//                           District = s.Distict
//                       }).ToList();

