 <h2> Naming Unit Tests </h2>
 
 public void NameOftheTestMethod_FunctionalityWeTest_ExpectedOutput() {  }

 <h2>  Types</h2>
 <ul>
 <li> Unit testing means testing the smallest Unit in the code. We dont test the database or any external calls.  </li>
 <li> Integration means testing between 2 or more components. </li>
 <li> Functional testing means to test the overall functionality, ex: from request to response </li>
 </ul>
 
<h2>  Code Samples</h2>
<ul>
 <li>
  <a href="./UnitTesting.WebAPI/WebAPI.Tests/AssertTypes.cs "> Common Assert Types</a>
  
 </li>

<li> Fact is a test which is always true.. We just test for conditions
   Theory is a test which is only true for a particular set of data. We can pass parameters
 <ul>
  <li> [InlineData] -> <a href="./UnitTesting.WebAPI/blob/master/WebAPI.Tests/Theory/TheoryTests.cs#L19"> pass data Inline</a> </li>
   <li> [MemberData]  -> <a href="./UnitTesting.WebAPI/blob/master/WebAPI.Tests/Theory/TheoryTests.cs#L29"> pass data from methods or properties</a> </li>
   <li> [ClassData]  -> <a href="[./UnitTesting.WebAPI/blob/master/WebAPI.Tests/Theory/TheoryTests.cs#L29](https://github.com/Anish407/UnitTesting.WebAPI/blob/master/WebAPI.Tests/Theory/TheoryTests.cs#L69)"> pass data from another class</a> </li>
 </ul>
</li>
<li> We should only test the code we write. </li>

 <li> 
    <a href="./UnitTesting.WebAPI/WebAPI.Tests/Testing Controllers/">Testing Controllers </a> 
 </li>
  <li> 
    <a href="./UnitTesting.WebAPI/WebAPI.Tests/Sharing and reusing contexts/">Sharing and Reusing Contexts</a>  
 </li>
 <li> 
    <a href="./UnitTesting.WebAPI/WebAPI.Tests/Testing HttpClient/">Testing HttpClient</a> 
 </li>
  <li> 
    <a href="./UnitTesting.WebAPI/WebAPI.Tests/Testing HttpContext/">Testing HttpContext</a> 
 </li>
</ul>
