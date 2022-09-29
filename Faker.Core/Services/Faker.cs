using System.Reflection;
using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Services;

public class Faker : IFaker
{
    private readonly Dictionary<Type, IValueGenerator> _generators;
    private readonly GeneratorContext _context;
    private readonly HashSet<Type> _typesBeingCreated = new();

    public Faker(Random random)
    {
        _generators = GetGenerators();
        _context = new GeneratorContext(this, random);
    }

    public Faker() : this(new Random())
    {
    }

    private static Dictionary<Type, IValueGenerator> GetGenerators()
    {
        var generators = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
            .Where(t => t.GetInterfaces().Contains(typeof(IValueGenerator)))
            .Select(t => (IValueGenerator)Activator.CreateInstance(t)).ToList();

        return generators.ToDictionary(generator => generator.GeneratedType);
    }

    public T Create<T>()
    {
        return (T)Create(typeof(T));
    }

    public object Create(Type type)
    {
        if (_generators.ContainsKey(type))
        {
            return _generators[type].Generate(_context);
        }

        if (_typesBeingCreated.Contains(type))
            return GetDefaultValue(type);

        _typesBeingCreated.Add(type);
        var obj = CreateComplex(type);
        FillFields(obj);
        _typesBeingCreated.Remove(type);
        return obj;
    }
    
    private object CreateComplex(Type type)
    {
        var constructors = type.GetConstructors().ToList()
            .OrderByDescending(c => c.GetParameters().Length).ToList();
        foreach (var constructor in constructors)
        {
            try
            {
                return constructor.Invoke(constructor.GetParameters().Select(p => Create(p.ParameterType)).ToArray());
            }
            catch (Exception)
            {
                // ignored
            }
        }
        return GetDefaultValue(type);
    }
    
    private void FillFields(object obj)
    {
        var fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var field in fields)
        {
            if (field.IsInitOnly)
            {
                continue;
            }

            var value = Create(field.FieldType);
            field.SetValue(obj, value);
        }
    }
    
    private static object GetDefaultValue(Type t)
    {
        return t.IsValueType ? Activator.CreateInstance(t) : null;
    }
}