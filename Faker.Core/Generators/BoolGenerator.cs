using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class BoolGenerator : IValueGenerator
{
    public object Generate(Type type, GeneratorContext context)
    {
        return context.Random.Next(0, 2) == 0;
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(bool);
    }
}