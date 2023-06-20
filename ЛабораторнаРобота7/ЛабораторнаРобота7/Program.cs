// Клас, який представляє курс
class Course
{
    public string Title { get; set; }
    public string Content { get; set; }

    // Метод, який повертає об'єкт Memento для збереження стану курсу
    public CourseMemento Save()
    {
        return new CourseMemento(Title, Content);
    }

    // Метод, який відновлює стан курсу з об'єкта Memento
    public void Restore(CourseMemento memento)
    {
        Title = memento.Title;
        Content = memento.Content;
    }
}

// Клас, який представляє об'єкт Memento
class CourseMemento
{
    public string Title { get; }
    public string Content { get; }

    public CourseMemento(string title, string content)
    {
        Title = title;
        Content = content;
    }
}

// Клас, який відповідає за збереження та відновлення стану курсу
class CourseCareTaker
{
    private CourseMemento _memento;

    public CourseMemento Memento
    {
        get { return _memento; }
        set { _memento = value; }
    }
}

// Приклад використання
class Program
{
    static void Main(string[] args)
    {
        // Створення курсу
        Course course = new Course();
        course.Title = "Основи програмування";
        course.Content = "Уроки про основи програмування";

        // Збереження стану курсу
        CourseCareTaker careTaker = new CourseCareTaker();
        careTaker.Memento = course.Save();

        // Зміна стану курсу
        course.Title = "Продовження програмування";
        course.Content = "Уроки про продовження програмування";

        // Відновлення стану курсу
        course.Restore(careTaker.Memento);

        // Виведення інформації про курс після відновлення
        Console.WriteLine("Після відновлення:");
        Console.WriteLine("Назва курсу: " + course.Title);
        Console.WriteLine("Зміст курсу: " + course.Content);
    }
}
