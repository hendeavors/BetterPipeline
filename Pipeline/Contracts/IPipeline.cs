using System;
using System.Threading.Tasks;

namespace BetterPipeline
{
    public interface IPipeline<T> : IPipelineBuilder<T>, IProcessPipeline<T>
    {
    }
}
