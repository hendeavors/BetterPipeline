using System;
using System.Threading.Tasks;

namespace BetterPipeline
{
    public interface ITaskPipeline<T>
    {
        Task<T> Process(T input);

        ITaskPipeline<T> Pipe(ITaskStage<T> stage);

        ITaskPipeline<T> Register(ITaskStage<T> stage);
    }
}
