using System;
using Xunit;
using BetterPipeline;


namespace PipelineTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(1,1);
        }

        [Fact]
        public void MustBeTrue()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void Things()
        {
            
        }
    }
}
