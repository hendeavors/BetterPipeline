using System;
using System.Collections.Generic;

namespace BetterPipeline
{
    public interface IPipelineBuilder<T>
    {
        IPipelineBuilder<T> Pipe(IStage<T> stage);

        IPipelineBuilder<T> Register(IStage<T> stage);

        IPipelineBuilder<T> Pipe(IPipelineBuilder<T> p);

        IList<IStage<T>> GetStages();
    }
}