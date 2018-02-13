using System;
using Xunit;
using BetterPipeline;

namespace PipelineTests
{
    public class RunsAPipelineTest
    {
        public RunsAPipelineTest()
        {
        }

        [Fact]
        public void CanRunAPipeline()
        {
            Pipeline<int> pipeline = new PipelineRunner<int>();

            pipeline.Pipe(new ConcreteStage())
                    .Pipe(new ConcreteStageTwo())
                    .Pipe(new ConcreteStage());

            pipeline.Process(0);
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
