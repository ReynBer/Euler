using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Euler.Common.Tests
{
    public class Problem1Test
    {
        [Fact]
        public void Check()
            => Assert.Equal(23, new Problems.Problem_0001(9).Run().Result);
    }
}
