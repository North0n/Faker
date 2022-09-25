using Faker.Interfaces;

namespace Faker.Entities;

public class GeneratorContext
{
    public IFaker Faker { get; }
    public Random Random { get; }
    
    public GeneratorContext(IFaker faker, Random random)
    {
        Faker = faker;
        Random = random;
    }
}