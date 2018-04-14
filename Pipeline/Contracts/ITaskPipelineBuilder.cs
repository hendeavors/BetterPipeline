using System;
namespace BetterPipeline
{
    public interface ITaskPipelineBuilder<T>
    {
        ITaskPipelineBuilder<T> Pipe(ITaskStage<T> stage);

        ITaskPipelineBuilder<T> Register(ITaskStage<T> stage);

        ITaskPipelineBuilder<T> Pipe(TaskPipeline<T> p);
    }
}
