﻿using System;
using HttpTracer;
using Microsoft.Extensions.Logging;

namespace Apizr.Logging.Attributes
{
    /// <summary>
    /// Tells Apizr to trace and log HTTP(s) traffic
    /// </summary>
    public abstract class LogAttributeBase : Attribute
    {
        /// <summary>
        /// Trace All http traffic and log Apizr execution steps at Information log level
        /// </summary>
        protected LogAttributeBase()
        {

        }

        /// <summary>
        /// Trace http traffic at specified verbosity and log Apizr execution steps at Information log level
        /// </summary>
        /// <param name="trafficVerbosity">Http traffic tracing verbosity (default: all)</param>
        protected LogAttributeBase(HttpMessageParts trafficVerbosity)
        {
            TrafficVerbosity = trafficVerbosity;
        }

        /// <summary>
        /// Trace All http traffic and log Apizr execution steps at specified log level
        /// </summary>
        /// <param name="logLevel">Log level to apply while writing (default: Trace)</param>
        protected LogAttributeBase(LogLevel logLevel)
        {
            LogLevel = logLevel;
        }

        /// <summary>
        /// Trace All http traffic and log Apizr execution steps at specified log level
        /// </summary>
        /// <param name="trafficVerbosity">Http traffic tracing verbosity (default: all)</param>
        /// <param name="logLevel">Log level to apply while writing (default: Trace)</param>
        protected LogAttributeBase(HttpMessageParts trafficVerbosity, LogLevel logLevel)
        {
            TrafficVerbosity = trafficVerbosity;
            LogLevel = logLevel;
        }

        /// <summary>
        /// Http traffic tracing verbosity (default: all)
        /// </summary>
        public HttpMessageParts TrafficVerbosity { get; } = HttpMessageParts.All;

        /// <summary>
        /// Log level to apply while writing (default: Information)
        /// </summary>
        public LogLevel LogLevel { get; } = LogLevel.Information;
    }
}
