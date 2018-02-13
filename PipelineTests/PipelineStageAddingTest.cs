using System;
using BetterPipeline;
using Xunit;

namespace PipelineTests
{
    public class PipelineStageAddingTest
    {
        public PipelineStageAddingTest(){}

        [Fact]
        public void CanPipeStage()
        {
            var cp = new ConcretePipeline();
            cp.Pipe(new ConcreteStage());
        }

        [Fact]
        public void CanRegisterStage()
        {
            var cp = new ConcretePipeline();
            cp.Register(new ConcreteStage());
        }

        [Fact]
        public void CanAddMultipleStagesChaining()
        {
            var cp = new ConcretePipeline();
            cp.Register(new ConcreteStage())
              .Register(new ConcreteStageTwo());
        }

        public partial class ConcretePipeline : Pipeline<int>
        {
            public override int Process(int input)
            {
                int result = 0;

                foreach(var p in GetStages())
                {
                    result = p.Execute(input);
                }

                return result;
            }
        }

        public partial class ConcreteStage : IStage<int>
        {
            public int Execute(int input)
            {
                throw new NotImplementedException();
            }
        }

        public partial class ConcreteStageTwo : IStage<int>
        {
            public int Execute(int input)
            {
                return 0;
            }
        }
    }
}
