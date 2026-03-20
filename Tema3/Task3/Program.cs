using System;

abstract class Person
{
    public string FullName { get; set; }
    public int Age { get; set; }
}

sealed class Student : Person
{
    public double AvgScore { get; set; }
}

sealed class Teacher : Person
{
    public string Subject { get; set; }
}

class University
{
    public Person[] People { get; set; }
    public Student BestStud()
    {
        Student best = null;

        foreach (Person p in People)
        {
            if (p is Student s)
            {
                if (best == null ||
                    s.AvgScore > best.AvgScore)
                {
                    best = s;
                }
            }
        }

        return best;
    }

    public Teacher[] ByAge(int age)
    {
        int count = 0;

        foreach (Person p in People)
        {
            if ((p is Teacher t) && (t.Age > age))
            {
                count++;
            }
        }

        Teacher[] result = new Teacher[count];
        int index = 0;

        foreach (Person p in People)
        {
            if ((p is Teacher t) && (t.Age > age))
            {
                result[index] = t;
                index++;
            }
        }

        return result;
    }
}

class Task3_University
{
    static void Main()
    {
        University uni = new()
        {
            People =
            [
                new Student
                {
                    FullName = "Ivan",
                    Age = 20,
                    AvgScore = 9.5
                },
                new Student
                {
                    FullName = "Anna",
                    Age = 21,
                    AvgScore = 8.2
                },
                new Teacher
                {
                    FullName = "Dr.Smith",
                    Age = 45,
                    Subject = "Math"
                },
                new Teacher
                {
                    FullName = "Dr.Epstein",
                    Age = 67,
                    Subject = "Science"
                }
            ]
        };

        Student best = uni.BestStud();

        Console.WriteLine($"Лучший студент: {best.FullName}");
        Console.WriteLine($"Укажите возсраст");
        int n = Convert.ToInt32(Console.ReadLine());

        Teacher[] teachers = uni.ByAge(n);

        Console.WriteLine("Выше указанного возраста");
        foreach (Teacher t in teachers)
        {
            Console.WriteLine(t.FullName);
        }
    }
}