using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class SByteGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (sbyte)context.Random.Next(sbyte.MinValue, sbyte.MaxValue + 1);
    }

    public Type GeneratedType => typeof(sbyte);
}