namespace Faker.Interfaces;

public interface IFaker
{
    public T Create<T>();
}