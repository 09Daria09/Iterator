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
        Console.WriteLine("1. Экскурсия (500 грн, 1 час)");
        Console.WriteLine("2. Навигатор (100 грн, 1.5 часа)");
        Console.WriteLine("3. Самостоятельно (2 часа)");

        int choice = int.Parse(Console.ReadLine());

        IEnumerable route;
        double time;

        switch (choice)
        {
            case 1:
                route = new GuidedTour();
                if (budget < 500)
                {
                    Console.WriteLine("Недостаточно средств для выбора экскурсии.");
                    return;
                }
                time = 1;
                break;
            case 2:
                route = new Navigator();
                if (budget < 100)
                {
                    Console.WriteLine("Недостаточно средств для выбора навигатора.");
                    return;
                }
                time = 1.5;
                break;
            case 3:
                route = new SelfGuided();
                if (budget < 0)
                {
                    Console.WriteLine("Недостаточно средств для самостоятельного похода.");
                    return;
                }
                time = 2;
                break;
            default:
                Console.WriteLine("Выбор не распознан.");
                return;
        }

        Console.WriteLine("Маршрут:");

        foreach (var location in route)
        {
            Console.WriteLine(location);
        }

        Console.WriteLine($"Время затраченное на поход: {time} часов.");

        if (budget < 0)
        {
            Console.WriteLine("Недостаточно средств для завершения похода.");
            return;
        }

        Console.WriteLine($"Оставшийся бюджет: {budget} грн.");
        Console.WriteLine("Ура, вы достигли Колизея!");
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