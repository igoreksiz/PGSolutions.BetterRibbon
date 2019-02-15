﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Runtime.InteropServices;

namespace PGSolutions.RibbonDispatcher.ComInterfaces {
    [ComVisible(false)]
    public interface IActivatable {
        string Id           { get; }
    //    bool   ShowInactive { get; }
        void   Detach();
    //    void   Invalidate();
    }
    //[ComVisible(false)]
    //public interface IAttachableControlModel<TCtl>
    //        where TCtl : IRibbonCommon {
    //    new string Id { get; }
    //    TCtl Attach(string id);
    //    void Detach();
    //    bool ShowInactive { get; }
    //}
    [ComVisible(false)]
    public interface IActivatable<TCtrl, TSource> : IActivatable
            where TCtrl : IRibbonCommon where TSource : IRibbonCommonSource {
        TCtrl Attach(TSource source);
        bool ShowInactive { get; }

        new string Id { get; }
        new void   Detach();
   }
}
