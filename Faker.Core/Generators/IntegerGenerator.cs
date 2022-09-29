using System.Numerics;
using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class IntegerGenerator : IValueGenerator
{
    public object Generate(Type type, GeneratorContext context)
    {
        return context.Random.Next(int.MinValue, int.MaxValue);
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(int);   
    }
};