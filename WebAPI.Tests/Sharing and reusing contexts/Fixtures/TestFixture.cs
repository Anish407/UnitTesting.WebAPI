using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Tests.Sharing_and_reusing_contexts.Fixtures
{
    // share objects between tests and not create a new instance during the arrange phase.
    // the instance of the TestFixture will eb shared accross all the unit test instances. 
    public class TestFixture
    {
        public StudentRepository StudentRepository { get; set; }
        public SubjectsRepository SubjectsRepository { get; set; }

        public TestFixture()
        {
            // the object of this class  will be shared by all the tests 
            // This constructor will only be called once
            // so if the arrange step is time consuming then we can save time by not instatiating the object 
            // each time the unit test runs
            Thread.Sleep(3000);
            StudentRepository= new StudentRepository();
            SubjectsRepository= new SubjectsRepository();
        }
    }

    public class StudentRepository
    {
         public async Task<string> GetStudentsNames()=> await Task.FromResult("Anish");
    }
    public class SubjectsRepository
    {
        public async Task<string> GetSubjectNames() => await Task.FromResult("Azure");
    }

}
