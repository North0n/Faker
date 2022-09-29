using System.Collections;
using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Generators;

public class ListGenerator : IValueGenerator
{
    public int MinListSize { get; set; } = 1;
    public int MaxListSize { get; set; } = 10;
    
    public object Generate(Type type, GeneratorContext context)
    {
        var listType = typeof(List<>).MakeGenericType(type.GenericTypeArguments[0]);
        var list = (IList)Activator.CreateInstance(listType)!;
        
        var size = context.Random.Next(MinListSize, MaxListSize + 1);
        var elementType = type.GetGenericArguments()[0];
        for (var i = 0; i < size; i++)
        {
            list.Add(context.Faker.Create(elementType));
        }

        return list;
    }
    
    public bool CanGenerate(Type type)
    {
        return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
    }
}