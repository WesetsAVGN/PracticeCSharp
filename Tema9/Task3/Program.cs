using System;

namespace PracticeTasks;

class Program
{
    static void Main()
    {
        EmployeeFileReader reader = new();
        EmployeeProcessor processor = new();

        var employees = reader.ReadEmployees();

        var result = processor.FindByDepartment(employees, "IT");

        foreach (var e in result)
        {
            Console.WriteLine(e.Name);
        }
    }
}