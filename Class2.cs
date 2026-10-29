using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class Program
{
    static void Main()
    {

        List<Student> allStudents =
        [
            new Student("Sophia", [93, 87, 98, 95, 100]),
            new Student("Nicolas5", [80, 83, 82, 88, 80]),
            new Student("ZahirahZahirahZahira", [84, 96, 73, 85, 79]),
            new Student("Jeong55", [90, 92, 98, 100, 97]),
        ];

        Console.WriteLine("Student\t\t\tGrade\n");

        foreach (Student student in allStudents)
        {
            decimal grade = student.getGrade();

            string score = (grade) switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                _ => "D"
            };

            string studentName = student.Name + ":";

            studentName = studentName.PadRight(23);

            Console.WriteLine($"{studentName}\t{grade}\t{score}");

        }

    }

    public class Student
    {
        public string Name { get; set; }
        public List<int>? grades;

        public Student(string name, List<int> values)
        {
            Name = name;
            grades = [.. values];
        }

        public decimal getGrade()
        {
            return (decimal)grades.Sum() / grades.Count;
        }
    }

}
