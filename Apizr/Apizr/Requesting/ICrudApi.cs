﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Apizr.Caching;
using Apizr.Policing;
using Refit;

namespace Apizr.Requesting
{
    [Policy("TransientHttpError"), Cache]
    public interface ICrudApi<T, in TKey> where T : class
    {
        [Post("")]
        Task<T> Create([Body] T payload, CancellationToken cancellationToken = default);

        [Get("")]
        Task<IEnumerable<T>> ReadAll(CancellationToken cancellationToken = default);

        [Get("/{key}")]
        Task<T> Read([CacheKey] TKey key, CancellationToken cancellationToken = default);

        [Put("/{key}")]
        Task Update(TKey key, [Body] T payload, CancellationToken cancellationToken = default);

        [Delete("/{key}")]
        Task Delete(TKey key, CancellationToken cancellationToken = default);
    }
}