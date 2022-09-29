using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class CharGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (char)context.Random.Next(char.MinValue, char.MaxValue + 1);
    }

    public Type GeneratedType => typeof(char);
}