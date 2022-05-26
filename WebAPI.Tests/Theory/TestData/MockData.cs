using System.Collections;
using System.Collections.Generic;

namespace WebAPI.Tests.Theory.TestData
{
    public class MockData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Anish", true };
            yield return new object[] { "Jiya", true };
            yield return new object[] { "Jeeba", true };
            yield return new object[] { "sasi", false };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
