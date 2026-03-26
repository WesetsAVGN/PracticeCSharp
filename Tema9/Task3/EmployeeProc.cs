using System.Collections.Generic;

namespace PracticeTasks;

class EmployeeProcessor
{
    public List<Employee> FindByDepartment(List<Employee> employees, string department)
    {
        List<Employee> result = [];

        foreach (Employee e in employees)
        {
            if (e.Department == department)
            {
                result.Add(e);
            }
        }

        return result;
    }
}