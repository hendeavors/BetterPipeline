using System;
using System.Collections.Generic;

namespace BetterPipeline.Builder
{
    /// <summary>
    /// Pipeline builder.
    /// </summary>
    public abstract class PipelineBuilder<T>
    {
        /// <summary>
        /// The stages.
        /// </summary>
        protected readonly IList<IStage<T>> stages = new List<IStage<T>>();

        /// <summary>
        /// Pipe the specified stage.
        /// </summary>
        /// <returns>The pipe.</returns>
        /// <param name="stage">Stage.</param>
        public PipelineBuilder<T> Pipe(IStage<T> stage)
        {
            stages.Add(stage);

            return this;
        }

        /// <summary>
        /// Register the specified stage.
        /// </summary>
        /// <returns>The register.</returns>
        /// <param name="stage">Stage.</param>
        public PipelineBuilder<T> Register(IStage<T> stage)
        {
            return Pipe(stage);
        }
    }
}
