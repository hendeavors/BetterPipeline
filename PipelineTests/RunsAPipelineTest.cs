using System;
using Xunit;
using BetterPipeline;
using System.Threading.Tasks;

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

        [Fact]
        public async void CanRunAnAsynchronousPipeline()
        {
            TaskPipeline<int> pipeline = new AsynchronousConcretePipeline();

            pipeline.Pipe(new AsynchronousConcreteStage())
                    .Pipe(new AsynchronousConcreteStageTwo());

            await pipeline.Process(0);
        }

        public partial class AsynchronousConcretePipeline : TaskPipeline<int>
        {
            public async override Task<int> Process(int input)
            {
                int result = 0;

                foreach (var p in GetStages())
                {
                    result = await p.Execute(input);
                }

                return result;
            }
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

        public partial class AsynchronousConcreteStage : ITaskStage<int>
        {
            public Task<int> Execute(int input)
            {
                return Task.FromResult(2);
            }
        }

        public partial class AsynchronousConcreteStageTwo : ITaskStage<int>
        {
            public Task<int> Execute(int input)
            {
                return Task.FromResult(1);
            }
        }
    }
}
