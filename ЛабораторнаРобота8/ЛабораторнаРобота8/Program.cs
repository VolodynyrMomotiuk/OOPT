using System;

// Абстрактний клас, що представляє базовий курс
public abstract class Course
{
    public abstract string GetDescription();
}

// Конкретний клас курсу
public class BasicCourse : Course
{
    public override string GetDescription()
    {
        return "Базовий курс";
    }
}

// Базовий декоратор
public abstract class CourseDecorator : Course
{
    protected Course _course;

    public CourseDecorator(Course course)
    {
        _course = course;
    }

    public override string GetDescription()
    {
        return _course.GetDescription();
    }
}

// Декоратор, що додає можливість завантаження матеріалів курсу
public class MaterialsDecorator : CourseDecorator
{
    public MaterialsDecorator(Course course) : base(course)
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", з можливістю завантаження матеріалів";
    }
}

// Декоратор, що додає можливість виконувати завдання курсу
public class AssignmentsDecorator : CourseDecorator
{
    public AssignmentsDecorator(Course course) : base(course)
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", з можливістю виконання завдань";
    }
}

// Декоратор, що додає можливість спілкування з викладачами
public class CommunicationDecorator : CourseDecorator
{
    public CommunicationDecorator(Course course) : base(course)
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", з можливістю спілкування з викладачами";
    }
}

// Цільовий інтерфейс для доступу до курсів
public interface ICourse
{
    void Start();
    void SubmitAssignment(string assignment);
    void CommunicateWithInstructor(string message);
}

// Адаптований клас для типу курсу "OnlineCourse"
public class OnlineCourse
{
    public void LaunchCourse()
    {
        Console.WriteLine("Launching online course...");
    }

    public void SubmitTask(string task)
    {
        Console.WriteLine("Submitting task: " + task);
    }

    public void ContactInstructor(string message)
    {
        Console.WriteLine("Sending message to instructor: " + message);
    }
}

// Адаптер для типу курсу "OnlineCourse"
public class OnlineCourseAdapter : ICourse
{
    private OnlineCourse onlineCourse;

    public OnlineCourseAdapter(OnlineCourse course)
    {
        onlineCourse = course;
    }

    public void Start()
    {
        onlineCourse.LaunchCourse();
    }

    public void SubmitAssignment(string assignment)
    {
        onlineCourse.SubmitTask(assignment);
    }

    public void CommunicateWithInstructor(string message)
    {
        onlineCourse.ContactInstructor(message);
    }
}

// Приклад використання
public class Program
{
    static void Main(string[] args)
    {
        // Створюємо базовий курс
        Course basicCourse = new BasicCourse();

        // Додаємо до нього декоратори
        Course decoratedCourse = new MaterialsDecorator(new AssignmentsDecorator(new CommunicationDecorator(basicCourse)));

        // Виводимо опис курсу
        Console.WriteLine(decoratedCourse.GetDescription());

        // Створення інстанції адаптованого класу
        OnlineCourse onlineCourse = new OnlineCourse();

        // Створення адаптера
        ICourse courseAdapter = new OnlineCourseAdapter(onlineCourse);

        // Використання адаптера для доступу до курсу
        courseAdapter.Start();
        courseAdapter.SubmitAssignment("Adapter pattern assignment");
        courseAdapter.CommunicateWithInstructor("Need help with the assignment");
    }
}
