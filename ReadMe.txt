 1. Naming Unit Tests
 
 public void NameOftheTestMethod_FunctionalityWeTest_ExpectedOutput()
        {

        }

2.  Types
     a. Unit testing means testing the smallest Unit in the code. We dont test the database or any external calls.
     b. Integration means testing between 2 or more components. 
     c. Functional testing means to test the overall functionality, ex: from request to response

3. Fact is a test which is always true.. We just test for conditions
   Theory is a test which is only true for a particular set of data. We can pass parameters
     a. [InlineData] -> pass data Inline
     b. [MemberData] -> pass data from methods or properties
     c. [ClassData]  -> pass data from another class

4. We should only test the code we write.