using System;
using System.Collections.Generic;

namespace BetterPipeline
{
    public abstract class Pipeline<T> : IPipeline<T>
    {
        /// <summary>
        /// The stages.
        /// </summary>
        protected readonly IList<IStage<T>> stages = new List<IStage<T>>();

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

        /// <summary>
        /// Pipe the specified stage.
        /// </summary>
        /// <returns>The pipe.</returns>
        /// <param name="stage">Stage.</param>
        public IPipelineBuilder<T> Pipe(IStage<T> stage)
        {
            stages.Add(stage);

            return this;
        }

        public IPipelineBuilder<T> Pipe(Pipeline<T> p)
        {
            foreach(var s in p.GetStages())
            {
                stages.Add(s);
            }

            return this;
        }

        /// <summary>
        /// Register the specified stage.
        /// </summary>
        /// <returns>The register.</returns>
        /// <param name="stage">Stage.</param>
        public IPipelineBuilder<T> Register(IStage<T> stage)
        {
            return Pipe(stage);
        }
    }
}
