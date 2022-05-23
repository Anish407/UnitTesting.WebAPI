using System.Threading;
using Xunit;

namespace WebAPI.Tests.Sharing_and_reusing_contexts
{
    public class ConstructorAndDisposeMethod
    {
        public ConstructorAndDisposeMethod()
        {
            // write Arrange code here. So for every test a new instance will be generated and the instance will not be shared.
            // do this when you dont want data to be shared between the tests.. 
            Thread.Sleep(3000);

            // each unit test will take 3 secs to complete
            // Dont write code that is time consuming inside here when following this approach
        }


        [Fact]
        public void Testmethod1()
        {
            Assert.True(true, "Return this message");
        }    
        
        [Fact]
        public void Testmethod2()
        {
            Assert.True(true, "Return this message");
        } 
        
        [Fact]
        public void Testmethod3()
        {
            Assert.True(true, "Return this message");
        }
    }
}
