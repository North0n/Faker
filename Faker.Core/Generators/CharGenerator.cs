using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class CharGenerator : IValueGenerator
{
    public object Generate(Type type, GeneratorContext context)
    {
        return (char)context.Random.Next(0, 65535);
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(char);
    }
}