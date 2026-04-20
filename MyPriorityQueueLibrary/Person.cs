using MyPriorityQueueLibrary;
namespace MyPriorityQueueLibrary;


public class Person : IComparable<Person>
{
    public string? Name { get; set; }
    public byte Age { get; set; }
    public Person(byte age)
    {
        Age = age; 
    }
    public int CompareTo(Person? other)
        => Age.CompareTo(other?.Age);
}
