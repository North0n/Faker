using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class DoubleGenerator : IValueGenerator
{
    public object Generate(Type type, GeneratorContext context)
    {
        return (context.Random.NextDouble() - 0.5) * double.MaxValue;
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(double);
    }
}