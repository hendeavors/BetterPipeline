using System;
namespace BetterPipeline
{
    public interface IPipelineBuilder<T>
    {
        IPipelineBuilder<T> Pipe(IStage<T> stage);

        IPipelineBuilder<T> Register(IStage<T> stage);

        IPipelineBuilder<T> Pipe(Pipeline<T> p);
    }
}