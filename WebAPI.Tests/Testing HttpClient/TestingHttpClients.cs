using System.Net.Http;
using System.Threading.Tasks;
using UnitTesting.WebAPI.HttpClients;
using UnitTesting.WebAPI.Model;
using WebAPI.Tests.HttpClientTests.DummyHandlers;
using Xunit;

namespace WebAPI.Tests.HttpClientTests
{
    public class TestingHttpClients
    {

        // Create a message handler and pass it to the HttpClient
        // This will return the httpReponse defined in the handler and will not make an Http Call
        [Fact]
        public async Task TestHttpClient()
        {
            // Arrange
            string studentName = "Anish";
            string expectedAddress = "mvlk";
            int expectedAge = 33;
            StudentDummyMessageHandler messageHandler = new StudentDummyMessageHandler(studentName);
            StudentsClient studentsClient = new StudentsClient(new HttpClient(messageHandler));
            
            // Act
            Student student = await studentsClient.GetStudentByName(studentName);

            // Assert
            Assert.Equal(student.Name, studentName);
            Assert.Equal(student.Address, expectedAddress, ignoreCase: true);
            Assert.True(student.Age == expectedAge);
        }
    }
}
