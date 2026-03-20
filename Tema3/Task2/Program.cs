using System;

class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }
}

static class EmployeeOperations
{
    public static Employee[] Generate(int count)
    {
        Random rnd = new();

        Employee[] data = new Employee[count];

        for (var i = 0; i < count; i++)
        {
            data[i] = new Employee
            {
                Name = $"Emp{i}",
                Salary = rnd.Next(1000, 5000)
            };
        }

        return data;
    }
    public static double CalcAvgSal(Employee[] employees)
    {
        double sum = 0;

        foreach (Employee emp in employees)
        {
            sum += emp.Salary;
        }

        return sum / employees.Length;
    }
}

class Program
{
    static void Main()
    {
        Employee[] data = EmployeeOperations.Generate(5);

        double avg = EmployeeOperations.CalcAvgSal(data);

        Console.WriteLine($"Средняя зарплата: {avg:F2}");
    }
}