using System.Collections.Generic;
using System.IO;

namespace PracticeTasks;

class EmployeeFileWriter
{
    public void WriteEmployees(List<Employee> employees, char separator)
    {
        using StreamWriter writer = new("file.data");

        foreach (Employee e in employees)
        {
            writer.WriteLine($"{e.Name}{separator}" + $"{e.Department}{separator}" + $"{e.Salary}");
        }
    }
}