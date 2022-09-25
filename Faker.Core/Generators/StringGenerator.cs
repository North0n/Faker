using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class StringGenerator : IValueGenerator
{
    private const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public object Generate(Type type, GeneratorContext context)
    {
        var length = context.Random.Next(0, 255);
        var str = new string('\0', length);
        return str.Select(_ => Chars[context.Random.Next(0, Chars.Length)]);
    }

    public bool CanGenerate(Type type)
    {
        return type == typeof(string);
    }
}