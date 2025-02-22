﻿using System;
using Apizr.Configuring.Common;

namespace Apizr.Configuring.Registry
{
    public interface IApizrRegistry : IApizrEnumerableRegistry
    {
        void Populate(Action<Type, Func<object>> populateAction);
    }
}
