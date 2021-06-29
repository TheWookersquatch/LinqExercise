using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine(numbers.Sum());
            Console.WriteLine("");
            Console.WriteLine(numbers.Average());
            Console.WriteLine("");
            //Order numbers in ascending order and decsending order. Print each to console.
            var ascending = numbers.OrderBy(n => n);
            foreach (var num in ascending)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("");
            var descending = numbers.OrderByDescending(n => n);
            foreach (var num in descending)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("");
            //Print to the console only the numbers greater than 6
            var greater = numbers.Where(n => n > 6);
            foreach (var n in greater)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("");
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var only4 = ascending.Take(4);
            foreach (var n in only4)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("");
            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 31;
 
             var change4 = numbers.OrderByDescending(n => n);
            foreach(var num in change4)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("");

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();
            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var fullName = employees.Where(n => n.FirstName.StartsWith("C") || n.FirstName.StartsWith("S")).OrderBy(n => n.FirstName);
            foreach (var name in fullName)
            {
                Console.WriteLine(name.FullName);
            }
            Console.WriteLine(" ");


            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var nameAndAge = employees.Where(n => n.Age > 26).OrderBy(n => n.Age).ThenBy(n => n.FirstName);
            foreach (var name in nameAndAge)
            {
                Console.WriteLine($"{name.FullName}   {name.Age}");
            }
            Console.WriteLine(" ");
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var sumAndAve = employees.Where(n => n.Age > 35 && n.YearsOfExperience <= 10);
            
            Console.WriteLine($"{sumAndAve.Sum(n => n.YearsOfExperience)}");
            Console.WriteLine($"{sumAndAve.Average(n => n.YearsOfExperience)}");
            Console.WriteLine(" ");
            //Add an employee to the end of the list without using employees.Add()
           var added = employees.Append(new Employee("Bob", "Wardo", 183, 596));
            foreach (var name in added)
            {
                if (name == added.Last())
                {
                    Console.WriteLine($"{name.FullName} is {name.Age} and has {name.YearsOfExperience} years experience.");
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
