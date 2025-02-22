﻿using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Apizr.Mediation.Requesting.Handling.Base;
using Polly;

namespace Apizr.Mediation.Requesting.Handling
{
    public class ExecuteResultRequestHandler<TWebApi, TModelResultData, TApiResultData, TApiRequestData,
        TModelRequestData> : ExecuteResultRequestHandlerBase<TWebApi,
        TModelResultData, TApiResultData, TApiRequestData, TModelRequestData, ExecuteResultRequest<TWebApi,
            TModelResultData, TApiResultData, TApiRequestData, TModelRequestData>>
    {
        public ExecuteResultRequestHandler(IApizrManager<TWebApi> webApiManager) : base(webApiManager)
        {
        }

        public override Task<TModelResultData> Handle(
            ExecuteResultRequest<TWebApi, TModelResultData, TApiResultData, TApiRequestData, TModelRequestData> request,
            CancellationToken cancellationToken)
        {
            switch (request.ExecuteApiMethod)
            {
                case Expression<Func<TWebApi, TApiRequestData, Task<TApiResultData>>> executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync<TModelResultData, TApiResultData, TApiRequestData, TModelRequestData>(
                            executeApiMethod, request.ModelRequestData, request.ClearCache, request.OnException);

                case Expression<Func<CancellationToken, TWebApi, TApiRequestData, Task<TApiResultData>>>
                    executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync<TModelResultData, TApiResultData, TApiRequestData, TModelRequestData>(
                            executeApiMethod, request.ModelRequestData, cancellationToken, request.ClearCache, request.OnException);

                case Expression<Func<Context, TWebApi, TApiRequestData, Task<TApiResultData>>> executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync<TModelResultData, TApiResultData, TApiRequestData, TModelRequestData>(
                            executeApiMethod, request.ModelRequestData, request.Context, request.ClearCache, request.OnException);

                case Expression<Func<Context, CancellationToken, TWebApi, TApiRequestData, Task<TApiResultData>>>
                    executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync<TModelResultData, TApiResultData, TApiRequestData, TModelRequestData>(
                            executeApiMethod, request.ModelRequestData, request.Context, cancellationToken, request.ClearCache, request.OnException);

                default:
                    throw new ApizrException<TModelResultData>(new NotImplementedException());
            }
        }
    }

    public class ExecuteResultRequestHandler<TWebApi, TModelData, TApiData> : ExecuteResultRequestHandlerBase<TWebApi,
        TModelData, TApiData, ExecuteResultRequest<TWebApi,
            TModelData, TApiData>>
    {
        public ExecuteResultRequestHandler(IApizrManager<TWebApi> webApiManager) : base(webApiManager)
        {
        }

        public override Task<TModelData> Handle(
            ExecuteResultRequest<TWebApi, TModelData, TApiData> request,
            CancellationToken cancellationToken)
        {
            switch (request.ExecuteApiMethod)
            {
                case Expression<Func<TWebApi, Task<TApiData>>> executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync<TModelData, TApiData>(
                            executeApiMethod, request.ClearCache, request.OnException);

                case Expression<Func<Context, TWebApi, Task<TApiData>>>
                    executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync<TModelData, TApiData>(
                            executeApiMethod, request.Context, request.ClearCache);

                case Expression<Func<CancellationToken, TWebApi, Task<TApiData>>> executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync<TModelData, TApiData>(
                            executeApiMethod, cancellationToken, request.ClearCache, request.OnException);

                case Expression<Func<TWebApi, TApiData, Task<TApiData>>>
                    executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync<TModelData, TApiData>(
                            executeApiMethod, request.ModelRequestData, request.ClearCache, request.OnException);

                case Expression<Func<CancellationToken, TWebApi, TApiData, Task<TApiData>>> executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync<TModelData, TApiData>(
                            executeApiMethod, request.ModelRequestData, cancellationToken, request.ClearCache, request.OnException);

                case Expression<Func<Context, CancellationToken, TWebApi, Task<TApiData>>>
                    executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync<TModelData, TApiData>(
                            executeApiMethod, request.Context, cancellationToken, request.ClearCache, request.OnException);

                case Expression<Func<Context, TWebApi, TApiData, Task<TApiData>>> executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync<TModelData, TApiData>(
                            executeApiMethod, request.ModelRequestData, request.Context, request.ClearCache, request.OnException);

                case Expression<Func<Context, CancellationToken, TWebApi, TApiData, Task<TApiData>>>
                    executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync<TModelData, TApiData>(
                            executeApiMethod, request.ModelRequestData, request.Context, cancellationToken, request.ClearCache, request.OnException);

                default:
                    throw new ApizrException<TModelData>(new NotImplementedException());
            }
        }
    }

    public class ExecuteResultRequestHandler<TWebApi, TApiData> : ExecuteResultRequestHandlerBase<TWebApi,
        TApiData, ExecuteResultRequest<TWebApi, TApiData>>
    {
        public ExecuteResultRequestHandler(IApizrManager<TWebApi> webApiManager) : base(webApiManager)
        {
        }

        public override Task<TApiData> Handle(
            ExecuteResultRequest<TWebApi, TApiData> request,
            CancellationToken cancellationToken)
        {
            switch (request.ExecuteApiMethod)
            {
                case Expression<Func<TWebApi, Task<TApiData>>> executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync(
                            executeApiMethod, request.ClearCache, request.OnException);

                case Expression<Func<Context, TWebApi, Task<TApiData>>>
                    executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync(
                            executeApiMethod, request.Context, request.ClearCache, request.OnException);

                case Expression<Func<CancellationToken, TWebApi, Task<TApiData>>> executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync(
                            executeApiMethod, cancellationToken, request.ClearCache, request.OnException);

                case Expression<Func<TWebApi, TApiData, Task<TApiData>>>
                    executeApiMethod:
                    return WebApiManager
                        .ExecuteAsync(
                            executeApiMethod, request.ModelRequestData, request.ClearCache, request.OnException);

                default:
                    throw new ApizrException<TApiData>(new NotImplementedException());
            }
        }
    }
}
