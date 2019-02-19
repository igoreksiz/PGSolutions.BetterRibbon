﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;

using PGSolutions.RibbonDispatcher.ComInterfaces;

namespace PGSolutions.RibbonDispatcher.ComClasses {
    /// <summary>TODO</summary>
    [CLSCompliant(true)]
    public abstract class RibbonCommon<TSource>: IRibbonCommon, IActivatable<TSource,IRibbonCommon>
        where TSource: IRibbonCommonSource {
        /// <summary>TODO</summary>
        protected RibbonCommon(string itemId) => Id = itemId;

        #region Common Control implementation
        /// <summary>TODO</summary>
        internal event ChangedEventHandler Changed;

        /// <inheritdoc/>
        public string Id             { get; }
        /// <inheritdoc/>
        public string KeyTip         => Strings?.KeyTip ?? "";
        /// <inheritdoc/>
        public virtual string Label  => Strings?.Label ?? Id;
        /// <inheritdoc/>
        public string ScreenTip      => Strings?.ScreenTip ?? $"{Id} ScreenTip";
        /// <inheritdoc/>
        public string SuperTip       => Strings?.SuperTip ?? $"{Id} SuperTip";
        /// <inheritdoc/>
        public string AlternateLabel => Strings?.AlternateLabel ?? $"{Id} Alternate";
        /// <inheritdoc/>
        public string Description    => Strings?.Description ?? $"{Id} Description";

        /// <inheritdoc/>
        protected virtual IRibbonControlStrings Strings => Source?.Strings;

        /// <inheritdoc/>
        public bool IsEnabled        => Source?.IsEnabled ?? false;

        /// <inheritdoc/>
        public bool IsVisible        => Source?.IsVisible ?? ShowInactive;
        #endregion

        #region IActivatable implementation
        protected TSource Source { get; private set; }

        protected bool IsAttached => Source != null;

        /// <inheritdoc/>
        protected virtual T Attach<T>(TSource source) where T: RibbonCommon<TSource> {
            Source = source;
            Invalidate();
            return this as T;
        }

        public IRibbonCommon Attach(TSource source) => Attach<RibbonCommon<TSource>>(source);

        /// <inheritdoc/>
        public virtual void Detach() {
            Source = default;
            Invalidate();
        }

        /// <inheritdoc/>
        public bool ShowInactive => Source?.ShowInactive ?? _defaultShowInactive;

        /// <inheritdoc/>
        public void SetShowInactive(bool showInactive) {
            _defaultShowInactive = showInactive; Invalidate();
        }
        bool _defaultShowInactive = false;
        #endregion

        /// <inheritdoc/>
        public virtual void Invalidate() => Changed?.Invoke(this, new ControlChangedEventArgs(Id));
    }
}
