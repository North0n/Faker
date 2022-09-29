using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class DateTimeGenerator : IValueGenerator
{
    public static readonly DateTime MinValue = new DateTime(1900, 1, 1, 0, 0, 0, 0);
    public static readonly DateTime MaxValue = new DateTime(2100, 1, 1, 0, 0, 0, 0);
    
    private static readonly double Range = (MaxValue - MinValue).TotalSeconds; 

    public object Generate(GeneratorContext context)
    {
        return MinValue.AddSeconds(context.Random.NextDouble() * Range);
    }

    public Type GeneratedType => typeof(DateTime);
}