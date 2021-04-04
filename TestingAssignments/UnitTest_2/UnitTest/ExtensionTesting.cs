using System;
using UnitTest_2;
using Xunit;

namespace UnitTest
{
    public class ExtensionTesting
    {
        #region Convert ToUpper
        [Fact]
        public void ConvertToUpper_with_lowercase_input()
        {
            // Arrange
            string a = "input";
            // Act
            string result = a.ConvertToUpper();
            // Assert
            Assert.Equal("INPUT", result);
        }
        [Fact]
        public void ConvertToUpper_with_uppercase_input()
        {
            // Arrange
            string a = "INPUT";
            // Act
            string result = a.ConvertToUpper();
            // Assert
            Assert.Equal("INPUT", result);
        }

        [Fact]
        public void ConvertToUpper_with_mix_input()
        {
            // Arrange
            string a = "iNpuT";
            // Act
            string result = a.ConvertToUpper();
            // Assert
            Assert.Equal("INPUT", result);
        }
        #endregion

        #region Covert ToLower
        [Fact]
        public void ConvertToLower_with_uppercase_input()
        {
            // Arrange
            string a = "INPUT";
            // Act
            string result = a.ConvertToLower();
            // Assert
            Assert.Equal("input", result);
        }
        [Fact]
        public void ConvertToLower_with_lowercase_input()
        {
            // Arrange
            string a = "input";
            // Act
            string result = a.ConvertToLower();
            // Assert
            Assert.Equal("input", result);
        }

        [Fact]
        public void ConvertToLower_with_mix_input()
        {
            // Arrange
            string a = "iNpUt";
            // Act
            string result = a.ConvertToLower();
            // Assert
            Assert.Equal("input", result);
        }
        #endregion

        #region Convert To TitleCase
        [Fact]
        public void ConvertToTitleCase_with_lowercase_input()
        {
            // Arrange
            string a = "this is a demo";
            // Act
            string result = a.ConvertToTitleCase();
            // Assert
            Assert.Equal("This Is A Demo", result);
        }
        [Fact]
        public void ConvertToTitleCase_with_uppercase_input()
        {
            // Arrange
            string a = "THIS IS A DEMO";
            // Act
            string result = a.ConvertToTitleCase();
            // Assert
            Assert.NotEqual("This Is A demo", result);
        }

        [Fact]
        public void ConvertToTitleCase_with_mix_input()
        {
            // Arrange
            string a = "This Is A DemO";
            // Act
            string result = a.ConvertToTitleCase();
            // Assert
            Assert.NotEqual("This Is A demo", result);
        }
        #endregion

        #region Find if string is in LowerCase
        [Fact]
        public void IsLower_with_lowercase_input()
        {
            // Arrange
            string a = "input";
            // Act
            bool result = a.IsLower();
            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsLower_uppercase_input()
        {
            // Arrange
            string a = "INPUT";
            // Act
            bool result = a.IsLower();
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsLower_mix_input()
        {
            // Arrange
            string a = "InPuT";
            // Act
            bool result = a.IsLower();
            // Assert
            Assert.False(result);
        }
        #endregion

        #region Find if string is in UpperCase
        [Fact]
        public void IsUpper_with_uppercase_input()
        {
            // Arrange
            string a = "INPUT";
            // Act
            bool result = a.IsUpper();
            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsUpper_with_mixcase_input()
        {
            // Arrange
            string a = "iNpUt";
            // Act
            bool result = a.IsUpper();
            // Assert
            Assert.False(result);
        }
        [Fact]
        public void IsUpper_with_lowercase_input()
        {
            // Arrange
            string a = "input";
            // Act
            bool result = a.IsUpper();
            // Assert
            Assert.False(result);
        }
        #endregion

        #region Convert First Letter To Capitalize
        [Fact]
        public void ConvertToCapitalize_with_lowercase_input()
        {
            // Arrange
            string a = "input";
            // Act
            string result = a.ConvertToCapitalize();
            // Assert
            Assert.Equal("Input", result);
        }
        [Fact]
        public void ConvertToCapitalize_with_uppercase_input()
        {
            // Arrange
            string a = "INPUT";
            // Act
            string result = a.ConvertToCapitalize();
            // Assert
            Assert.NotEqual("Input", result);
        }

        [Fact]
        public void ConvertToCapitalize_with_mix_input()
        {
            // Arrange
            string a = "InPuT";
            // Act
            string result = a.ConvertToCapitalize();
            // Assert
            Assert.NotEqual("Input", result);
        }
        #endregion

        #region Counting Words
        [Fact]
        public void CountingTotalWord_with_lowercase_input()
        {
            // Arrange
            string a = "this is a demo";
            // Act
            int result = a.CountingWord();
            // Assert
            Assert.Equal(4, result);
        }
        [Fact]
        public void CountingTotalWord_with_wrong_expected_output()
        {
            // Arrange
            string a = "this is a demo";
            // Act
            int result = a.CountingWord();
            // Assert
            Assert.NotEqual(1, result);
        }
        #endregion

        #region Remove Last Character
        [Fact]
        public void RemoveLastCharacterFrom_with_valid_expected_output()
        {
            // Arrange
            string a = "input";
            // Act
            string result = a.RemoveLastCharacterFrom();
            // Assert
            Assert.Equal("inpu", result);
        }
        [Fact]
        public void RemoveLastCharacterFrom_with_invalid_expected_output()
        {
            // Arrange
            string a = "input";
            // Act
            string result = a.RemoveLastCharacterFrom();
            // Assert
            Assert.NotEqual("inp", result);
        }
        #endregion

        #region Check Valid Numeric From String Input
        [Fact]
        public void IsValidNumeric_with_valid_input()
        {
            // Arrange
            string a = "2021";
            // Act
            bool result = a.IsValidNumeric();
            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsValidNumeric_with_invalid_input()
        {
            // Arrange
            string a = "2021H";
            // Act
            bool result = a.IsValidNumeric();
            // Assert
            Assert.False(result);
        }
        #endregion

        #region Convert String To Number
        [Fact]
        public void ConvertStringToNumber_with_valid_input()
        {
            // Arrange
            string a = "2012";
            // Act
            int? result = a.ConvertStringToNumber();
            // Assert
            Assert.Equal(2012, result);
        }
        [Fact]
        public void ConvertStringToNumber_with_invalid_input()
        {
            // Arrange
            string a = "2012H";
            // Act
            int? result = a.ConvertStringToNumber();
            // Assert
            Assert.Null(result);
        }
        #endregion
    }
}
