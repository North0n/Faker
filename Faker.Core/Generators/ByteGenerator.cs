using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class ByteGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (byte)context.Random.Next(byte.MaxValue + 1);
    }

    public Type GeneratedType => typeof(byte);
}