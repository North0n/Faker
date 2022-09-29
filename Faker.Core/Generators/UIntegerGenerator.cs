using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class UIntegerGenerator : IValueGenerator
{
    public object Generate(Type type, GeneratorContext context)
    {
        return (uint)context.Random.Next();
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(uint);   
    }
}