using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class FloatGenerator : IValueGenerator
{
    public object Generate(Type type, GeneratorContext context)
    {
        return (float)((context.Random.NextSingle() - 0.5) * float.MaxValue);
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(float);   
    }
}