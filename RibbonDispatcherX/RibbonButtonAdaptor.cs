﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                                Copyright (c) 2018 Pieter Geerkens                              //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

using PGSolutions.RibbonDispatcher.ComInterfaces;
using System.ComponentModel;
using stdole;

namespace PGSolutions.RibbonDispatcher.ComClasses
{
    /// <summary>The ViewModel for RibbonButton adapters.</summary>
    [Description("The ViewModel for Ribbon Button adapters.")]
    [SuppressMessage("Microsoft.Interoperability", "CA1409:ComVisibleTypesShouldBeCreatable",
        Justification = "Public, Non-Creatable, class with exported Events.")]
    [Serializable]
    [CLSCompliant(true)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IClickedEvents))]
    [ComDefaultInterface(typeof(IRibbonButton))]
    [Guid(Guids.RibbonButtonAdaptor)]
    public class RibbonButtonAdaptor : RibbonButton, IRibbonButton {
        internal RibbonButtonAdaptor(string itemId, IResourceManager mgr, bool visible, bool enabled,
                RdControlSize size, ImageObject image, bool showImage, bool showLabel)
            : base(itemId, mgr, visible, enabled, size, image, showImage, showLabel) {
        }

        public override bool IsVisible => base.IsVisible && Proxy != null;

        private IClickableRibbonButton Proxy { get; set; }

        public IRibbonButton Attach(IClickableRibbonButton proxy, IRibbonTextLanguageControl strings) {
            SetLanguageStrings(strings);
            Proxy = proxy;
            return this;
        }

        public void Detach() {
            Proxy = null;
            SetLanguageStrings(RibbonTextLanguageControl.Empty);
        }

        /// <summary>The callback from the Ribbon Dispatcher to initiate Clicked events on this control.</summary>
        public override void OnClicked() => Proxy.OnClicked();
    }

    [CLSCompliant(true)]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IClickableRibbonButton {
        void OnClicked();
    }
}
