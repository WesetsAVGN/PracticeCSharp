using System;
class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }
}

class Department
{
    public string Name { get; set; }
}

class Client
{
    public string Name { get; set; }
}

class Company
{

    public Employee[] Employees { get; set; }
    public Department Department { get; set; }
    public Client Client { get; set; }

    public double CalculateTotalSalary()
    {
        double sum = 0;

        foreach (Employee emp in Employees)
        {
            sum += emp.Salary;
        }

        return sum;
    }
}

class Program
{
    static void Main()
    {
        Employee e1 = new() { Name = "Inna", Salary = 3000 };
        Employee e2 = new() { Name = "Alexander", Salary = 4000 };

        Company[] companies =
        [
            new Company
            {
                Employees = [e1, e2],
                Department = new Department { Name = "IT" },
                Client = new Client { Name = "Client_A" }
            }
        ];

        foreach (Company c in companies)
        {
            Console.WriteLine($"Сумма зарплат: {c.CalculateTotalSalary()}");
        }
    }
}