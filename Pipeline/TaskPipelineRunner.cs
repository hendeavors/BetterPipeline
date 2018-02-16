using System;
using System.Threading.Tasks;

namespace BetterPipeline
{
    public class TaskPipelineRunner<K>: MixedPipeline<Task,K>
    {
        private Task[] tasks;

        private int counter = 0;

        public TaskPipelineRunner(int capacity)
        {
            tasks = new Task[capacity];
        }

        public override void Process(K input)
        {
            foreach(IMixedStage<Task,K> s in stages)
            {
                tasks[counter] = s.Execute(input);

                counter++;
            }

            Task.WaitAll(tasks);
        }
    }
}
