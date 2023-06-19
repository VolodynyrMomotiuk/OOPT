using System;

// Абстрактний клас курсу
abstract class Course
{
    public abstract void Enroll();
}

// Конкретний клас курсу
class MathCourse : Course
{
    public override void Enroll()
    {
        Console.WriteLine("Enrolling in Math course...");
        // Логіка для запису на математичний курс
    }
}

// Конкретний клас курсу
class ScienceCourse : Course
{
    public override void Enroll()
    {
        Console.WriteLine("Enrolling in Science course...");
        // Логіка для запису на науковий курс
    }
}

// Фабричний метод, який визначає створення курсів
abstract class CourseFactory
{
    public abstract Course CreateCourse();
}

// Конкретний фабричний метод для створення математичних курсів
class MathCourseFactory : CourseFactory
{
    public override Course CreateCourse()
    {
        return new MathCourse();
    }
}

// Конкретний фабричний метод для створення наукових курсів
class ScienceCourseFactory : CourseFactory
{
    public override Course CreateCourse()
    {
        return new ScienceCourse();
    }
}

// Клас, який використовує фабричний метод для створення курсів
class OnlineEducationPlatform
{
    private CourseFactory courseFactory;

    public OnlineEducationPlatform(CourseFactory factory)
    {
        courseFactory = factory;
    }

    public void CreateAndEnrollCourse()
    {
        Course course = courseFactory.CreateCourse();
        course.Enroll();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення платформи онлайн-освіти з фабрикою математичних курсів
        CourseFactory mathCourseFactory = new MathCourseFactory();
        OnlineEducationPlatform mathPlatform = new OnlineEducationPlatform(mathCourseFactory);
        mathPlatform.CreateAndEnrollCourse();

        // Створення платформи онлайн-освіти з фабрикою наукових курсів
        CourseFactory scienceCourseFactory = new ScienceCourseFactory();
        OnlineEducationPlatform sciencePlatform = new OnlineEducationPlatform(scienceCourseFactory);
        sciencePlatform.CreateAndEnrollCourse();

        Console.ReadLine();
    }
}
