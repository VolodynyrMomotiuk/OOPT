using System;
using System.Collections;
using System.Collections.Generic;

// Клас, що представляє курс на платформі
public class Course
{
    public string Title { get; set; }
    public string Description { get; set; }
    // Додайте інші властивості, які вам потрібні для курсу
}

// Інтерфейс Ітератора, який описує методи, що повинні бути реалізовані
public interface ICourseIterator
{
    Course First();
    Course Next();
    bool IsDone();
    Course CurrentItem();
}

// Клас, що представляє колекцію курсів
public class CourseCollection : IEnumerable<Course>
{
    private List<Course> courses = new List<Course>();

    public void AddCourse(Course course)
    {
        courses.Add(course);
    }

    public IEnumerator<Course> GetEnumerator()
    {
        return new CourseIterator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Реалізація Ітератора
    private class CourseIterator : IEnumerator<Course>
    {
        private CourseCollection collection;
        private int currentIndex;

        public CourseIterator(CourseCollection collection)
        {
            this.collection = collection;
            currentIndex = -1;
        }

        public Course Current => collection.courses[currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            // Відсутня реалізація, так як не потрібна для даного прикладу
        }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < collection.courses.Count;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}

// Приклад використання патерну Ітератор
public class Program
{
    public static void Main(string[] args)
    {
        // Створюємо платформу для навчання
        CourseCollection courseCollection = new CourseCollection();

        // Додаємо курси
        courseCollection.AddCourse(new Course { Title = "Курс програмування", Description = "Навчіться програмувати в C#" });
        courseCollection.AddCourse(new Course { Title = "Курс веб-розробки", Description = "Навчіться створювати веб-сайти" });
        courseCollection.AddCourse(new Course { Title = "Курс баз даних", Description = "Основи роботи з базами даних" });

        // Використання Ітератора для перебору курсів
        IEnumerator<Course> iterator = courseCollection.GetEnumerator();
        while (iterator.MoveNext())
        {
            Course course = iterator.Current;
            Console.WriteLine($"Назва курсу: {course.Title}");
            Console.WriteLine($"Опис: {course.Description}");
            Console.WriteLine("--------------------");
        }
    }
}
