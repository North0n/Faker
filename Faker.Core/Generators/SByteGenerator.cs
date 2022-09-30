using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class SByteGenerator : IValueGenerator
{
    public object Generate(Type type, GeneratorContext context)
    {
        return (sbyte)context.Random.Next(sbyte.MinValue, sbyte.MaxValue + 1);
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(sbyte);
    }
}