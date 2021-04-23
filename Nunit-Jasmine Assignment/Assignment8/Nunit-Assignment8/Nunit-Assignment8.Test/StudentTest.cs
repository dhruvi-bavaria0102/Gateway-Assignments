using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nunit_Assignment8.Test
{
    public class StudentTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [OrderedTest(0)]
        public void TestGetEmployees()
        {
            //Arrange
            int total = 4;

            //Act + Assert
            Assert.That(StudentCRUD.GetStudents(), Has.Count.EqualTo(total)
                        .And.All.Property("Name").Not.Null
                        .And.All.Property("Section").Not.Null);
        }

        [OrderedTest(2)]
        public void TestGetEmployee()
        {
            //Arrange
            int id = 2;
            string name = "student2";
            //Act
            Student actual = StudentCRUD.GetStudent(id);
            //Assert
            Assert.That(actual, Has.Property("Name").EqualTo(name));
        }

        [OrderedTest(3)]
        public void TestGetStudentBySection()
        {
            //Arrange
            string section = "A";
            //Act
            List<Student> actualList = StudentCRUD.GetStudentBySection(section);
            //Assert
            Assert.That(actualList, Has.Count.EqualTo(2)
                                       .And.All.Property("Section").EqualTo("A"));
        }

        [OrderedTest(1)]
        public void TestGetStudentName()
        {
            //Arrange
            int id = 1;
            string name = "student1";
            //Act + Assert
            Assert.That(StudentCRUD.GetStudentName(id), Is.EqualTo(name));
        }
     
        [TestCaseSource(sourceName: "TestSource")]
        public void MainTest(TestStructure test)
        {
            test.Test();
        }
        public static IEnumerable<TestCaseData> TestSource
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                Dictionary<int, List<MethodInfo>> methods = assembly
                .GetTypes()
                .SelectMany(x => x.GetMethods())
                .Where(y => y.GetCustomAttributes().OfType<OrderedTestAttribute>().Any())
                .GroupBy(z => z.GetCustomAttribute<OrderedTestAttribute>().Order)
                .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());
                foreach (var order in methods.Keys.OrderBy(x => x))
                {
                    foreach (var methodInfo in methods[order])
                    {
                        MethodInfo info = methodInfo;
                        yield return new TestCaseData(
                        new TestStructure
                        {
                            Test = () =>
                            {
                                object classInstance = Activator.CreateInstance(info.DeclaringType, null);
                                info.Invoke(classInstance, null);
                            }
                        }).SetName(methodInfo.Name);
                    }
                }
            }
        }
    }
    public class TestStructure
    {
        public Action Test;
    }
    public class OrderedTestAttribute : Attribute
    {
        public int Order { get; set; }
        public OrderedTestAttribute(int order)
        {
            this.Order = order;
        }
    }
}
