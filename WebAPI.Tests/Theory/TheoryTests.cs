using System.Collections.Generic;
using Xunit;
using System.Linq;
using WebAPI.Tests.Theory.TestData;

namespace WebAPI.Tests.Theory
{
    public class TheoryTests
    {
        #region InlineData
        // With theory we can pass data to a test
        // [InlineData], [MemberData] or [ClassData]
        // Use Inline Data when you dont want to share data among tests
        // Usually used for simple test scenarios
        [Theory]
        [InlineData(true, "Demo message1")]
        [InlineData(true, "Demo message2")]
        [InlineData(true, "Some message3")]
        public void TestWithInlineData(bool expectedValue, string message)
        {
            Assert.True(expectedValue, message);
        } 
        #endregion

        #region MemberData
        [Theory]
        //[MemberData(nameof(TestDataFromProperty))] // Get Data from a Property or a Method
        [MemberData(nameof(TestDataFromMethod), 2)] // we can even pass parameters to the test method
        public void TestWithMemberData(string expectedName, bool expectedValue)
        {
            string[] names = new string[] { "Anish", "Jiya", "Jeeba" };
            Assert.True(names.Contains(expectedName) == expectedValue);
        }

        // Property has to be static and should return an  IEnumerable<object[]>
        public static IEnumerable<object[]> TestDataFromProperty
        {
            get
            {
                return new List<object[]>
                {
                   new object[] { "Anish", true },
                   new object[]  { "Jiya", true },
                   new object[] { "Jeeba", true},
                   new object[] { "sasi", false},

                };
            }
        }

        // Take is a variable whose value is passed from the MemberData attribute
        public static IEnumerable<object[]> TestDataFromMethod(int take)
        {
            return new List<object[]>
                {
                   new object[] { "Anish", true },
                   new object[]  { "Jiya", true },
                   new object[] { "Jeeba", true},
                   new object[] { "sasi", false},

                }.Take(take);
        }
        #endregion

        #region ClassData
        // In this case we get the data from another class
        [Theory]
        [ClassData(typeof(MockData))] // we can even pass parameters to the test method
        public void TestWithClassData(string expectedName, bool expectedValue)
        {
            string[] names = new string[] { "Anish", "Jiya", "Jeeba" };
            Assert.True(names.Contains(expectedName) == expectedValue);
        }
        #endregion

        #region TheoryData
        // pass strongly typed types instead of object[]
        #endregion
    }
}
