using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class ByteGenerator : IValueGenerator
{
    public object Generate(Type type, GeneratorContext context)
    {
        return (byte)context.Random.Next(byte.MaxValue + 1);
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(byte);
    }
}