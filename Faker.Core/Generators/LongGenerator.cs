using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class LongGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return context.Random.NextInt64(long.MinValue, long.MaxValue);
    }

    public Type GeneratedType => typeof(long);
}