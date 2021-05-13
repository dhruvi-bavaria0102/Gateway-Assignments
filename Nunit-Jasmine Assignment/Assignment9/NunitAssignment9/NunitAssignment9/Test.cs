using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using System.Linq;

namespace NunitAssignment9
{
    public class Tests
    {
        private Values values;
        [SetUp]
        public void Setup()
        {
            // 1. Create moq object
            var valueMoq = new Mock<Values>();

            // 2. Setup the returnables
            valueMoq
            .Setup(o => o.GetValues())
            .Returns(new List<Values>() {
            new Values {
                Id = 1001,
                Name = "Ms. Dhruvi",
                Address = "Ankleshwar"
            }
            });

            // 3. Assign to Object when needed
            values = valueMoq.Object;
        }

        [Test]
        public void CustomConstrainTest_To_Check_Capitalize_String()
        {
            // Act
            string value = "Dhruvi";

            // Assert
            Assert.That("Dhruvi", Is.IsCapitalize(value));
        }
        [Test]
        public void CustomConstrainTest_To_Check_Title_Case_String_For_Lower_case()
        {
            // Act
            string value = "dhruvi";

            // Assert
            Assert.That("Dhruvi", Is.IsCapitalize(value));
        }
        [Test]
        public void CustomConstrainTest_To_Check_Title_Case_String_For_Upper_Case()
        {
            // Act
            string value = "DHRUVI";

            // Assert
            Assert.That("Dhruvi", Is.IsCapitalize(value));
        }
        [Test]
        public void CustomConstrainTest_For_Check_Title_Case_String_With_Many_Word_Positive()
        {
            // Act
            string value = "Dhruvi bavaria";

            // Assert
            Assert.That("Dhruvi Bavaria", Is.IsCapitalize(value));
        }
        [Test]
        public void CustomConstrainTest_For_Check_Title_Case_String_With_Many_Word_Negative()
        {
            // Act
            string value = "Dhruvi Bavaria";

            // Assert
            Assert.AreNotEqual("Dhruvi bavaria", Is.IsCapitalize(value));
        }

        [Test]
        public void TestCase_For_Count_The_No_Of_List_Positive()
        {
            // Assert 
            Assert.True(values.GetValues().Count() == 1);
        }
        [Test]
        public void TestCase_For_Count_The_No_Of_List_Negative()
        {
            // Assert 
            Assert.False(values.GetValues().Count() == 0);
        }
    }
}