using System;
using System.Collections.Generic;

namespace BetterPipeline.Builder
{
    /// <summary>
    /// Pipeline builder.
    /// </summary>
    public class PipelineBuilder<T> : IPipelineBuilder<T>
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
        public IPipelineBuilder<T> Pipe(IStage<T> stage)
        {
            stages.Add(stage);

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

        /// <summary>
        /// Pipe the specified pipeline.
        /// </summary>
        /// <returns>The pipe.</returns>
        /// <param name="p">P.</param>
        public IPipelineBuilder<T> Pipe(IPipelineBuilder<T> p)
        {
            foreach (var s in p.GetStages())
            {
                stages.Add(s);
            }

            return this;
        }

        public IList<IStage<T>> GetStages()
        {
            return stages;
        }
    }
}
