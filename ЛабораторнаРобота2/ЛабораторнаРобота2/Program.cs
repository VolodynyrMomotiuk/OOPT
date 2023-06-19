using System;

// Абстрактний клас Прототип
abstract class CoursePrototype
{
    public string Title { get; set; }

    public abstract CoursePrototype Clone();
}

// Конкретний клас Прототипа, який реалізує клонування
class ConcreteCourse : CoursePrototype
{
    public override CoursePrototype Clone()
    {
        return (CoursePrototype)this.MemberwiseClone();
    }
}

// Клас Керівника, який використовує прототипи для створення нових курсів
class CourseManager
{
    private CoursePrototype _coursePrototype;

    public CourseManager(CoursePrototype coursePrototype)
    {
        _coursePrototype = coursePrototype;
    }

    public CoursePrototype CreateCourse()
    {
        return _coursePrototype.Clone();
    }
}

// Приклад використання патерну Прототип
class Program
{
    static void Main(string[] args)
    {
        // Створення початкового курсу
        CoursePrototype initialCourse = new ConcreteCourse();
        initialCourse.Title = "Introduction to Programming";

        // Створення менеджера курсів і клонування початкового курсу
        CourseManager manager = new CourseManager(initialCourse);
        CoursePrototype clonedCourse = manager.CreateCourse();

        // Зміна назви клонованого курсу
        clonedCourse.Title = "Advanced Programming";

        Console.WriteLine("Original course: " + initialCourse.Title);
        Console.WriteLine("Cloned course: " + clonedCourse.Title);
    }
}
