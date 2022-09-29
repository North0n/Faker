using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class UShortGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (ushort)context.Random.Next(ushort.MaxValue + 1);
    }

    public Type GeneratedType => typeof(ushort);
}