using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class FloatGenerator : IValueGenerator
{
    private static readonly Type[] AllowedTypes =
    {
        typeof(float), typeof(double), typeof(decimal)
    };
    
    public object Generate(Type type, GeneratorContext context)
    {
        return (context.Random.NextDouble() - 0.5) * double.MaxValue;
    }

    public bool CanGenerate(Type type)
    {
        return AllowedTypes.Contains(type);
    }
}