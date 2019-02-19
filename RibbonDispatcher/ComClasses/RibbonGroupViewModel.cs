﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using PGSolutions.RibbonDispatcher.ComInterfaces;

namespace PGSolutions.RibbonDispatcher.ComClasses {
    public class RibbonGroupViewModel : RibbonCommon<IRibbonCommonSource>, IRibbonGroup,
            IActivatable<IRibbonCommonSource,RibbonGroupViewModel> {
        public RibbonGroupViewModel(IRibbonFactory factory, string itemId)
        : base(itemId) {
            Factory = factory;
            Controls = new KeyedControls();
            Add<IRibbonCommonSource>(this);
        }

        /// <summary>Attaches this control-model to the specified ribbon-control as data source and event sink.</summary>
        [Description("Attaches this control-model to the specified ribbon-control as data source and event sink.")]
        RibbonGroupViewModel IActivatable<IRibbonCommonSource,RibbonGroupViewModel>.Attach(IRibbonCommonSource source)
        => Attach<RibbonGroupViewModel>(source);

        public override void Detach() {
            foreach (var c in Controls) c.Detach();
            base.Detach();
        }

        public IRibbonFactory Factory { get; }

        protected KeyedCollection<string,IActivatable> Controls { get; }

        public override void Invalidate() => Invalidate(null);

        internal void Invalidate(Action<IActivatable> action) {
            foreach (var ctrl in Controls) {
                if (ctrl != this) {
                    action?.Invoke(ctrl);
                    ctrl.Invalidate(); 
                }
            }
            base.Invalidate();
        }

        public TControl GetControl<TControl>(string controlId) where TControl : class,IRibbonCommon
        => Controls.FirstOrDefault(ctl => ctl.Id == controlId) as TControl;

        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public RibbonGroupViewModel Add<TSource>(IActivatable control)
        where TSource:IRibbonCommonSource {
            if (control == null) return null;
            Controls.Add(control);
            return this;
        }

        public void DetachControls() {
            foreach (var ctrl in Controls) {
                if (ctrl != this) ctrl?.Detach();
                ctrl.SetShowInactive(false);
            }
        }

        public new IRibbonControlStrings Strings => base.Strings;

        protected static string NoImage => "MacroSecurity";

        public new void SetShowInactive(bool showInactive) {
            foreach (var vm in Controls) { 
                if (vm != this) { vm.SetShowInactive(showInactive); }
            }
            base.SetShowInactive(showInactive);
        }

        private class KeyedControls : KeyedCollection<string,IActivatable> {
            public KeyedControls() :base() { }
            protected override string GetKeyForItem(IActivatable control) => control?.Id;
        }
    }
}
