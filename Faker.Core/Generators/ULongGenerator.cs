using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class ULongGenerator : IValueGenerator
{
    public object Generate(Type type, GeneratorContext context)
    {
        return (ulong)context.Random.NextInt64();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(ulong);   
    }
}