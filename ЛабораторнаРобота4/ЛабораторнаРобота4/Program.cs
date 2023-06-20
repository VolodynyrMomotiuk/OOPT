using System;
using System.Collections.Generic;

// Клас курсу
public class Course
{
    public string Name { get; }

    public Course(string name)
    {
        Name = name;
    }

    public void Enroll()
    {
        Console.WriteLine("Enrolling in course: " + Name);
    }
}

// Клас завдання
public class Assignment
{
    public string Name { get; }

    public Assignment(string name)
    {
        Name = name;
    }

    public void Submit()
    {
        Console.WriteLine("Submitting assignment: " + Name);
    }
}

// Клас користувача
public class User
{
    public string Name { get; }

    public User(string name)
    {
        Name = name;
    }

    public void SendMessage(string message)
    {
        Console.WriteLine("Sending message to user " + Name + ": " + message);
    }
}

// Базовий клас команди
public abstract class Command
{
    public abstract void Execute();
}

// Конкретна команда для зареєстрування на курс
public class EnrollCourseCommand : Command
{
    private readonly Course course;

    public EnrollCourseCommand(Course course)
    {
        this.course = course;
    }

    public override void Execute()
    {
        course.Enroll();
    }
}

// Конкретна команда для відправки завдання
public class SubmitAssignmentCommand : Command
{
    private readonly Assignment assignment;

    public SubmitAssignmentCommand(Assignment assignment)
    {
        this.assignment = assignment;
    }

    public override void Execute()
    {
        assignment.Submit();
    }
}

// Конкретна команда для відправки повідомлення
public class SendMessageCommand : Command
{
    private readonly User recipient;
    private readonly string message;

    public SendMessageCommand(User recipient, string message)
    {
        this.recipient = recipient;
        this.message = message;
    }

    public override void Execute()
    {
        recipient.SendMessage(message);
    }
}

// Викликач команд
public class Invoker
{
    private readonly List<Command> commands = new List<Command>();

    public void AddCommand(Command command)
    {
        commands.Add(command);
    }

    public void ExecuteCommands()
    {
        foreach (Command command in commands)
        {
            command.Execute();
        }

        commands.Clear();
    }
}

// Приклад використання патерна Макрокоманди
public class Program
{
    public static void Main()
    {
        // Створення об'єктів команд
        Course course = new Course("Programming 101");
        EnrollCourseCommand enrollCommand = new EnrollCourseCommand(course);

        Assignment assignment = new Assignment("Homework 1");
        SubmitAssignmentCommand submitCommand = new SubmitAssignmentCommand(assignment);

        User teacher = new User("John Doe");
        SendMessageCommand messageCommand = new SendMessageCommand(teacher, "Hi, I have a question.");

        // Створення викликача та додавання команд до черги
        Invoker invoker = new Invoker();
        invoker.AddCommand(enrollCommand);
        invoker.AddCommand(submitCommand);
        invoker.AddCommand(messageCommand);

        // Виконання всіх команд
        invoker.ExecuteCommands();
    }
}
