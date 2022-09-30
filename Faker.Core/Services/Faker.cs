using System.Reflection;
using Faker.Entities;
using Faker.Interfaces;

namespace Faker.Services;

public class Faker : IFaker
{
    private readonly List<IValueGenerator> _generators;
    private readonly GeneratorContext _context;
    private readonly HashSet<Type> _typesBeingCreated = new();
    private readonly FakerConfig _config = null;

    public Faker(FakerConfig config, Random random) : this(random)
    {
        _config = config;
    }
    
    public Faker(Random random)
    {
        _generators = GetGenerators();
        _context = new GeneratorContext(this, random);
    }

    public Faker() : this(new Random())
    {
    }

    private static List<IValueGenerator> GetGenerators()
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IValueGenerator)))
            .Select(t => (IValueGenerator)Activator.CreateInstance(t)).ToList();
    }

    public T Create<T>()
    {
        return (T)Create(typeof(T));
    }

    public object Create(Type type)
    {
        foreach (var generator in _generators)
        {
            if (generator.CanGenerate(type))
            {
                return generator.Generate(type, _context);
            }
        }

        if (_typesBeingCreated.Contains(type))
            return GetDefaultValue(type);

        _typesBeingCreated.Add(type);
        var obj = CreateComplex(type);
        if (obj == null)
        {
            return null;
        }
        FillFields(obj);
        FillProps(obj);
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
                return constructor.Invoke(constructor.GetParameters()
                    .Select(info => GenerateMemberValue(type, info.Name, info.ParameterType)).ToArray());
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

            field.SetValue(obj, GenerateMemberValue(obj.GetType(), field.Name, field.FieldType));
        }
    }

    private void FillProps(object obj)
    {
        var props = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var prop in props)
        {
            if (prop.CanWrite)
            {
                prop.SetValue(obj, GenerateMemberValue(obj.GetType(), prop.Name, prop.PropertyType));
            }
        }
    }

    private object GenerateMemberValue(Type objectType, string memberName, Type memberType)
    {
        if (_config != null && _config.Contains(objectType, memberName))
            return _config.GetGenerator(objectType, memberName).Generate(memberType, _context);
        return Create(memberType);
    }

    private static object GetDefaultValue(Type t)
    {
        return t.IsValueType ? Activator.CreateInstance(t) : null;
    }
}