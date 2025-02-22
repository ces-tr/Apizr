﻿using Apizr.Extending.Configuring.Common;

[assembly: Apizr.Preserve]
namespace Apizr
{
    public static class MicrosoftCachingOptionsBuilderExtensions
    {
        /// <summary>
        /// Use any registered IDistributedCache implementation
        /// </summary>
        /// <returns></returns>
        public static TBuilder WithDistributedCacheHandler<TBuilder, TCache>(this TBuilder builder) where TBuilder : IApizrExtendedCommonOptionsBuilder
        {
            builder.WithCacheHandler<DistributedCacheHandler<TCache>>();

            return builder;
        }


        /// <summary>
        /// Use any registered IMemoryCache implementation
        /// </summary>
        /// <returns></returns>
        public static TBuilder WithInMemoryCacheHandler<TBuilder>(this TBuilder builder) where TBuilder : IApizrExtendedCommonOptionsBuilder
        {
            builder.WithCacheHandler<InMemoryCacheHandler>();

            return builder;
        }
    }
}
