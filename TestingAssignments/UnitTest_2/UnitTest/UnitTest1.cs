using System;
using UnitTest_2;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void ConvertToUpper_with_lowercaseinput()
        {
            string a = "input";
            string result = a.ConvertToUpper();
            Assert.Equal("INPUT", result);
        }
        [Fact]
        public void ConvertToUpper2()
        {
            string a = "input";
            string result = a.ConvertToUpper();
            Assert.NotEqual("Input", result);
        }
        [Fact]
        public void ConvertToLower1()
        {
            string a = "INPUT";
            string result = a.ConvertToLower();
            Assert.Equal("input", result);
        }
        [Fact]
        public void ConvertToLower2()
        {
            string a = "INPUT";
            string result = a.ConvertToLower();
            Assert.NotEqual("Input", result);
        }
        [Fact]
        public void ConvertToTitleCase1()
        {
            string a = "this is a demo";
            string result = a.ConvertToTitleCase();
            Assert.Equal("This Is A Demo", result);
        }
        [Fact]
        public void ConvertToTitleCase2()
        {
            string a = "this is a demo";
            string result = a.ConvertToTitleCase();
            Assert.NotEqual("This Is A demo", result);
        }
        [Fact]
        public void IsLower1()
        {
            string a = "input";
            bool result = a.IsLower();
            Assert.True(result);
        }
        [Fact]
        public void IsLower2()
        {
            string a = "Input";
            bool result = a.IsLower();
            Assert.False(result);
        }
        [Fact]
        public void IsUpper1()
        {
            string a = "INPUT";
            bool result = a.IsUpper();
            Assert.True(result);
        }
        [Fact]
        public void IsUpper2()
        {
            string a = "iNpUt";
            bool result = a.IsUpper();
            Assert.False(result);
        }
        [Fact]
        public void ConvertToCapitalize1()
        {
            string a = "this is a demo";
            string result = a.ConvertToCapitalize();
            Assert.Equal("This is a demo", result);
        }
        [Fact]
        public void ConvertToCapitalize2()
        {
            string a = "this is a demo";
            string result = a.ConvertToCapitalize();
            Assert.NotEqual("This Is A Demo", result);
        }
        [Fact]
        public void CountingTotalWord1()
        {
            string a = "this is a demo";
            int result = a.CountingWord();
            Assert.Equal(4, result);
        }
        [Fact]
        public void CountingTotalWord2()
        {
            string a = "this is a demo";
            int result = a.CountingWord();
            Assert.NotEqual(1, result);
        }
        [Fact]
        public void RemoveLastCharacterFrom1()
        {
            string a = "input";
            string result = a.RemoveLastCharacterFrom();
            Assert.Equal("inpu", result);
        }
        [Fact]
        public void RemoveLastCharacterFrom2()
        {
            string a = "input";
            string result = a.RemoveLastCharacterFrom();
            Assert.NotEqual("inp", result);
        }
        [Fact]
        public void IsValidNumeric1()
        {
            string a = "2012";
            bool result = a.IsValidNumeric();
            Assert.True(result);
        }
        [Fact]
        public void IsValidNumeric2()
        {
            string a = "2012H";
            bool result = a.IsValidNumeric();
            Assert.False(result);
        }
        [Fact]
        public void ConvertStringToNumber1()
        {
            string a = "2012";
            int? result = a.ConvertStringToNumber();
            Assert.Equal(1929, result);
        }
        [Fact]
        public void ConvertStringToNumber2()
        {
            string a = "2012H";
            int? result = a.ConvertStringToNumber();
            Assert.Null(result);
        }
    }
}
