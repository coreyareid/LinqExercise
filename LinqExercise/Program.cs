using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        // Exercise 3
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            // Part 1
            Console.WriteLine("----------Sum--------------");
            Console.WriteLine(numbers.Sum());

            Console.WriteLine("-----------Average-------------");
            Console.WriteLine(numbers.Average());

            Console.WriteLine("----------Ascending Order--------------");
            var ascending = numbers.OrderBy(number => number);
            foreach (var number in ascending)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("----------Descending Order--------------");
            var descending = numbers.OrderByDescending(number => number);

            foreach (var number in descending)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("----------Greater Than Six--------------");
            var aboveSix = numbers.Where(number => number > 6);
            foreach (var number in aboveSix)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("-----------Only 4 Descending-------------");
            foreach (var number in descending.Take(4))
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("----------My Age Descending--------------");
            numbers.SetValue(30, 4);
            var myAgeDescending = numbers.OrderByDescending(number => number);
            foreach (var number in myAgeDescending)
            {
                Console.WriteLine(number);
            }

            // Part 2
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            Console.WriteLine("----------Employee In Order Name starts with C or S-----------");
            var  employeeOrderCS= employees.Where(employee => employee.FirstName.ToLower().StartsWith('c') || employee.FirstName.ToLower()[0] == 's')
                            .OrderBy(employee => employee.FirstName);
            foreach (var employee in employeeOrderCS)
            {
                Console.WriteLine(employee.FullName);
            }

            Console.WriteLine("\n----------Employee Ordered By Age-----------");
            var employeeOverTwentySix = employees.Where(employee => employee.Age > 26).OrderByDescending(employee => employee.Age).ThenBy(employee => employee.FirstName);
            foreach (var employee in employeeOverTwentySix)
            {
                Console.WriteLine($" Employee Name: {employee.FirstName} || Employee Age: {employee.Age}");
            }

            Console.WriteLine("\n---Sum and Average with less or equal to ten years and older than 35---");
            var summedExp = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35);
            Console.WriteLine($"Sum years of experience: {summedExp.Sum(employee => employee.YearsOfExperience)}");
            Console.WriteLine($"Average years of experience: {summedExp.Average(employee => employee.YearsOfExperience)}");

            Console.WriteLine("\n------Added my name to the list of employees------");
            employees = employees.Append(new Employee("Corey", "Reid", 30, 0)).ToList();
            var nameInOrder = employees.OrderBy(employee => employee.FirstName).ThenBy(employee => employee.Age);
            foreach (var employee in nameInOrder)
            {
                Console.WriteLine($"Full name: {employee.FullName} | Age {employee.Age} | Experience: {employee.YearsOfExperience}");
            }
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
