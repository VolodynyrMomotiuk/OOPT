// Базовий інтерфейс елемента мови, який може бути інтерпретований
public interface IExpression
{
    void Interpret(Context context);
}

// Конкретний клас елемента мови - вираз для виконання математичних операцій
public class MathExpression : IExpression
{
    private string expression;

    public MathExpression(string expression)
    {
        this.expression = expression;
    }

    public void Interpret(Context context)
    {
        // Інтерпретація виразу для виконання математичної операції
        // Виконання операції та збереження результату в контексті
        int result = PerformMathOperation(expression);
        context.SetVariable("result", result);
    }

    private int PerformMathOperation(string expression)
    {
        // Логіка виконання математичної операції
        // Приклад: розбиття виразу на операнди та оператор, обчислення та повернення результату
        return 42; // Повернення фіктивного значення для прикладу
    }
}

// Клас контексту, що зберігає стан інтерпретації та результати
public class Context
{
    private Dictionary<string, object> variables;

    public Context()
    {
        variables = new Dictionary<string, object>();
    }

    public void SetVariable(string name, object value)
    {
        variables[name] = value;
    }

    public object GetVariable(string name)
    {
        return variables[name];
    }
}

// Клас інтерпретатора, що виконує інтерпретацію коду
public class Interpreter
{
    private List<IExpression> expressions;

    public Interpreter()
    {
        expressions = new List<IExpression>();
    }

    public void AddExpression(IExpression expression)
    {
        expressions.Add(expression);
    }

    public void Interpret(Context context)
    {
        foreach (var expression in expressions)
        {
            expression.Interpret(context);
        }
    }
}

// Приклад використання патерну Інтерпретатор у контексті платформи для онлайн-освіти
public class OnlineEducationPlatform
{
    public static void Main()
    {
        // Створення контексту
        Context context = new Context();

        // Створення виразу для виконання математичної операції
        IExpression mathExpression = new MathExpression("2 + 2");

        // Створення інтерпретатора та додавання виразу
        Interpreter interpreter = new Interpreter();
        interpreter.AddExpression(mathExpression);

        // Виконання інтерпретації
        interpreter.Interpret(context);

        // Отримання результату
        int result = (int)context.GetVariable("result");
        Console.WriteLine("Result: " + result); // Виведе: Result: 42
    }
}
