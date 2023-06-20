using System;
using System.Collections.Generic;

// Інтерфейс стратегії оцінювання
interface IGradingStrategy
{
    int CalculateGrade(List<Answer> answers);
}

// Конкретні реалізації стратегій оцінювання
class SimpleGradingStrategy : IGradingStrategy
{
    public int CalculateGrade(List<Answer> answers)
    {
        // Простий алгоритм оцінювання
        int correctAnswers = 0;
        foreach (Answer answer in answers)
        {
            if (answer.IsCorrect)
                correctAnswers++;
        }
        return (int)Math.Round((double)correctAnswers / answers.Count * 100);
    }
}

class WeightedGradingStrategy : IGradingStrategy
{
    public int CalculateGrade(List<Answer> answers)
    {
        // Алгоритм оцінювання з ваговими коефіцієнтами
        int totalWeight = 0;
        int weightedScore = 0;
        foreach (Answer answer in answers)
        {
            totalWeight += answer.Weight;
            if (answer.IsCorrect)
                weightedScore += answer.Weight;
        }
        return (int)Math.Round((double)weightedScore / totalWeight * 100);
    }
}

// Клас, який представляє завдання
class Question
{
    public string Text { get; set; }
    public List<Answer> Answers { get; set; }
    public IGradingStrategy GradingStrategy { get; set; }

    public int CalculateGrade()
    {
        return GradingStrategy.CalculateGrade(Answers);
    }
}

// Клас, який представляє відповіді студента на завдання
class Answer
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
    public int Weight { get; set; }
}

// Клас, який використовується для демонстрації роботи патерна Стратегія
class Program
{
    static void Main(string[] args)
    {
        // Створення питань та відповідей
        Question question1 = new Question
        {
            Text = "What is the capital of France?",
            Answers = new List<Answer>
            {
                new Answer { Text = "Paris", IsCorrect = true },
                new Answer { Text = "London", IsCorrect = false },
                new Answer { Text = "Berlin", IsCorrect = false }
            },
            GradingStrategy = new SimpleGradingStrategy()
        };

        Question question2 = new Question
        {
            Text = "Who painted the Mona Lisa?",
            Answers = new List<Answer>
            {
                new Answer { Text = "Leonardo da Vinci", IsCorrect = true },
                new Answer { Text = "Pablo Picasso", IsCorrect = false },
                new Answer { Text = "Vincent van Gogh", IsCorrect = false }
            },
            GradingStrategy = new WeightedGradingStrategy()
        };

        // Оцінювання відповідей
        List<Question> questions = new List<Question> { question1, question2 };
        foreach (Question question in questions)
        {
            int grade = question.CalculateGrade();
            Console.WriteLine($"Grade for question: '{question.Text}': {grade}%");
        }

        Console.ReadLine();
    }
}
