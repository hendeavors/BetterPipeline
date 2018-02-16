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
        public void TaskPipelineRunnerTest()
        {
            TaskPipelineRunner<int> p = new TaskPipelineRunner<int>(2);
            p.Pipe(new CreateOrder())
             .Pipe(new ProcessPayment());

            p.Process(0);
        }

        public partial class CreateOrder : IMixedStage<Task,int>
        {
            public Task Execute(int input)
            {
                var factory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
                
                var createOrderTask = factory.StartNew(() =>
                {
                    int sum = 0;
                    for (int i = 0; i < 10000000; i++)
                    {
                        sum += i;
                    }

                    return sum;
                });

                return createOrderTask;
            }
        }

        public partial class ProcessPayment : IMixedStage<Task,int>
        {
            public Task Execute(int input)
            {
                var factory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);

                var processPaymentTask = factory.StartNew(() =>
                {
                    int sum = 0;
                    for (int i = 0; i < 10000000; i++)
                    {
                        sum += i;
                    }

                    return sum;
                });

                return processPaymentTask;
            }
        }
    }
}
