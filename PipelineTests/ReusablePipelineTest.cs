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

            pipelineTwo.Process(0);
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
                return 1;
            }
        }

    }
}
