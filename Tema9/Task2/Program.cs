using System.Collections.Generic;

namespace PracticeTasks;

class Program
{
    static void Main()
    {
        List<Employee> employees =
        [
            new Employee
            {
                Name = "Ilya",
                Department = "IT",
                Salary = 3000
            },
            new Employee
            {
                Name = "Nikita",
                Department = "HR",
                Salary = 2500
            }
        ];

        EmployeeFileWriter writer = new();
        writer.WriteEmployees(employees, '|');
    }
}