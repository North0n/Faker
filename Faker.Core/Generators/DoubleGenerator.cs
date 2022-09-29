using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class DoubleGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (context.Random.NextDouble() - 0.5) * double.MaxValue;
    }

    public Type GeneratedType => typeof(double);
}