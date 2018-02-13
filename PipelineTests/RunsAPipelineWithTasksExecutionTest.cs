using System;
using System.Threading.Tasks;
using BetterPipeline;
using Xunit;

namespace PipelineTests
{
    public class RunsAPipelineWithTasksExecutionTest
    {
        public RunsAPipelineWithTasksExecutionTest()
        {
        }

        [Fact]
        public void AggregatePipelineRunnerTaskResultTest()
        {
            TaskPipelineRunner<int> p = new TaskPipelineRunner<int>(3);
            p.Pipe(new ConcreteStage())
             .Pipe(new ConcreteStage())
             .Pipe(new ConcreteStageTwo());



            p.Process(0);
        }

        public partial class ConcreteStage : IMixedStage<Task,int>
        {
            public Task Execute(int input)
            {
                var f = new TaskFactory(TaskCreationOptions.LongRunning,
                          TaskContinuationOptions.None);



                var loadTask = f.StartNew(() =>
                {
                    int sum = 0;
                    for (int i = 0; i < 10000000; i++)
                    {
                        sum += i;
                    }

                    return sum;
                });



                return loadTask;
            }
        }

        public partial class ConcreteStageTwo : IMixedStage<Task,int>
        {
            public Task Execute(int input)
            {
                var f = new TaskFactory(TaskCreationOptions.LongRunning,
                          TaskContinuationOptions.None);

                var loadTask = f.StartNew(() =>
                {
                    int sum = 0;
                    for (int i = 0; i < 10000000; i++)
                    {
                        sum += i;
                    }

                    return sum;
                });

                return loadTask;
            }
        }
    }
}
