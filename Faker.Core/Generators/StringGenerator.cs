using System.Text;
using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class StringGenerator : IValueGenerator
{
    private const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public object Generate(GeneratorContext context)
    {
        var length = context.Random.Next(0, 255);
        var str = new StringBuilder(length);
        for (var i = 0; i < length; i++)
        {
            str.Append(Chars[context.Random.Next(Chars.Length)]);
        }

        return str.ToString();
    }

    public Type GeneratedType => typeof(string);
}