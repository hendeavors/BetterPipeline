using System;
using System.Collections.Generic;

namespace BetterPipeline.Builder
{
    /// <summary>
    /// Pipeline builder.
    /// </summary>
    public class PipelineBuilder<T>
    {
        private IStage<T>[] stages;

        private int counter = 0;

        public PipelineBuilder(int capacity)
        {
            stages = new IStage<T>[capacity];
        }

        public PipelineBuilder<T> Add(IStage<T> stage)
        {
            stages[counter] = stage;

            counter++;

            return this;
        }

        public Pipeline<T> build(Pipeline<T> pipeline)
        {
            for (int i = 0; i < counter; i++ )
            {
                pipeline.Register(stages[i]);
            }

            return pipeline;
        }
    }
}
