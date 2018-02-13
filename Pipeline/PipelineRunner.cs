using System;

namespace BetterPipeline
{
    public class PipelineRunner<T> : Pipeline<T>
    {
        public PipelineRunner()
        {
        }

        /// <summary>
        /// Process the specified input as is.
        /// The final result is determined by
        /// the last stage in the pipeline.
        /// </summary>
        /// <returns>The process.</returns>
        /// <param name="input">Input.</param>
        public override T Process(T input)
        {
            T result = default(T);

            foreach (IStage<T> stage in stages)
            {
                result = stage.Execute(input);
            }

            return result;
        }
    }
}
