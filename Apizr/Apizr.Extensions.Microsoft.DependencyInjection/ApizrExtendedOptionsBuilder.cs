﻿using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using Apizr.Authenticating;
using Apizr.Caching;
using Apizr.Connecting;
using Apizr.Mapping;
using HttpTracer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Refit;

namespace Apizr
{
    public class ApizrExtendedOptionsBuilder : IApizrExtendedOptionsBuilder
    {
        protected readonly ApizrExtendedOptions Options;

        public ApizrExtendedOptionsBuilder(ApizrExtendedOptions apizrOptions)
        {
            Options = apizrOptions;
        }

        public IApizrExtendedOptions ApizrOptions => Options;

        public IApizrExtendedOptionsBuilder WithBaseAddress(string baseAddress)
        {
            if (Uri.TryCreate(baseAddress, UriKind.RelativeOrAbsolute, out var baseUri))
                Options.BaseAddressFactory = _ => baseUri;

            return this;
        }

        public IApizrExtendedOptionsBuilder WithBaseAddress(Uri baseAddress)
        {
            Options.BaseAddressFactory = _ => baseAddress;

            return this;
        }

        public IApizrExtendedOptionsBuilder WithBaseAddress(Func<IServiceProvider, string> baseAddressFactory)
        {
            Options.BaseAddressFactory = serviceProvider =>
                Uri.TryCreate(baseAddressFactory.Invoke(serviceProvider), UriKind.RelativeOrAbsolute, out var baseUri)
                    ? baseUri
                    : null;

            return this;
        }

        public IApizrExtendedOptionsBuilder WithBaseAddress(Func<IServiceProvider, Uri> baseAddressFactory)
        {
            Options.BaseAddressFactory = baseAddressFactory;

            return this;
        }

        public IApizrExtendedOptionsBuilder WithHttpTracing(HttpMessageParts trafficVerbosity = HttpMessageParts.All, LogLevel trafficLogLevel = LogLevel.Trace)
            => WithHttpTracing(_ => trafficVerbosity, _ => trafficLogLevel);

        public IApizrExtendedOptionsBuilder WithHttpTracing(
            Func<IServiceProvider, HttpMessageParts> trafficVerbosityFactory,
            Func<IServiceProvider, LogLevel> trafficLogLevelFactory)
        {
            Options.TrafficVerbosityFactory = trafficVerbosityFactory;
            Options.TrafficLogLevelFactory = trafficLogLevelFactory;

            return this;
        }
        
        public IApizrExtendedOptionsBuilder WithHttpClientHandler(HttpClientHandler httpClientHandler)
            => WithHttpClientHandler(_ => httpClientHandler);

        public IApizrExtendedOptionsBuilder WithHttpClientHandler(Func<IServiceProvider, HttpClientHandler> httpClientHandlerFactory)
        {
            Options.HttpClientHandlerFactory = httpClientHandlerFactory;

            return this;
        }

        public IApizrExtendedOptionsBuilder ConfigureHttpClientBuilder(Action<IHttpClientBuilder> httpClientBuilder)
        {
            Options.HttpClientBuilder = httpClientBuilder;

            return this;
        }

        public IApizrExtendedOptionsBuilder WithAuthenticationHandler(Func<HttpRequestMessage, Task<string>> refreshTokenFactory)
        {
            var authenticationHandler = new Func<IServiceProvider, IApizrOptionsBase, DelegatingHandler>((serviceProvider, options) =>
                new AuthenticationHandler(serviceProvider.GetRequiredService<ILogger>(), options, refreshTokenFactory));
            Options.DelegatingHandlersExtendedFactories.Add(authenticationHandler);

            return this;
        }

        public IApizrExtendedOptionsBuilder WithAuthenticationHandler<TAuthenticationHandler>(
            Func<IServiceProvider, IApizrOptionsBase, TAuthenticationHandler> authenticationHandlerFactory) where TAuthenticationHandler : AuthenticationHandlerBase
        {
            Options.DelegatingHandlersExtendedFactories.Add(authenticationHandlerFactory);

            return this;
        }

        public IApizrExtendedOptionsBuilder WithAuthenticationHandler<TSettingsService, TTokenService>(Expression<Func<TSettingsService, string>> tokenProperty,
            Expression<Func<TTokenService, HttpRequestMessage, Task<string>>> refreshTokenMethod)
        {
            Options.DelegatingHandlersExtendedFactories.Add((serviceProvider, options) =>
                new AuthenticationHandler<TSettingsService, TTokenService>(
                    serviceProvider.GetRequiredService<ILogger>(),
                    options,
                    serviceProvider.GetRequiredService<TSettingsService>, tokenProperty,
                    serviceProvider.GetRequiredService<TTokenService>, refreshTokenMethod));

            return this;
        }

        public IApizrExtendedOptionsBuilder WithAuthenticationHandler<TSettingsService>(Expression<Func<TSettingsService, string>> tokenProperty, Func<HttpRequestMessage, Task<string>> refreshTokenFactory)
        {
            Options.DelegatingHandlersExtendedFactories.Add((serviceProvider, options) =>
                new AuthenticationHandler<TSettingsService>(
                    serviceProvider.GetRequiredService<ILogger>(),
                    options,
                    serviceProvider.GetRequiredService<TSettingsService>, tokenProperty, refreshTokenFactory));

            return this;
        }

        public IApizrExtendedOptionsBuilder AddDelegatingHandler(DelegatingHandler delegatingHandler)
            => AddDelegatingHandler(_ => delegatingHandler);

        public IApizrExtendedOptionsBuilder AddDelegatingHandler(
            Func<IServiceProvider, DelegatingHandler> delegatingHandlerFactory)
            => AddDelegatingHandler((serviceProvider, _) => delegatingHandlerFactory(serviceProvider));

        public IApizrExtendedOptionsBuilder AddDelegatingHandler(Func<IServiceProvider, IApizrOptionsBase, DelegatingHandler> delegatingHandlerFactory)
        {
            Options.DelegatingHandlersExtendedFactories.Add(delegatingHandlerFactory);

            return this;
        }

        public IApizrExtendedOptionsBuilder WithRefitSettings(RefitSettings refitSettings)
            => WithRefitSettings(_ => refitSettings);

        public IApizrExtendedOptionsBuilder WithRefitSettings(
            Func<IServiceProvider, RefitSettings> refitSettingsFactory)
        {
            Options.RefitSettingsFactory = refitSettingsFactory;

            return this;
        }

        public IApizrExtendedOptionsBuilder WithConnectivityHandler<TConnectivityHandler>()
            where TConnectivityHandler : class, IConnectivityHandler
            => WithConnectivityHandler(typeof(TConnectivityHandler));

        public IApizrExtendedOptionsBuilder WithConnectivityHandler(Type connectivityHandlerType)
        {
            if (!typeof(IConnectivityHandler).IsAssignableFrom(connectivityHandlerType))
                throw new ArgumentException(
                    $"Your connectivity handler class must inherit from {nameof(IConnectivityHandler)} interface or derived");

            Options.ConnectivityHandlerType = connectivityHandlerType;

            return this;
        }

        public IApizrExtendedOptionsBuilder WithCacheHandler<TCacheHandler>()
            where TCacheHandler : class, ICacheHandler
            => WithCacheHandler(typeof(TCacheHandler));

        public IApizrExtendedOptionsBuilder WithCacheHandler(Type cacheHandlerType)
        {
            if (!typeof(ICacheHandler).IsAssignableFrom(cacheHandlerType))
                throw new ArgumentException(
                    $"Your cache handler class must inherit from {nameof(ICacheHandler)} interface or derived");

            Options.CacheHandlerType = cacheHandlerType;

            return this;
        }

        public IApizrExtendedOptionsBuilder WithMappingHandler<TMappingHandler>()
            where TMappingHandler : class, IMappingHandler
            => WithMappingHandler(typeof(TMappingHandler));

        public IApizrExtendedOptionsBuilder WithMappingHandler(Type mappingHandlerType)
        {
            if (!typeof(IMappingHandler).IsAssignableFrom(mappingHandlerType))
                throw new ArgumentException(
                    $"Your mapping handler class must inherit from {nameof(IMappingHandler)} interface or derived");

            Options.MappingHandlerType = mappingHandlerType;

            return this;
        }
    }
}
