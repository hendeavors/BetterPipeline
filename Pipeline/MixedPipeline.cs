using System;
using System.Collections.Generic;

namespace BetterPipeline
{
    public abstract class MixedPipeline<T,K>
    {
        /// <summary>
        /// The stages.
        /// </summary>
        protected readonly IList<IMixedStage<T,K>> stages = new List<IMixedStage<T,K>>();

        /// <summary>
        /// Pipe the specified stage.
        /// </summary>
        /// <returns>The pipe.</returns>
        /// <param name="stage">Stage.</param>
        public MixedPipeline<T,K> Pipe(IMixedStage<T,K> stage)
        {
            stages.Add(stage);

            return this;
        }

        /// <summary>
        /// Register the specified stage.
        /// </summary>
        /// <returns>The register.</returns>
        /// <param name="stage">Stage.</param>
        public MixedPipeline<T,K> Register(IMixedStage<T,K> stage)
        {
            return Pipe(stage);
        }

        /// <summary>
        /// Process the specified input.
        /// </summary>
        /// <returns>The process.</returns>
        /// <param name="input">Input.</param>
        public abstract T Process(K input);

        /// <summary>
        /// Gets the stages.
        /// </summary>
        /// <returns>The stages.</returns>
        public IList<IMixedStage<T,K>> GetStages()
        {
            return stages;
        }
    }
}
