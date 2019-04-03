using System;
using Xunit;
using BetterPipeline;
using System.Threading.Tasks;

namespace PipelineTests
{
    public class ReusablePipelineTest
    {
        public ReusablePipelineTest()
        {
        }

        [Fact]
        public void CanRunAPipeline()
        {
            Pipeline<int> pipelineOne = new PipelineRunner<int>();

            pipelineOne.Pipe(new ConcreteStage())
                       .Pipe(new ConcreteStageTwo())
                       .Pipe(new ConcreteStage());

            Pipeline<int> pipelineTwo = new PipelineRunner<int>();

            pipelineTwo.Pipe(new ConcreteStage())
                       .Pipe(pipelineOne);

            var result = pipelineTwo.Process(0);

            Assert.Equal(result, 1);
        }

        [Fact]
        public void PipelineRunnerContainsExpectedResult()
        {
            Pipeline<int> pipelineOne = new PipelineRunner<int>();

            pipelineOne.Pipe(new ConcreteStage())
                       .Pipe(new ConcreteStageTwo())
                       .Pipe(new ConcreteStage());

            Pipeline<int> pipelineTwo = new PipelineRunner<int>();

            pipelineTwo.Pipe(new ConcreteStage())
                       .Pipe(pipelineOne);

            var result = pipelineTwo.Process(0);

            Assert.Equal(result, 1);
        }

        [Fact]
        public void AggregatePipelineRunnerContainsExpectedResult()
        {
            Pipeline<int> pipelineOne = new AggregatePipelineRunner<int>();

            pipelineOne.Pipe(new ConcreteStage())
                       .Pipe(new ConcreteStageTwo())
                       .Pipe(new ConcreteStage());

            Pipeline<int> pipelineTwo = new AggregatePipelineRunner<int>();

            pipelineTwo.Pipe(new ConcreteStage())
                       .Pipe(pipelineOne);

            var result = pipelineTwo.Process(0);

            Assert.Equal(result, 4);
        }

        public class ConcreteStage : IStage<int>
        {
            public int Execute(int input)
            {
                int result = input + 1;

                return result;
            }
        }

        public class ConcreteStageTwo : IStage<int>
        {
            public int Execute(int input)
            {
                return input + 1;
            }
        }

    }
}
