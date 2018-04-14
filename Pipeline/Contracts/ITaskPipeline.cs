using System;
using System.Threading.Tasks;

namespace BetterPipeline
{
    public interface ITaskPipeline<T> : ITaskPipelineBuilder<T>
    {
        Task<T> Process(T input);
    }
}
