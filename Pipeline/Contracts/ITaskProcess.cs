using System;
using System.Threading.Tasks;

namespace BetterPipeline
{
    public interface ITaskProcess<T> : IPipelineBuilder<T>
    {
        Task<T> Process(T input);
    }
}
