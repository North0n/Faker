using System.Linq.Expressions;
using Faker.Interfaces;

namespace Faker.Entities;

public class FakerConfig
{
    private readonly Dictionary<Type, Dictionary<string, IValueGenerator>> _generators = new();

    public void Add<TClass, TType, TGenerator>(Expression<Func<TClass, TType>> expression)
        where TGenerator : IValueGenerator
    {
        if (!_generators.ContainsKey(typeof(TClass)))
        {
            _generators.Add(typeof(TClass), new());
        }

        var member = expression.Body as MemberExpression ??
                     throw new ArgumentException("Expression must be a member expression");
        var memberName = member.Member.Name;
        var generator = (IValueGenerator)Activator.CreateInstance(typeof(TGenerator));
        _generators[typeof(TClass)].Add(memberName, generator);
    }

    public bool Contains(Type type, string memberName)
    {
        return _generators.ContainsKey(type) && _generators[type].ContainsKey(memberName);
    }

    public IValueGenerator GetGenerator(Type type, string memberName)
    {
        if (_generators.ContainsKey(type) && _generators[type].ContainsKey(memberName))
        {
            return _generators[type][memberName];
        }

        return null;
    }
}