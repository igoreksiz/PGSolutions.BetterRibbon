﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PGSolutions.RibbonDispatcher.ComInterfaces;

namespace PGSolutions.RibbonDispatcher.ComClasses {
    public class RibbonGroupViewModel : RibbonCommon<IRibbonCommonSource>, IRibbonGroup,
            IActivatable<IRibbonGroup, IRibbonCommonSource> {
        public RibbonGroupViewModel(IRibbonFactory factory, string itemId)
        : base(itemId) {
            Factory = factory;
            AdaptorControls = new Dictionary<string, IActivatable>();
            Add<IRibbonCommonSource>(this);
        }

        #region IActivatable implementation
        /// <summary>Attaches this control-model to the specified ribbon-control as data source and event sink.</summary>
        [Description("Attaches this control-model to the specified ribbon-control as data source and event sink.")]
        IRibbonGroup IActivatable<IRibbonGroup, IRibbonCommonSource>.Attach(IRibbonCommonSource source)
        => Attach<RibbonGroupViewModel>(source);

        public override void Detach() {
            foreach (var c in AdaptorControls) c.Value.Detach();
            base.Detach();
        }
        #endregion

        public IRibbonFactory Factory { get; }

        protected IDictionary<string, IActivatable> AdaptorControls { get; }

        public TControl GetControl<TControl>(string controlId) where TControl : class,IRibbonCommon
        => AdaptorControls.FirstOrDefault(kv => kv.Key == controlId).Value as TControl;

        public RibbonGroupViewModel Add<TSource>(IActivatable control)
        where TSource:IRibbonCommonSource{
            if (control == null) return null;
            AdaptorControls.Add(new KeyValuePair<string, IActivatable>(control.Id, control));
            return this;
        }

        public void DetachControls() {
            foreach (var ctrl in AdaptorControls) if(ctrl.Value != this) ctrl.Value?.Detach();
        }

        public new IRibbonControlStrings Strings => base.Strings;

        protected static string NoImage => "MacroSecurity";
    }
}
