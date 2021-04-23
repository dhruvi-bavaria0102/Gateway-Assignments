using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nunit_Assignment8
{
    public static class StudentCRUD
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
        }
        static List<Student> students = new List<Student>()
        {
            new Student(){Id=1,Name="student1",Address="Student1 address", Standard="8th", Section="A"},
            new Student(){Id=2,Name="student2",Address="Student2 address", Standard="9th", Section="A"},
            new Student(){Id=3,Name="student3",Address="Student3 address", Standard="8th", Section="B"},
            new Student(){Id=4,Name="student4",Address="Student4 address", Standard="9th", Section="B"},
        };
        public static List<Student> GetStudents()
        {
            return students;
        }
        public static Student GetStudent(int id)
        {
            Student student = students.Where(x => x.Id == id).FirstOrDefault();
            if (student == null)
                throw new Exception("Employee not Found");
            return student;
        }
        public static List<Student> GetStudentBySection(string section)
        {
            List<Student> student = students.Where(x => x.Section == section).ToList();
            return student;

        }
        public static string GetStudentName(int id)
        {
            Student student = students.Where(x => x.Id == id).FirstOrDefault();
            return student.Name;
        }
        public static int TotalStudent()
        {
            int count;
            count = GetStudents().Count();
            return count;
        }
    }
}
