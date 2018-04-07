using System;
using System.Threading.Tasks;

namespace BetterPipeline
{
    public class AsynchronousPipelineRunner<T> : TaskPipeline<T>, ITaskPipeline<T>
    {
        public override async Task<T> Process(T input)
        {
            T result = default(T);

            foreach (var p in GetStages())
            {
                result = await p.Execute(input);
            }

            return result;
        }
    }
}
