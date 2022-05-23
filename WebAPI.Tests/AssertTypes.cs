using System;
using System.Collections.Generic;
using UnitTesting.WebAPI.Model;
using Xunit;

namespace WebAPI.Tests
{
    public class AssertTypes
    {
        [Fact]
        public void BooleanAsserts_HaveTypes_ReturnTrue()
        {
            Assert.True(true);
            Assert.False(false);
            Assert.True(true, "Return this message");
        }

        [Fact]
        public void StringAsserts_HaveTypes_ReturnTrue()
        {
            string name = "Anish Aravind";

            Assert.Equal(expected: "Anish Aravind", name);
            Assert.NotEqual(expected: "Anish1 Aravind", name);
            Assert.Equal(expected: "ANISH Aravind", name, ignoreCase: true);
            Assert.StartsWith("ANISH", name, StringComparison.CurrentCultureIgnoreCase);
            Assert.Contains("ANISH", name, StringComparison.CurrentCultureIgnoreCase);
        }

        [Fact]
        public void IntAsserts_HaveTypes_ReturnTrue()
        {
            int value = 100;
            Assert.True(value <= 100);
            Assert.InRange(value, 50, 150);
        }
        [Fact]
        public void CollectionAsserts_HaveTypes_ReturnTrue()
        {
            Student student = new Student { Name = "Anish" };
            IEnumerable<Student> students = new List<Student>()
            {
                student,
                new Student{  Name ="Jiya"},
                new Student{  Name ="Jeeba"}
            };
            //checks if  instances are same 
            Assert.Contains(student, students);
            Assert.Contains(students, s => s.Name == "Anish");
        }
    }
}
