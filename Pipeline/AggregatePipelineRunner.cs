using System;
using System.Collections.Generic;

namespace BetterPipeline
{
    public class AggregatePipelineRunner<T>: Pipeline<T>
    {
        public AggregatePipelineRunner()
        {
        }

        /// <summary>
        /// Process the specified input using the
        /// result from each stage in the pipeline.
        /// </summary>
        /// <returns>The process.</returns>
        /// <param name="input">Input.</param>
        public override T Process(T input)
        {
            T result = input;

            foreach (IStage<T> stage in stages)
            {
                result = stage.Execute(result);
            }

            return result;
        }
    }
}
