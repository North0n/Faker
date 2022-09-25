using Faker.Entities;

namespace Faker.Interfaces;

public interface IValueGenerator
{
    object Generate(Type type, GeneratorContext context);
    
    bool CanGenerate(Type type);
}