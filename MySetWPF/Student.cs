namespace MySetWPF;

public class Student : IComparable<Student>
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }

    public Student(int studentId, string name, Gender gender)
    {
        StudentId = studentId;
        Name = name;
        Gender = gender;
    }

    public int CompareTo(Student? other)
    {
        return StudentId.CompareTo(other.StudentId);
    }
}
