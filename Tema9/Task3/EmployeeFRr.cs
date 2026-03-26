using System.Collections.Generic;
using System.IO;

namespace PracticeTasks;

class EmployeeFileReader
{
    public List<Employee> ReadEmployees()
    {
        List<Employee> list = [];

        string[] lines = File.ReadAllLines("file.data");

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            list.Add(new Employee
            {
                Name = parts[0],
                Department = parts[1],
                Salary = double.Parse(parts[2])
            });
        }

        return list;
    }
}