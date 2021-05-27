using System;
using Xunit;

namespace GameOfLife.Domain.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var c = new EmptyClass();
            Assert.NotNull(c);
        }
    }
}