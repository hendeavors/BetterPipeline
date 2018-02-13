using System;
using System.Threading.Tasks;
using BetterPipeline;
using Xunit;

namespace PipelineTests
{
    public class RunsAPipelineExecutionTest
    {
        public RunsAPipelineExecutionTest()
        {
        }

        [Fact]
        public void PipelineRunnerResultTest()
        {
            PipelineRunner<int> pipeline = new PipelineRunner<int>();

            pipeline.Register(new ConcreteStage())
                    .Register(new ConcreteStageTwo());

            Assert.Equal(2,pipeline.Process(1));
        }

        [Fact]
        public void AggregatePipelineRunnerResultTest()
        {
            AggregatePipelineRunner<int> pipeline = new AggregatePipelineRunner<int>();

            pipeline.Register(new ConcreteStage())
                    .Register(new ConcreteStageTwo());

            Assert.Equal(3, pipeline.Process(1));
        }

        public partial class ConcreteStage : IStage<int>
        {
            public int Execute(int input)
            {
                int result = input + 1;

                return result;
            }
        }

        public partial class ConcreteStageTwo : IStage<int>
        {
            public int Execute(int input)
            {
                return input + 1;
            }
        }
    }
}
