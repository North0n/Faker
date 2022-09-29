using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class UIntegerGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (uint)context.Random.Next();
    }

    public Type GeneratedType => typeof(uint);
}