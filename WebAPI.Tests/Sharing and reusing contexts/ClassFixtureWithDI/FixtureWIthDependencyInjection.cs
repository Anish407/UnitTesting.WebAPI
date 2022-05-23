using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace WebAPI.Tests.Sharing_and_reusing_contexts.ClassFixtureWithDI
{
    public class FixtureWIthDependencyInjection
    {
        public StudentRepository StudentRepository { get; set; }
        public SubjectsRepository SubjectsRepository { get; set; }

        public FixtureWIthDependencyInjection()
        {
            IServiceProvider provider = new ServiceCollection()
                .AddScoped<StudentRepository>()
                .AddScoped<SubjectsRepository>()
                .BuildServiceProvider();

            StudentRepository = provider.GetService<StudentRepository>() ?? throw new Exception($"{nameof(StudentRepository)} is null ");
            SubjectsRepository = provider.GetService<SubjectsRepository>() ?? throw new Exception($"{nameof(SubjectsRepository)} is null ");

        }
    }

    public class StudentRepository
    {
        public async Task<string> GetStudentsNames() => await Task.FromResult("Anish");
    }
    public class SubjectsRepository
    {
        public async Task<string> GetSubjectNames() => await Task.FromResult("Azure");
    }
}

