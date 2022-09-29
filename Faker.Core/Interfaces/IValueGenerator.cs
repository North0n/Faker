using Faker.Entities;

namespace Faker.Interfaces;

public interface IValueGenerator
{
    object Generate(GeneratorContext context);
    
    Type GeneratedType { get; }
}