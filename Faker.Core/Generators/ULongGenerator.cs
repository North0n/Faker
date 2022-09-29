using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class ULongGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (ulong)context.Random.NextInt64();
    }

    public Type GeneratedType => typeof(ulong);
}