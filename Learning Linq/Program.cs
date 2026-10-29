using System;

using System.Collections.Generic;

using System.Linq;

namespace LinQLearning
{

    class LinqLearning
    {

        public static void PrintList<T>(List<T> list, string seperator = ", ")
        {
            Console.WriteLine(string.Join(seperator, list));
        }


        internal class Warrior
        {
            public int Height { get; set; }
        }

        public static int[] StringToIntArray(string[] list)
        {
            int[] numbers = list.Select(value => int.Parse(value)).OrderBy(value => value).ToArray();

            return numbers;

        }


        public static int[] SplitStringToNumber(string value)
        {
            int[] result = value.Split(" ").OrderByDescending(value => value).Select(value => int.Parse(value)).Where(value => value > 4).ToArray();

            return result;

        }

        static void Main()
        {

            string sentence = "I love cats";
            string[] catnames = { "Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki", "Oscar" };
            int[] numbers = { 5, 6, 3, 2, 1, 5, 6, 7, 8, 4, 234, 54, 14, 653, 3, 5, 6, 7 };
            string[] stringOfNumbers = { "5", "6", "3", "2" };
            string stringWithNumbers = "1 2 7 4 8 3 8 2";


            int[] stringToNumbers = StringToIntArray(stringOfNumbers);

            PrintList(stringToNumbers.ToList(), "//");

            List<int> numbersFromString = SplitStringToNumber(stringWithNumbers).ToList();

            PrintList(numbersFromString);


            var getTheNumbers = (from number in numbers where number > 1 orderby number select number * 2).ToList();

            var firstSelect = (from number in numbers where number > 1 orderby number select number * 2);
            var secondSelect = (from number in numbers where number > 1 orderby number descending select number);


            var oddNumbers = numbers.Where(numbers => (numbers % 2 == 1)).Select(numbers => numbers * 2);

            PrintList(oddNumbers.ToList());

            oddNumbers = numbers.Where(numbers => (numbers % 2 == 1)).Select(numbers => numbers);

            PrintList(oddNumbers.ToList());


            List<Warrior> warrior = new List<Warrior>()
            {
                new Warrior() {Height = 100},
                new Warrior() {Height = 80},
                new Warrior() {Height = 100},
                new Warrior() {Height = 70}
            };

            List<int> shortWarriors = warrior.Where(w => w.Height < 100).OrderBy(w => w.Height).Select(w => w.Height).ToList();
            List<Warrior> shortWarriorsObject = warrior.Where(w => w.Height <= 100).OrderBy(w => w.Height).Select(w => w).ToList();


            //shortWarriors.ForEach(wa => Console.WriteLine(wa));

            shortWarriorsObject.ForEach(war => Console.WriteLine(war.Height));

            //PrintList(shortWarriors, " -- ");



            // PrintList((numbers.Where(numbers => numbers % 2 == 0).Select(numbers => numbers)).ToList());

            List<IEnumerable<int>> selects = new();

            selects.Add(firstSelect);
            selects.Add(secondSelect);

            foreach (var item in selects)
            {
                PrintList(item.ToList());
            }




            //List<int> filtered = new();

            //foreach (var number in numbers)
            //{
            //    if (number < 5) filtered.Add(number);
            //}

            //var se = (from s in sentence select s).ToList();

            //var name = (from n in catnames where n.Contains("i") where n.ToLower().Contains("s")  select n).ToList();

            //var catsWithA = (from cat in catnames where (cat.ToLower().Contains("a")) && (cat.Length >= 5) 
            //                 orderby cat
            //                 select cat).ToList();

            //PrintList(se);
            //PrintList(name);
            //PrintList(catsWithA);



            //PrintList(getTheNumbers);
            //PrintList(filtered);
            //filtered = getTheNumbers;
            //PrintList(filtered);


        }

    }

}