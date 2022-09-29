using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class UShortGenerator : IValueGenerator
{
    public object Generate(Type type, GeneratorContext context)
    {
        return (ushort)context.Random.Next(ushort.MaxValue + 1);
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(ushort);   
    }
}