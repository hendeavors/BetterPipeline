using System;
using System.Collections.Generic;
using BetterPipeline.Builder;

namespace BetterPipeline
{
    public abstract class Pipeline<T> : IPipeline<T>
    {
        /// <summary>
        /// The builder.
        /// </summary>
        protected readonly IPipelineBuilder<T> builder = new PipelineBuilder<T>();

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
            return builder.GetStages();
        }

        /// <summary>
        /// Pipe the specified stage.
        /// </summary>
        /// <returns>The pipe.</returns>
        /// <param name="stage">Stage.</param>
        public IPipelineBuilder<T> Pipe(IStage<T> stage)
        {
            builder.Pipe(stage);

            return builder;
        }

        public IPipelineBuilder<T> Pipe(IPipelineBuilder<T> p)
        {
            foreach(var s in p.GetStages())
            {
                builder.Pipe(s);
            }

            return builder;
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
