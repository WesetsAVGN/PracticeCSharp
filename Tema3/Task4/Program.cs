using System;

class Company
{
    public Employee[] Employees { get; set; }

    public Employee[] HighPay()
    {
        double max = Employees[0].Salary;

        foreach (Employee emp in Employees)
        {
            if (emp.Salary > max)
            {
                max = emp.Salary;
            }
        }

        int cnt = 0;

        foreach (Employee emp in Employees)
        {
            if (emp.Salary == max)
            {
                cnt++;
            }
        }

        Employee[] result = new Employee[cnt];
        int index = 0;

        foreach (Employee emp in Employees)
        {
            if (emp.Salary == max)
            {
                result[index] = emp;
                index++;
            }
        }

        return result;
    }

    public Employee[] EmpPos(
        string position)
    {
        int cnt = 0;

        foreach (Employee emp in Employees)
        {
            if (emp.HasPosition(position))
            {
                cnt++;
            }
        }

        Employee[] result = new Employee[cnt];
        int index = 0;

        foreach (Employee emp in Employees)
        {
            if (emp.HasPosition(position))
            {
                result[index] = emp;
                index++;
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        Company company = new()
        {
            Employees =
            [
                new Employee
                {
                    Name = "Ivan",
                    Position = "Dev",
                    Salary = 3000
                },
                new Employee
                {
                    Name = "Anna",
                    Position = "Dev",
                    Salary = 5000
                },
                new Employee
                {
                    Name = "Oleg",
                    Position = "HR",
                    Salary = 5000
                }
            ]
        };

        Employee[] top = company.HighPay();
        Console.WriteLine("Макс зарплата:");

        foreach (Employee e in top)
        {
            Console.WriteLine(e.Name);
        }

        Employee[] devs = company.EmpPos("Dev");
        Console.WriteLine("Разработчики:");

        foreach (Employee e in devs)
        {
            Console.WriteLine(e.Name);
        }
    }
}