using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class CharGenerator : IValueGenerator
{
    public object Generate(Type type, GeneratorContext context)
    {
        return (char)context.Random.Next(char.MinValue, char.MaxValue + 1);
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(char);
    }
}