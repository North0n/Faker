using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class ShortGenerator : IValueGenerator
{
    public object Generate(Type type, GeneratorContext context)
    {
        return (short)context.Random.Next(short.MinValue, short.MaxValue + 1);
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(short);   
    }
}