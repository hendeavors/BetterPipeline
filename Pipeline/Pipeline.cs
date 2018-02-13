using System;
using System.Collections.Generic;

namespace BetterPipeline
{
    public abstract class Pipeline<T>
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
        public Pipeline<T> Pipe(IStage<T> stage)
        {
            stages.Add(stage);

            return this;
        }

        /// <summary>
        /// Register the specified stage.
        /// </summary>
        /// <returns>The register.</returns>
        /// <param name="stage">Stage.</param>
        public Pipeline<T> Register(IStage<T> stage)
        {
            return Pipe(stage);
        }

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
