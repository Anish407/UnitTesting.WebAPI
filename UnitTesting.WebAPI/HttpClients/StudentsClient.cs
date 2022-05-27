using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using UnitTesting.WebAPI.Model;

namespace UnitTesting.WebAPI.HttpClients
{
    public class StudentsClient
    {
        public StudentsClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; }

        public async Task<Student> GetStudentByName(string Name, CancellationToken cancellationToken = default)
        {

            HttpRequestMessage? request = new HttpRequestMessage(
                   HttpMethod.Get,
                   "https://localhost:7219/api/movies");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            using (var response = await HttpClient.SendAsync(request,
               HttpCompletionOption.ResponseHeadersRead,
               cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();

                if (stream == null)
                {
                    throw new ArgumentNullException(nameof(stream));
                }

                if (!stream.CanRead)
                {
                    throw new NotSupportedException("Can't read from this stream.");
                }

                using (var streamReader = new StreamReader(stream))
                {
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        var jsonSerializer = new JsonSerializer();
                        return jsonSerializer.Deserialize<Student>(jsonTextReader);
                    }
                }
            }
        }
    }
}
