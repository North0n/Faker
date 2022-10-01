using System.Reflection;
using Faker.Entities;
using Faker.Interfaces;

namespace Tests;

public class Tests
{
    IFaker _faker;
    
    [SetUp]
    public void Setup()
    {
        _faker = new Faker.Services.Faker(new Random(11));
    }
    
    [Test]
    public void ValueTypes()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_faker.Create<byte>(), Is.Not.EqualTo(default(sbyte)));
            Assert.That(_faker.Create<short>(), Is.Not.EqualTo(default(short)));
            Assert.That(_faker.Create<int>(), Is.Not.EqualTo(default(int)));
            Assert.That(_faker.Create<long>(), Is.Not.EqualTo(default(long)));
            
            Assert.That(_faker.Create<byte>(), Is.Not.EqualTo(default(byte)));
            Assert.That(_faker.Create<ushort>(), Is.Not.EqualTo(default(ushort)));
            Assert.That(_faker.Create<uint>(), Is.Not.EqualTo(default(uint)));
            Assert.That(_faker.Create<ulong>(), Is.Not.EqualTo(default(ulong)));
            
            Assert.That(_faker.Create<float>(), Is.Not.EqualTo(default(float)));
            Assert.That(_faker.Create<double>(), Is.Not.EqualTo(default(double)));
            
            Assert.That(_faker.Create<decimal>(), Is.Not.EqualTo(default(decimal)));
            Assert.That(_faker.Create<char>(), Is.Not.EqualTo(default(char)));
            Assert.That(_faker.Create<string>(), Is.Not.EqualTo(default(string)));
            Assert.That(_faker.Create<DateTime>(), Is.Not.EqualTo(default(DateTime)));
        });
    }

    struct TestStruct2
    {
        public bool _boolField;
        public DateTime Time { set; get; }
        public Bebra BebraProp { get; set; }
    }
    
    struct TestStruct
    {
        public TestStruct(int count)
        {
            Count = count;
            testStruct2 = new TestStruct2();
        }
        
        public double price = 10;
        private string name = "test";
        public int Count { get; }

        public TestStruct2 testStruct2;
    }
    
    class Bebra
    {
        public int A { get; set; }
        private readonly string _id = "bebra";
        private DateTime _dateTime;
        private TestStruct _struct;
    }

    [Test]
    public void CycleDependencyTest()
    {
        var bebra = _faker.Create<Bebra>();
        
        Assert.That(bebra.A, Is.Not.EqualTo(default(int)));
        var privateStruct = (TestStruct)bebra.GetType()
            .GetField("_struct", BindingFlags.NonPublic | BindingFlags.Instance)!
            .GetValue(bebra)!;
        Assert.That(privateStruct, Is.Not.EqualTo(null));
        Assert.That(privateStruct.testStruct2, Is.Not.EqualTo(null));
        Assert.That(privateStruct.testStruct2.BebraProp, Is.EqualTo(null));
    }

    class CycleList
    {
        public string Name { get; set; }
        public List<CycleList> InnerList { get; set; }
    }
    
    [Test]
    public void ListTest()
    {
        var list = _faker.Create<List<CycleList>>();
        Assert.That(list, Is.Not.EqualTo(default(List<CycleList>)));
        foreach (var innerList in list)
        {
            Assert.That(innerList, Is.Not.EqualTo(null));
            Assert.Multiple(() =>
            {
                Assert.That(innerList.Name, Is.Not.EqualTo(default(string)));
                Assert.That(innerList.InnerList, Is.Not.EqualTo(default(List<CycleList>)));
            });
            foreach (var i in innerList.InnerList)
            {
                Assert.That(i, Is.EqualTo(default(CycleList)));
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
        private int Age {get; set; }
        public string PrevCity;
    }
    
    [Test]
    public void ConfigTest()
    {
        var config = new FakerConfig();
        config.Add<Person, string, CityGenerator>(person => person.City);
        config.Add<Person, string, CityGenerator>(p => p.PrevCity);
        
        var faker = new Faker.Services.Faker(config, new Random(13));
        var person = faker.Create<Person>();
        Assert.Multiple(() =>
        {
            Assert.That(person.Name, Is.Not.EqualTo(default(string)));
            Assert.That(person.City, Is.AnyOf(CityGenerator.Cities));
            Assert.That(person.PrevCity, Is.AnyOf(CityGenerator.Cities));
            Assert.That(
                (int)person.GetType().GetProperty("Age", BindingFlags.Instance | BindingFlags.NonPublic)!
                    .GetValue(person)!,
                Is.Not.EqualTo(default(int)));
        });
    }
}