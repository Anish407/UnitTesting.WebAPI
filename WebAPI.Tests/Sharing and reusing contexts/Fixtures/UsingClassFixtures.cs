using System.Threading.Tasks;
using WebAPI.Tests.Sharing_and_reusing_contexts.Fixtures;
using Xunit;

namespace WebAPI.Tests.Sharing_and_reusing_contexts
{
    public class UsingClassFixtures: IClassFixture<TestFixture>
    {
        public TestFixture  TestFixture { get; set; }

        public UsingClassFixtures(TestFixture testFixture)
        {
            TestFixture = testFixture;
        }


        [Fact]
        public async  Task UsingClassFixtures_StudentRepository_ReturnsString()
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
        
        [Fact]
        public async Task UsingClassFixtures_SubjectRepository_ReturnsString5()
        {
            // arrange
            SubjectsRepository studentRepository = TestFixture.SubjectsRepository;
            string expectedSubjectName = "Azure";

            // Act
            string subjectName = await studentRepository.GetSubjectNames();

            // Assert
            Assert.Equal(expectedSubjectName, subjectName);
        }
        
        [Fact]
        public async Task UsingClassFixtures_SubjectRepository_ReturnsString2()
        {
            // arrange
            SubjectsRepository studentRepository = TestFixture.SubjectsRepository;
            string expectedSubjectName = "Azure";

            // Act
            string subjectName = await studentRepository.GetSubjectNames();

            // Assert
            Assert.Equal(expectedSubjectName, subjectName);
        }
        
        [Fact]
        public async Task UsingClassFixtures_SubjectRepository_ReturnsString3()
        {
            // arrange
            SubjectsRepository studentRepository = TestFixture.SubjectsRepository;
            string expectedSubjectName = "Azure";

            // Act
            string subjectName = await studentRepository.GetSubjectNames();

            // Assert
            Assert.Equal(expectedSubjectName, subjectName);
        }
        
        [Fact]
        public async Task UsingClassFixtures_SubjectRepository_ReturnsString4()
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
