using System;
using System.IO;
using System.Xml.Serialization;

namespace Serializer
    public class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string MiddleName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
}
    public enum Gender 
{ 
    Male,
    Female 
}


    class Program
{
    static void Main()
    {
        Student student = new Student
        {
            ID = 5,
            Name = "Marina",
            MiddleName = "Kovalchyk",
            Age = 19,
            Gender = Gender.Female
        };
        XmlSerializer serializer = new XmlSerializer(typeof(Student));
        using (System.IO.FileStream fs = new FileStream("student.xml", FileMode.OpenOrCreate))
        {
            serializer.Serialize(fs, student);
        }
        using (FileStream fs = new FileStream("student.xml", FileMode.OpenOrCreate))
        {
            var studentDeserialized = (Student)serializer.Deserialize(fs);
            Console.WriteLine(studentDeserialized.Gender);
        }
    }
}

