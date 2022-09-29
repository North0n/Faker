using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class BoolGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return context.Random.Next(0, 2) == 0;
    }

    public Type GeneratedType => typeof(bool);
}