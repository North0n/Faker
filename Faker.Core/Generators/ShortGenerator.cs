using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class ShortGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (short)context.Random.Next(short.MinValue, short.MaxValue + 1);
    }

    public Type GeneratedType => typeof(short);
}