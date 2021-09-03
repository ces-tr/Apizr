﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Apizr.Caching;
using MonkeyCache;

[assembly: Apizr.Preserve]
namespace Apizr.Integrations.MonkeyCache
{
    public class MonkeyCacheHandler : ICacheHandler
    {
        private readonly IBarrel _barrel;
        private readonly TimeSpan _maxLifeSpan;

        public MonkeyCacheHandler(IBarrel barrel)
        {
            _barrel = barrel;
            _maxLifeSpan = DateTime.MaxValue - DateTime.Now;
        }

        public Task SetAsync(string key, object value, TimeSpan? lifeSpan = null, CancellationToken cancellationToken = default)
        {
            _barrel.Add(key, value, lifeSpan ?? _maxLifeSpan);

            return Task.CompletedTask;
        }

        public Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_barrel.Get<T>(key));
        }

        public Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                _barrel.Empty(key);

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task ClearAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                _barrel.EmptyAll();

                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }
}
