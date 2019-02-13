﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Runtime.InteropServices;

namespace PGSolutions.RibbonDispatcher.ComInterfaces {
    [ComVisible(false)]
    public interface IActivatable {
        bool ShowActiveOnly { get; set; }
        void Detach();
        void Invalidate();
    }
    [ComVisible(false)]
    public interface IActivatableControl<TCtl> : IActivatable where TCtl : IRibbonCommon {
        TCtl Attach();
        new void Detach();
        new bool ShowActiveOnly { get; set; }
    }
    [ComVisible(false)]
    public interface IActivatableControl<TCtl, TSource> : IActivatable where TCtl:IRibbonCommon {
        TCtl Attach(Func<TSource> getter);
        new void Detach();
        new bool ShowActiveOnly { get; set; }
    }
}
