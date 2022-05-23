using System.Threading.Tasks;
using Xunit;

namespace WebAPI.Tests.Sharing_and_reusing_contexts.ClassFixtureWithDI
{
    public class UnitTestingWithDI : IClassFixture<FixtureWIthDependencyInjection>
    {
        public FixtureWIthDependencyInjection TestFixture { get; set; }

        public UnitTestingWithDI(FixtureWIthDependencyInjection fixtureWIthDependencyInjection)
        {
            TestFixture = fixtureWIthDependencyInjection;
        }

        [Fact]
        // Type is the name of the trait 
        // WithDi is the value for the trait
        // In Test explorer we can group based on the traits
        [Trait("Type","WithDi")]
        public async Task UsingClassFixtures_StudentRepository_ReturnsString()
        {
            // arrange
            StudentRepository studentRepository = TestFixture.StudentRepository;
            string expectedStudentName = "Anish";

            // Act
            string studentName = await studentRepository.GetStudentsNames();

            // Assert
            Assert.Equal(expectedStudentName, studentName);
        }

        [Fact]
        [Trait("Type", "WithDi")]
        public async Task UsingClassFixtures_SubjectRepository_ReturnsString()
        {
            // arrange
            SubjectsRepository studentRepository = TestFixture.SubjectsRepository;
            string expectedSubjectName = "Azure";

            // Act
            string subjectName = await studentRepository.GetSubjectNames();

            // Assert
            Assert.Equal(expectedSubjectName, subjectName);
        }

        [Fact(Skip =" this message should be used to show the reason for skipping the test")]
        [Trait("Type", "WithDi")]
        public async Task UsingClassFixtures_SubjectRepository_SkipThisTest()
        {
            // arrange
            SubjectsRepository studentRepository = TestFixture.SubjectsRepository;
            string expectedSubjectName = "Azure";

            // Act
            string subjectName = await studentRepository.GetSubjectNames();

            // Assert
            Assert.Equal(expectedSubjectName, subjectName);
        }
    }
}
