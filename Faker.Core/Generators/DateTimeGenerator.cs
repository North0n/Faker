using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class DateTimeGenerator : IValueGenerator
{
    public DateTime MinValue { get; set; } = new(1900, 1, 1, 0, 0, 0, 0);
    public DateTime MaxValue { get; set; } = new(2100, 1, 1, 0, 0, 0, 0);

    public object Generate(Type type, GeneratorContext context)
    {
        return MinValue.AddSeconds(context.Random.NextDouble() * (MaxValue - MinValue).TotalSeconds);
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(DateTime);
    }
}