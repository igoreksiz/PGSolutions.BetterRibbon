﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace PGSolutions.RibbonDispatcher.ComInterfaces {
    /// <summary></summary>
    [Description("")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid(Guids.IStaticDropDownModel)]
    public interface IStaticDropDownModel {
        /// <summary>Gets or sets the (zero-based) integer of the selected item. Default value.</summary>
        [DispId(0)]
        int SelectedIndex {
            [Description("Gets or sets the (zero-based) integer of the selected item. Default value.")]
            get; set; }

        #region IActivable implementation
        /// <summary>Attaches this control-model to the specified ribbon-control as data source and event sink.</summary>
        [DispId(1),Description("Attaches this control-model to the specified ribbon-control as data source and event sink.")]
        IStaticDropDownModel Attach(string controlId);

        /// <summary>.</summary>
        [DispId(2),Description(".")]
        void Detach();

        /// <summary>Queues a request for this control to be refreshed.</summary>
        [DispId(3),Description("Queues a request for this control to be refreshed.")]
        void Invalidate();
        #endregion

        #region IControl implementation
        /// <summary>Gets the {IControlStrings} for this control.</summary>
        [DispId(4)]
        IControlStrings Strings {
            [Description("Gets the {IControlStrings} for this control.")]
            get;
        }
        /// <summary>Gets or sets whether the control is enabled.</summary>
        [DispId(5)]
        bool IsEnabled {
            [Description("Gets or sets whether the control is enabled.")]
            get; set;
        }
        /// <summary>Gets or sets whether the control is visible.</summary>
        [DispId(6)]
        bool IsVisible {
            [Description("Gets or sets whether the control is visible.")]
            get; set;
        }
        #endregion

        /// <summary>Gets or sets the selected item by ID.</summary>
        [DispId(7)]
        string SelectedId {
            [Description("Gets or sets the selected item by ID.")]
            get; set; }
    }
}
