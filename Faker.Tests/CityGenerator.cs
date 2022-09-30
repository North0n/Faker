using Faker.Entities;
using Faker.Interfaces;

namespace Tests;

public class CityGenerator : IValueGenerator
{
    public static string[] Cities => new[] { "Mosty", "Grodno", "Minsk", "Brest", "Vitebsk", "Gomel", "Mogilev" };

    public object Generate(Type type, GeneratorContext context)
    {
        return Cities[context.Random.Next(0, Cities.Length)];
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(string);
    }
}