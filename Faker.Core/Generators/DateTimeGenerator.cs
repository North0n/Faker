using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class DateTimeGenerator : IValueGenerator
{
    public static readonly DateTime MinValue = new DateTime(1900, 1, 1, 0, 0, 0, 0);
    public static readonly DateTime MaxValue = new DateTime(2100, 1, 1, 0, 0, 0, 0);

    public object Generate(Type type, GeneratorContext context)
    {
        var range = (MaxValue - MinValue).TotalSeconds;
        return MinValue.AddSeconds(context.Random.NextDouble() * range);
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(DateTime);
    }
}