using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class FloatGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return (float)((context.Random.NextSingle() - 0.5) * float.MaxValue);
    }

    public Type GeneratedType => typeof(float);
}