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
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //DONE  Print the Sum and Average of numbers

            var sumNum = numbers.Sum();
            var avgNum = numbers.Average();
            Console.WriteLine($"Sum: {sumNum}");
            Console.WriteLine($"Average: {avgNum}");
            Console.WriteLine("---------------------");


            //Order numbers in ascending order and decsending order. Print each to console.

            var numAsc = numbers.OrderBy(num => num);
            Console.WriteLine("---------------------");
            Console.WriteLine("Ascending");
            foreach (var num in numAsc)
            {
                Console.WriteLine(num);
            }


            var numDesc = numbers.OrderByDescending(num => num);
            Console.WriteLine("---------------------");
            Console.WriteLine("Descending");
            foreach (var num in numDesc)
            {
                Console.WriteLine(num);
            }


            //DONE  Print to the console only the numbers greater than 6

            var bigSix = numbers.Where(numX => numX > 6);
            Console.WriteLine("---------------------");
            Console.WriteLine("Greater than 6");
            foreach (var numX in bigSix)
            {
                Console.WriteLine(numX);
            }
            Console.WriteLine("---------------------");
            //DONE  Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("First 4 Ascending");
            foreach (var num in numAsc.Take(4))
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("---------------------");

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("With my age:");
            numbers[4] = 42;
            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------");


            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //DONE  Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //DONE  Order this in acesnding order by FirstName.
            var filtered = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);
            Console.WriteLine("C or S Employees:");
            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine("---------------------");

            //DONE Print all the employees' FullName and Age who are over the age 26 to the console.
            //DONE Order this by Age first and then by FirstName in the same result.

            var overTwentySix = employees.Where(person => person.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName);
            Console.WriteLine("Over 26:");
            foreach (var item in overTwentySix)
            {
                Console.WriteLine($"Age:  {item.Age}  Full Name: {item.FullName} ");
            }
            Console.WriteLine("---------------------");
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("YOE Sum and Avg");
            var yoeEmployees = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35);
            
            var sumOfYOE = yoeEmployees.Sum(emp => emp.YearsOfExperience);
            var avgOfYOE = yoeEmployees.Average(emp => emp.YearsOfExperience);

            Console.WriteLine($"Sum {sumOfYOE}  Avg {avgOfYOE}");
            Console.WriteLine("---------------------");
            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Jim-Bob", "Cooter", 98, 1)).ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.Age}");
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
