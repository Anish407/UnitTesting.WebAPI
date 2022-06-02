using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using UnitTesting.WebAPI.Model;

namespace WebAPI.Tests.HttpClientTests.DummyHandlers
{
    public class StudentDummyMessageHandler : HttpMessageHandler
    {

        public StudentDummyMessageHandler(string studentName) => StudentName = studentName;

        private string StudentName { get; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Student student = new Student
            {
                Name = StudentName,
                Address = "mvlk",
                Age = 33
            };

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(student)),
            });
        }
    }
}
