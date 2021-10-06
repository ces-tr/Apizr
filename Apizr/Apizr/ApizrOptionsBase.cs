﻿using System;
using System.Linq;
using Apizr.Logging;
using Microsoft.Extensions.Logging;
using Refit;

namespace Apizr
{
    public abstract class ApizrOptionsBase : IApizrOptionsBase
    {
        protected ApizrOptionsBase(IApizrConfigurationBase config, Type webApiType,
            string[] assemblyPolicyRegistryKeys,
            string[] webApiPolicyRegistryKeys)
        {
            WebApiType = webApiType;
            PolicyRegistryKeys =
                assemblyPolicyRegistryKeys?.Union(webApiPolicyRegistryKeys ?? Array.Empty<string>()).ToArray() ??
                webApiPolicyRegistryKeys ?? Array.Empty<string>();
        }

        public Type WebApiType { get; }
        public Uri BaseAddress { get; protected set; }
        public HttpTracerMode HttpTracerMode { get; protected set; }
        public HttpMessageParts TrafficVerbosity { get; protected set; }
        public LogLevel LogLevel { get; protected set; }
        public string[] PolicyRegistryKeys { get; }
        public IHttpContentSerializer ContentSerializer { get; protected set; }
    }
}