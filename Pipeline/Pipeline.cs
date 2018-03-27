using System;
using System.Collections.Generic;

namespace BetterPipeline
{
    public abstract class Pipeline<T> : Builder.PipelineBuilder<T>
    {
        /// <summary>
        /// Process the specified input.
        /// </summary>
        /// <returns>The process.</returns>
        /// <param name="input">Input.</param>
        public abstract T Process(T input);

        /// <summary>
        /// Gets the stages.
        /// </summary>
        /// <returns>The stages.</returns>
        public IList<IStage<T>> GetStages()
        {
            return stages;
        }
    }
}
