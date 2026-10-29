using System;

namespace MyApp
{
    public class Students
    {

        public class Student
        {
            public string Name { get; }
            public List<string> courses = ["English 101", "Algebra 101", "Biology 101", "Computer Science I", "Psychology 101"];
            public List<int> courseCredit = [3, 3, 4, 4, 3];

            public List<int> courseGrade = [4, 3, 3, 3, 4];

            public Student(string name)
            {
                Name = name;
            }

        }


        public static void Main()
        {
            Student student = new Student("Sophia Johnson");

            int totalCreditHours = student.courseCredit.Sum();

            int totalGradePoints = 0;

            for (int i = 0; i < student.courseGrade.Count; i++)
            {
                totalGradePoints += student.courseCredit[i] * student.courseGrade[i];
            }

            decimal gradePointAverage = (decimal)totalGradePoints / totalCreditHours;

            Console.WriteLine($"Student: {student.Name}\n");
            Console.WriteLine("Course\t\t\tGrade\tCredit Hours");

            for (int i = 0; i < student.courses.Count; i++)
            {
                Console.WriteLine($"{student.courses[i].PadRight(16)}\t{student.courseGrade[i]}\t\t{student.courseCredit[i]}");
            }

            Console.WriteLine($"Final GPA:\t\t{gradePointAverage:F2}");

        }
    }
}
