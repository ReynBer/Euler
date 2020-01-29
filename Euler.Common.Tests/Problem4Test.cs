using Euler.Problems;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Euler.Common.Tests
{
    public class Problem4Test
    {
        [Fact]
        public void CheckPalyndrom()
            => Assert.True("non".IsPalyndrom());

        [Fact]
        public void Check()
            => Assert.Equal(9009, new Problem_0004(2).Run().Result);
    }
}
