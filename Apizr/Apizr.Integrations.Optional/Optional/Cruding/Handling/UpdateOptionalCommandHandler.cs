﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Apizr.Extending;
using Apizr.Mediation.Cruding.Handling.Base;
using Apizr.Requesting;
using MediatR;
using Optional;
using Optional.Async.Extensions;

namespace Apizr.Optional.Cruding.Handling
{
    public class UpdateOptionalCommandHandler<TModelEntity, TApiEntity, TApiEntityKey, TReadAllResult, TReadAllParams> : 
        UpdateCommandHandlerBase<TModelEntity, TApiEntity, TApiEntityKey, TReadAllResult, TReadAllParams, UpdateOptionalCommand<TApiEntityKey, TModelEntity>, Option<Unit, ApizrException>>
        where TModelEntity : class
        where TApiEntity : class
    {
        public UpdateOptionalCommandHandler(IApizrManager<ICrudApi<TApiEntity, TApiEntityKey, TReadAllResult, TReadAllParams>> crudApiManager) : base(crudApiManager)
        {
        }

        public override async Task<Option<Unit, ApizrException>> Handle(UpdateOptionalCommand<TApiEntityKey, TModelEntity> request, CancellationToken cancellationToken)
        {
            try
            {
                return await request
                    .SomeNotNull(new ApizrException(
                        new NullReferenceException($"Request {request.GetType().GetFriendlyName()} can not be null")))
                    .MapAsync(async _ =>
                    {
                        await CrudApiManager
                            .ExecuteAsync<TModelEntity, TApiEntity>(
                                (ctx, ct, api, apiEntity) =>
                                    api.Update(request.Key, apiEntity, ctx, ct), request.RequestData, request.Context,
                                cancellationToken);

                        return Unit.Value;
                    })
                    .ConfigureAwait(false);
            }
            catch (ApizrException e)
            {
                return Option.None<Unit, ApizrException>(e);
            }
        }
    }

    public class UpdateOptionalCommandHandler<TModelEntity, TApiEntity, TReadAllResult, TReadAllParams> : 
        UpdateCommandHandlerBase<TModelEntity, TApiEntity, TReadAllResult, TReadAllParams, UpdateOptionalCommand<TModelEntity>, Option<Unit, ApizrException>>
        where TModelEntity : class
        where TApiEntity : class
    {
        public UpdateOptionalCommandHandler(IApizrManager<ICrudApi<TApiEntity, int, TReadAllResult, TReadAllParams>> crudApiManager) : base(crudApiManager)
        {
        }

        public override async Task<Option<Unit, ApizrException>> Handle(UpdateOptionalCommand<TModelEntity> request, CancellationToken cancellationToken)
        {
            try
            {
                return await request
                    .SomeNotNull(new ApizrException(
                        new NullReferenceException($"Request {request.GetType().GetFriendlyName()} can not be null")))
                    .MapAsync(async _ =>
                    {
                        await CrudApiManager
                            .ExecuteAsync<TModelEntity, TApiEntity>(
                                (ctx, ct, api, apiEntity) =>
                                    api.Update(request.Key, apiEntity, ctx, ct), request.RequestData, request.Context,
                                cancellationToken);

                        return Unit.Value;
                    })
                    .ConfigureAwait(false);
            }
            catch (ApizrException e)
            {
                return Option.None<Unit, ApizrException>(e);
            }
        }
    }
}
