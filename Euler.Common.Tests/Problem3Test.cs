using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Euler.Common.Tests
{
    public class Problem3Test
    {
        [Fact]
        public void Check()
            //=> Assert.Equal(29, new Problems.Problem_0003(13195L).Run().Result);
            => Assert.True("non".IsPalyndrom());
    }
}
