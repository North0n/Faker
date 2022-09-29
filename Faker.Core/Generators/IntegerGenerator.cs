using System.Numerics;
using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class IntegerGenerator : IValueGenerator
{
    public object Generate(GeneratorContext context)
    {
        return context.Random.Next(int.MinValue, int.MaxValue);
    }

    public Type GeneratedType => typeof(int);
};