﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Polly;

namespace Apizr.Mediation.Cruding.Sending
{
    public class ApizrCrudMediator : IApizrCrudMediator
    {
        private readonly IMediator _mediator;

        public ApizrCrudMediator(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Create

        #region SendCreateCommand

        public Task<TApiEntity> SendCreateCommand<TApiEntity>(TApiEntity entity, Action<Exception> onException = null) =>
            _mediator.Send(new CreateCommand<TApiEntity>(entity, onException));

        public Task<TApiEntity> SendCreateCommand<TApiEntity>(TApiEntity entity, Context context, Action<Exception> onException = null) =>
            _mediator.Send(new CreateCommand<TApiEntity>(entity, context, onException));

        public Task<TApiEntity> SendCreateCommand<TApiEntity>(TApiEntity entity,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _mediator.Send(new CreateCommand<TApiEntity>(entity, onException), cancellationToken);

        public Task<TApiEntity> SendCreateCommand<TApiEntity>(TApiEntity entity, Context context,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _mediator.Send(new CreateCommand<TApiEntity>(entity, context, onException), cancellationToken);

        #endregion

        #region SendCreateCommand<TModelEntity>

        public Task<TModelEntity> SendCreateCommand<TModelEntity, TApiEntity>(TModelEntity entity,
            Action<Exception> onException = null) =>
            _mediator.Send(new CreateCommand<TModelEntity>(entity, onException));

        public Task<TModelEntity> SendCreateCommand<TModelEntity, TApiEntity>(TModelEntity entity, Context context, Action<Exception> onException = null) =>
            _mediator.Send(new CreateCommand<TModelEntity>(entity, context, onException));

        public Task<TModelEntity> SendCreateCommand<TModelEntity, TApiEntity>(TModelEntity entity,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _mediator.Send(new CreateCommand<TModelEntity>(entity, onException), cancellationToken);

        public Task<TModelEntity> SendCreateCommand<TModelEntity, TApiEntity>(TModelEntity entity, Context context,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _mediator.Send(new CreateCommand<TModelEntity>(entity, context, onException), cancellationToken);

        #endregion

        #endregion

        #region ReadAll

        #region SendReadAllQuery

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult>(bool clearCache = false, Action<Exception> onException = null) => 
            _mediator.Send(new ReadAllQuery<TReadAllResult>(clearCache, onException));

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult>(Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllResult>(context, clearCache, onException));

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult>(CancellationToken cancellationToken,
            bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllResult>(clearCache, onException), cancellationToken);

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult>(int priority, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllResult>(priority, clearCache, onException));

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult>(int priority, Context context,
            bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllResult>(priority, context, clearCache, onException));

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult>(int priority,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllResult>(priority, clearCache, onException), cancellationToken);

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult>(Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllResult>(context, clearCache, onException), cancellationToken);

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult>(int priority, Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllResult>(priority, context, clearCache, onException), cancellationToken);

        #endregion

        #region SendReadAllQuery<TModelReadAllResult>

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult>(bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TModelReadAllResult>(clearCache, onException));

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult>(Context context,
            bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TModelReadAllResult>(context, clearCache, onException));

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult>(
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TModelReadAllResult>(clearCache, onException), cancellationToken);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult>(int priority,
            bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TModelReadAllResult>(priority, clearCache, onException));

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult>(int priority,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TModelReadAllResult>(priority, clearCache, onException), cancellationToken);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult>(int priority,
            Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TModelReadAllResult>(priority, context, clearCache, onException));

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult>(Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TModelReadAllResult>(context, clearCache, onException), cancellationToken);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult>(int priority,
            Context context, CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TModelReadAllResult>(priority, context, clearCache, onException), cancellationToken);

        #endregion

        #region SendReadAllQuery(TReadAllParams)

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult, TReadAllParams>(TReadAllParams readAllParams,
            bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllParams, TReadAllResult>(readAllParams, clearCache, onException));

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult, TReadAllParams>(TReadAllParams readAllParams,
            Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllParams, TReadAllResult>(readAllParams, context, clearCache, onException));

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult, TReadAllParams>(TReadAllParams readAllParams,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllParams, TReadAllResult>(readAllParams, clearCache, onException), cancellationToken);

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult, TReadAllParams>(TReadAllParams readAllParams,
            int priority, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllParams, TReadAllResult>(readAllParams, priority, clearCache, onException));

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult, TReadAllParams>(TReadAllParams readAllParams,
            int priority, Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllParams, TReadAllResult>(readAllParams, priority, context, clearCache, onException));

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult, TReadAllParams>(TReadAllParams readAllParams,
            int priority,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllParams, TReadAllResult>(readAllParams, priority, clearCache, onException),
                cancellationToken);

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult, TReadAllParams>(TReadAllParams readAllParams,
            Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllParams, TReadAllResult>(readAllParams, context, clearCache, onException), cancellationToken);

        public Task<TReadAllResult> SendReadAllQuery<TReadAllResult, TReadAllParams>(TReadAllParams readAllParams,
            int priority, Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) => _mediator.Send(
            new ReadAllQuery<TReadAllParams, TReadAllResult>(readAllParams, priority, context, clearCache, onException), cancellationToken);

        #endregion

        #region SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(TReadAllParams)

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(
            TReadAllParams readAllParams, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllParams, TModelReadAllResult>(readAllParams, clearCache, onException));

        public Task<TModelReadAllResult>
            SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(TReadAllParams readAllParams, Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllParams, TModelReadAllResult>(readAllParams, context, clearCache, onException));

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(
            TReadAllParams readAllParams,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllParams, TModelReadAllResult>(readAllParams, clearCache, onException),
                cancellationToken);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(
            TReadAllParams readAllParams,
            int priority, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllParams, TModelReadAllResult>(readAllParams, priority, clearCache, onException));

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(
            TReadAllParams readAllParams,
            int priority, Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(
                new ReadAllQuery<TReadAllParams, TModelReadAllResult>(readAllParams, priority, context, clearCache, onException));

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(
            TReadAllParams readAllParams,
            int priority,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllParams, TModelReadAllResult>(readAllParams, priority, clearCache, onException),
                cancellationToken);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(
            TReadAllParams readAllParams,
            Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadAllQuery<TReadAllParams, TModelReadAllResult>(readAllParams, context, clearCache, onException),
                cancellationToken);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(
            TReadAllParams readAllParams,
            int priority, Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(
                new ReadAllQuery<TReadAllParams, TModelReadAllResult>(readAllParams, priority, context, clearCache, onException),
                cancellationToken);

        #endregion

        #endregion

        #region Read

        #region SendReadQuery

        public Task<TApiEntity> SendReadQuery<TApiEntity, TApiEntityKey>(TApiEntityKey key, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TApiEntity, TApiEntityKey>(key, clearCache, onException));

        public Task<TApiEntity> SendReadQuery<TApiEntity, TApiEntityKey>(TApiEntityKey key, Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TApiEntity, TApiEntityKey>(key, context, clearCache, onException));

        public Task<TApiEntity> SendReadQuery<TApiEntity, TApiEntityKey>(TApiEntityKey key,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TApiEntity, TApiEntityKey>(key, clearCache, onException), cancellationToken);

        public Task<TApiEntity> SendReadQuery<TApiEntity, TApiEntityKey>(TApiEntityKey key,
            int priority, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TApiEntity, TApiEntityKey>(key, priority, clearCache, onException));

        public Task<TApiEntity> SendReadQuery<TApiEntity, TApiEntityKey>(TApiEntityKey key, Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TApiEntity, TApiEntityKey>(key, context, clearCache, onException), cancellationToken);

        public Task<TApiEntity> SendReadQuery<TApiEntity, TApiEntityKey>(TApiEntityKey key, int priority,
            Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TApiEntity, TApiEntityKey>(key, priority, context, clearCache, onException));

        public Task<TApiEntity> SendReadQuery<TApiEntity, TApiEntityKey>(TApiEntityKey key,
            int priority,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TApiEntity, TApiEntityKey>(key, priority, clearCache, onException), cancellationToken);

        public Task<TApiEntity> SendReadQuery<TApiEntity, TApiEntityKey>(TApiEntityKey key, int priority,
            Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TApiEntity, TApiEntityKey>(key, priority, context, clearCache, onException), cancellationToken);

        #endregion

        #region SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>

        public Task<TModelEntity> SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(TApiEntityKey key,
            bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TModelEntity, TApiEntityKey>(key, clearCache, onException));

        public Task<TModelEntity> SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(TApiEntityKey key, Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TModelEntity, TApiEntityKey>(key, context, clearCache, onException));

        public Task<TModelEntity> SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(TApiEntityKey key,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TModelEntity, TApiEntityKey>(key, clearCache, onException), cancellationToken);

        public Task<TModelEntity> SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(TApiEntityKey key,
            int priority, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TModelEntity, TApiEntityKey>(key, priority, clearCache, onException));

        public Task<TModelEntity> SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(TApiEntityKey key,
            Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TModelEntity, TApiEntityKey>(key, context, clearCache, onException), cancellationToken);

        public Task<TModelEntity> SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(TApiEntityKey key,
            int priority, Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TModelEntity, TApiEntityKey>(key, priority, context, clearCache, onException));

        public Task<TModelEntity> SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(TApiEntityKey key,
            int priority,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TModelEntity, TApiEntityKey>(key, priority, clearCache, onException), cancellationToken);

        public Task<TModelEntity> SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(TApiEntityKey key,
            int priority, Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _mediator.Send(new ReadQuery<TModelEntity, TApiEntityKey>(key, priority, context, clearCache, onException), cancellationToken);

        #endregion

        #endregion

        #region Update

        #region SendUpdateCommand<TApiEntity, TApiEntityKey>

        public Task SendUpdateCommand<TApiEntity, TApiEntityKey>(TApiEntityKey key,
            TApiEntity entity, Action<Exception> onException = null) =>
            _mediator.Send(new UpdateCommand<TApiEntityKey, TApiEntity>(key, entity, onException));

        public Task SendUpdateCommand<TApiEntity, TApiEntityKey>(TApiEntityKey key, TApiEntity entity, Context context, Action<Exception> onException = null) =>
            _mediator.Send(new UpdateCommand<TApiEntityKey, TApiEntity>(key, entity, context, onException));

        public Task SendUpdateCommand<TApiEntity, TApiEntityKey>(TApiEntityKey key,
            TApiEntity entity,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _mediator.Send(new UpdateCommand<TApiEntityKey, TApiEntity>(key, entity, onException), cancellationToken);

        public Task SendUpdateCommand<TApiEntity, TApiEntityKey>(TApiEntityKey key, TApiEntity entity, Context context,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _mediator.Send(new UpdateCommand<TApiEntityKey, TApiEntity>(key, entity, context, onException), cancellationToken);

        #endregion

        #region SendUpdateCommand<TModelEntity, TApiEntity, TApiEntityKey>

        public Task SendUpdateCommand<TModelEntity, TApiEntity, TApiEntityKey>(TApiEntityKey key,
            TModelEntity entity, Action<Exception> onException = null) =>
            _mediator.Send(new UpdateCommand<TApiEntityKey, TModelEntity>(key, entity, onException));

        public Task SendUpdateCommand<TModelEntity, TApiEntity, TApiEntityKey>(TApiEntityKey key, TModelEntity entity, Context context, Action<Exception> onException = null) =>
            _mediator.Send(new UpdateCommand<TApiEntityKey, TModelEntity>(key, entity, context, onException));

        public Task SendUpdateCommand<TModelEntity, TApiEntity, TApiEntityKey>(TApiEntityKey key,
            TModelEntity entity,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _mediator.Send(new UpdateCommand<TApiEntityKey, TModelEntity>(key, entity, onException), cancellationToken);

        public Task SendUpdateCommand<TModelEntity, TApiEntity, TApiEntityKey>(TApiEntityKey key, TModelEntity entity, Context context,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _mediator.Send(new UpdateCommand<TApiEntityKey, TModelEntity>(key, entity, context, onException), cancellationToken);

        #endregion

        #endregion

        #region Delete

        public Task SendDeleteCommand<TApiEntity, TApiEntityKey>(TApiEntityKey key, Action<Exception> onException = null) =>
            _mediator.Send(new DeleteCommand<TApiEntity, TApiEntityKey>(key, onException));

        public Task SendDeleteCommand<TApiEntity, TApiEntityKey>(TApiEntityKey key, Context context, Action<Exception> onException = null) =>
            _mediator.Send(new DeleteCommand<TApiEntity, TApiEntityKey>(key, context, onException));

        public Task SendDeleteCommand<TApiEntity, TApiEntityKey>(TApiEntityKey key,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _mediator.Send(new DeleteCommand<TApiEntity, TApiEntityKey>(key, onException), cancellationToken);

        public Task SendDeleteCommand<TApiEntity, TApiEntityKey>(TApiEntityKey key, Context context, CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _mediator.Send(new DeleteCommand<TApiEntity, TApiEntityKey>(key, onException), cancellationToken);

        #endregion
    }

    public class ApizrCrudMediator<TApiEntity, TApiEntityKey, TReadAllResult, TReadAllParams> : IApizrCrudMediator<TApiEntity, TApiEntityKey, TReadAllResult, TReadAllParams> where TApiEntity : class
    {
        private readonly IApizrCrudMediator _apizrMediator;

        public ApizrCrudMediator(IApizrCrudMediator apizrMediator)
        {
            _apizrMediator = apizrMediator;
        }

        #region Create

        #region SendCreateCommand

        public Task<TApiEntity> SendCreateCommand(TApiEntity entity, Action<Exception> onException = null) =>
            _apizrMediator.SendCreateCommand<TApiEntity>(entity, onException);

        public Task<TApiEntity> SendCreateCommand(TApiEntity entity, Context context, Action<Exception> onException = null) =>
            _apizrMediator.SendCreateCommand<TApiEntity>(entity, context, onException);

        public Task<TApiEntity> SendCreateCommand(TApiEntity entity,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _apizrMediator.SendCreateCommand<TApiEntity>(entity, cancellationToken, onException);

        public Task<TApiEntity> SendCreateCommand(TApiEntity entity, Context context,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _apizrMediator.SendCreateCommand<TApiEntity>(entity, context, cancellationToken, onException);

        #endregion

        #region SendCreateCommand<TModelEntity>

        public Task<TModelEntity> SendCreateCommand<TModelEntity>(TModelEntity entity, Action<Exception> onException = null) =>
            _apizrMediator.SendCreateCommand<TModelEntity>(entity, onException);

        public Task<TModelEntity> SendCreateCommand<TModelEntity>(TModelEntity entity, Context context, Action<Exception> onException = null) =>
            _apizrMediator.SendCreateCommand<TModelEntity>(entity, context, onException);

        public Task<TModelEntity> SendCreateCommand<TModelEntity>(TModelEntity entity,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _apizrMediator.SendCreateCommand<TModelEntity>(entity, cancellationToken, onException);

        public Task<TModelEntity> SendCreateCommand<TModelEntity>(TModelEntity entity, Context context,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _apizrMediator.SendCreateCommand<TModelEntity>(entity, context, cancellationToken, onException);

        #endregion

        #endregion

        #region ReadAll

        #region SendReadAllQuery

        public Task<TReadAllResult> SendReadAllQuery(bool clearCache = false, Action<Exception> onException = null) => _apizrMediator.SendReadAllQuery<TReadAllResult>(clearCache, onException);

        public Task<TReadAllResult> SendReadAllQuery(Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TReadAllResult>(context, clearCache, onException);

        public Task<TReadAllResult> SendReadAllQuery(CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TReadAllResult>(cancellationToken, clearCache, onException);

        public Task<TReadAllResult> SendReadAllQuery(int priority, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TReadAllResult>(priority, clearCache, onException);

        public Task<TReadAllResult> SendReadAllQuery(int priority, Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TReadAllResult>(priority, context, clearCache, onException);

        public Task<TReadAllResult> SendReadAllQuery(int priority,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TReadAllResult>(priority, cancellationToken, clearCache, onException);

        public Task<TReadAllResult> SendReadAllQuery(Context context, CancellationToken cancellationToken,
            bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TReadAllResult>(context, cancellationToken, clearCache, onException);

        public Task<TReadAllResult> SendReadAllQuery(int priority, Context context, CancellationToken cancellationToken,
            bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TReadAllResult>(priority, context, cancellationToken, clearCache, onException);

        #endregion

        #region SendReadAllQuery<TModelReadAllResult>

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult>(clearCache, onException);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult>(context, clearCache, onException);

        public Task<TModelReadAllResult>
            SendReadAllQuery<TModelReadAllResult>(CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult>(cancellationToken, clearCache, onException);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(int priority, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult>(priority, clearCache, onException);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(int priority,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult>(priority, cancellationToken, clearCache, onException);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(int priority, Context context,
            bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult>(priority, context, clearCache, onException);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult>(context, cancellationToken, clearCache, onException);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(int priority,
            Context context, CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult>(priority, context, cancellationToken, clearCache, onException);

        #endregion

        #region SendReadAllQuery(TReadAllParams)

        public Task<TReadAllResult> SendReadAllQuery(TReadAllParams readAllParams, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TReadAllResult, TReadAllParams>(readAllParams, clearCache, onException);

        public Task<TReadAllResult> SendReadAllQuery(TReadAllParams readAllParams, Context context,
            bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TReadAllResult, TReadAllParams>(readAllParams, context, clearCache, onException);

        public Task<TReadAllResult> SendReadAllQuery(TReadAllParams readAllParams,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TReadAllResult, TReadAllParams>(readAllParams, cancellationToken, clearCache, onException);

        public Task<TReadAllResult> SendReadAllQuery(TReadAllParams readAllParams,
            int priority, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TReadAllResult, TReadAllParams>(readAllParams, priority, clearCache, onException);

        public Task<TReadAllResult> SendReadAllQuery(TReadAllParams readAllParams, int priority, Context context,
            bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TReadAllResult, TReadAllParams>(readAllParams, priority, context, clearCache, onException);

        public Task<TReadAllResult> SendReadAllQuery(TReadAllParams readAllParams,
            int priority,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TReadAllResult, TReadAllParams>(readAllParams, priority,
                cancellationToken, clearCache, onException);

        public Task<TReadAllResult> SendReadAllQuery(TReadAllParams readAllParams, Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TReadAllResult, TReadAllParams>(readAllParams, context, cancellationToken, clearCache, onException);

        public Task<TReadAllResult> SendReadAllQuery(TReadAllParams readAllParams, int priority, Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) => 
            _apizrMediator.SendReadAllQuery<TReadAllResult, TReadAllParams>(readAllParams, priority, context, cancellationToken, clearCache, onException);

        #endregion

        #region SendReadAllQuery<TModelReadAllResult>(TReadAllParams)

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(TReadAllParams readAllParams,
            bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(readAllParams, clearCache, onException);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(TReadAllParams readAllParams,
            Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(readAllParams, context, clearCache, onException);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(TReadAllParams readAllParams,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(readAllParams,
                cancellationToken, clearCache, onException);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(TReadAllParams readAllParams,
            int priority, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(readAllParams, priority, clearCache, onException);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(TReadAllParams readAllParams,
            int priority, Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(readAllParams, priority, context, clearCache, onException);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(TReadAllParams readAllParams,
            int priority,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(readAllParams, priority,
                cancellationToken, clearCache, onException);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(TReadAllParams readAllParams,
            Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(readAllParams, context,
                cancellationToken, clearCache, onException);

        public Task<TModelReadAllResult> SendReadAllQuery<TModelReadAllResult>(TReadAllParams readAllParams,
            int priority, Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadAllQuery<TModelReadAllResult, TReadAllResult, TReadAllParams>(readAllParams, priority, context,
                cancellationToken, clearCache, onException);

        #endregion

        #endregion

        #region Read

        #region SendReadQuery

        public Task<TApiEntity> SendReadQuery(TApiEntityKey key, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TApiEntity, TApiEntityKey>(key, clearCache, onException);

        public Task<TApiEntity> SendReadQuery(TApiEntityKey key, Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TApiEntity, TApiEntityKey>(key, context, clearCache, onException);

        public Task<TApiEntity> SendReadQuery(TApiEntityKey key,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TApiEntity, TApiEntityKey>(key, cancellationToken, clearCache, onException);

        public Task<TApiEntity> SendReadQuery(TApiEntityKey key,
            int priority, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TApiEntity, TApiEntityKey>(key, priority, clearCache, onException);

        public Task<TApiEntity> SendReadQuery(TApiEntityKey key, Context context, CancellationToken cancellationToken,
            bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TApiEntity, TApiEntityKey>(key, context, cancellationToken, clearCache, onException);

        public Task<TApiEntity> SendReadQuery(TApiEntityKey key, int priority, Context context, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TApiEntity, TApiEntityKey>(key, priority, context, clearCache, onException);

        public Task<TApiEntity> SendReadQuery(TApiEntityKey key,
            int priority,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TApiEntity, TApiEntityKey>(key, priority, cancellationToken, clearCache, onException);

        public Task<TApiEntity> SendReadQuery(TApiEntityKey key, int priority, Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TApiEntity, TApiEntityKey>(key, priority, context, cancellationToken, clearCache);

        #endregion

        #region SendReadQuery<TModelEntity>

        public Task<TModelEntity> SendReadQuery<TModelEntity>(TApiEntityKey key, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(key, clearCache, onException);

        public Task<TModelEntity> SendReadQuery<TModelEntity>(TApiEntityKey key, Context context,
            bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(key, context, clearCache, onException);

        public Task<TModelEntity> SendReadQuery<TModelEntity>(TApiEntityKey key,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(key, cancellationToken, clearCache, onException);

        public Task<TModelEntity> SendReadQuery<TModelEntity>(TApiEntityKey key,
            int priority, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(key, priority, clearCache, onException);

        public Task<TModelEntity> SendReadQuery<TModelEntity>(TApiEntityKey key, Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(key, context, cancellationToken, clearCache, onException);

        public Task<TModelEntity> SendReadQuery<TModelEntity>(TApiEntityKey key, int priority, Context context,
            bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(key, priority, context, clearCache, onException);

        public Task<TModelEntity> SendReadQuery<TModelEntity>(TApiEntityKey key,
            int priority,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(key, priority, cancellationToken, clearCache, onException);

        public Task<TModelEntity> SendReadQuery<TModelEntity>(TApiEntityKey key, int priority, Context context,
            CancellationToken cancellationToken, bool clearCache = false, Action<Exception> onException = null) =>
            _apizrMediator.SendReadQuery<TModelEntity, TApiEntity, TApiEntityKey>(key, priority, context, cancellationToken, clearCache, onException);

        #endregion

        #endregion

        #region Update

        #region SendUpdateCommand

        public Task SendUpdateCommand(TApiEntityKey key,
            TApiEntity entity, Action<Exception> onException = null) =>
            _apizrMediator.SendUpdateCommand<TApiEntity, TApiEntityKey>(key, entity, onException);

        public Task SendUpdateCommand(TApiEntityKey key, TApiEntity entity, Context context, Action<Exception> onException = null) =>
            _apizrMediator.SendUpdateCommand<TApiEntity, TApiEntityKey>(key, entity, context, onException);

        public Task SendUpdateCommand(TApiEntityKey key,
            TApiEntity entity,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _apizrMediator.SendUpdateCommand<TApiEntity, TApiEntityKey>(key, entity, cancellationToken, onException);

        public Task SendUpdateCommand(TApiEntityKey key, TApiEntity entity, Context context,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _apizrMediator.SendUpdateCommand<TApiEntity, TApiEntityKey>(key, entity, context, cancellationToken, onException);

        #endregion

        #region SendUpdateCommand<TModelEntity>

        public Task SendUpdateCommand<TModelEntity>(TApiEntityKey key,
            TModelEntity entity, Action<Exception> onException = null) =>
            _apizrMediator.SendUpdateCommand<TModelEntity, TApiEntity, TApiEntityKey>(key, entity, onException);

        public Task SendUpdateCommand<TModelEntity>(TApiEntityKey key, TModelEntity entity, Context context, Action<Exception> onException = null) =>
            _apizrMediator.SendUpdateCommand<TModelEntity, TApiEntity, TApiEntityKey>(key, entity, context, onException);

        public Task SendUpdateCommand<TModelEntity>(TApiEntityKey key,
            TModelEntity entity,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _apizrMediator.SendUpdateCommand<TModelEntity, TApiEntity, TApiEntityKey>(key, entity, cancellationToken, onException);

        public Task SendUpdateCommand<TModelEntity>(TApiEntityKey key, TModelEntity entity, Context context,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _apizrMediator.SendUpdateCommand<TModelEntity, TApiEntity, TApiEntityKey>(key, entity, context, cancellationToken, onException);

        #endregion

        #endregion

        #region Delete

        public Task SendDeleteCommand(TApiEntityKey key, Action<Exception> onException = null) =>
            _apizrMediator.SendDeleteCommand<TApiEntity, TApiEntityKey>(key, onException);

        public Task SendDeleteCommand(TApiEntityKey key, Context context, Action<Exception> onException = null) =>
            _apizrMediator.SendDeleteCommand<TApiEntity, TApiEntityKey>(key, context, onException);

        public Task SendDeleteCommand(TApiEntityKey key,
            CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _apizrMediator.SendDeleteCommand<TApiEntity, TApiEntityKey>(key, cancellationToken, onException);

        public Task SendDeleteCommand(TApiEntityKey key, Context context, CancellationToken cancellationToken, Action<Exception> onException = null) =>
            _apizrMediator.SendDeleteCommand<TApiEntity, TApiEntityKey>(key, cancellationToken, onException);

        #endregion
    }
}