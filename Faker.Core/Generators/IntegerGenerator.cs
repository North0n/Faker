using System.Numerics;
using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class IntegerGenerator : IValueGenerator
{
    private static readonly Type[] AllowedTypes =
    {
        typeof(sbyte), typeof(byte), typeof(short), typeof(ushort), typeof(int), typeof(uint),
        typeof(long), typeof(ulong), typeof(BigInteger)
    };

    public object Generate(Type type, GeneratorContext context)
    {
        return context.Random.Next();
    }

    public bool CanGenerate(Type type)
    {
        return AllowedTypes.Contains(type);
    }
}