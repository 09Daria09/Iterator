using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите ваш бюджет:");
        int budget = int.Parse(Console.ReadLine());

        Colosseum colosseum = new Colosseum();

        Console.WriteLine("Как бы вы хотели добраться до Колизея?");
        Console.WriteLine("1. Экскурсия (500 грн)");
        Console.WriteLine("2. Навигатор (100 грн)");
        Console.WriteLine("3. Самостоятельно");

        int choice = int.Parse(Console.ReadLine());

        IEnumerable route;

        switch (choice)
        {
            case 1:
                route = new GuidedTour();
                if (budget < 500)
                {
                    Console.WriteLine("Недостаточно средств для выбора экскурсии.");
                    return;
                }
                budget -= 500;
                break;
            case 2:
                route = new Navigator();
                if (budget < 100)
                {
                    Console.WriteLine("Недостаточно средств для выбора навигатора.");
                    return;
                }
                budget -= 100;
                break;
            case 3:
                route = new SelfGuided();
                break;
            default:
                Console.WriteLine("Неправильный выбор");
                return;
        }

        Console.WriteLine("Ваш бюджет: " + budget);

        foreach (string stop in route)
        {
            Console.WriteLine("Остановка: " + stop);
        }

        colosseum.Visit();
    }
}

class Colosseum
{
    public void Visit()
    {
        Console.WriteLine("Добро пожаловать в Колизей!");
    }
}

class GuidedTour : IEnumerable
{
    private string[] stops = { "Туристическое агентство", "Остановка туристического автобуса", "Касса Колизея" };

    public IEnumerator GetEnumerator()
    {
        foreach (string stop in stops)
        {
            yield return stop;
        }
    }
}

class Navigator : IEnumerable
{
    private string[] stops = { "Отель", "Железнодорожный вокзал", "Колизей" };

    public IEnumerator GetEnumerator()
    {
        foreach (string stop in stops)
        {
            yield return stop;
        }
    }
}

class SelfGuided : IEnumerable
{
    private string[] stops = { "Отель", "Ресторан", "Колизей" };

    public IEnumerator GetEnumerator()
    {
        foreach (string stop in stops)
        {
            yield return stop;
        }
    }
}