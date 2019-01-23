﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                                Copyright (c) 2017-8 Pieter Geerkens                              //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Office.Core;
using stdole;

namespace PGSolutions.RibbonDispatcher.ComInterfaces {
    /// <summary>The ViewModel interface exposed by Ribbon ToggleButtons and CheckBoxes.</summary>
    [ComVisible(true)]
    [CLSCompliant(false)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid(Guids.IRibbonToggleButton)]
    public interface IRibbonToggle : IRibbonCommon, IRibbonImageable {
        /// <summary>Returns the unique (within this ribbon) identifier for this control.</summary>
        [DispId(DispIds.Id)]
        new string Id           { get; }
        /// <summary>Returns the Description string for this control. Only applicable for Menu Items.</summary>
        [DispId(DispIds.Description)]
        [Description("Returns the Description string for this control. Only applicable for Menu Items.")]
        new string Description  { get; }
        /// <summary>Returns the KeyTip string for this control.</summary>
        [DispId(DispIds.KeyTip)]
        [Description("Returns the KeyTip string for this control.")]
        new string KeyTip       { get; }
        /// <summary>Returns the Label string for this control.</summary>
        [DispId(DispIds.Label)]
        [Description("Returns the Label string for this control.")]
        new string Label        { get; }
        /// <summary>Returns the screenTip string for this control.</summary>
        [DispId(DispIds.ScreenTip)]
        [Description("Returns the screenTip string for this control.")]
        new string ScreenTip    { get; }
        /// <summary>Returns the SuperTip string for this control.</summary>
        [DispId(DispIds.SuperTip)]
        [Description("Returns the SuperTip string for this control.")]
        new string SuperTip     { get; }
        /// <summary>Sets the Label, KeyTip, ScreenTip and SuperTip for this control from the supplied values.</summary>
        [DispId(DispIds.SetLanguageStrings)]
        new void SetLanguageStrings(IRibbonControlStrings strings);

        /// <summary>Gets or sets whether the control is enabled.</summary>
        [DispId(DispIds.IsEnabled)]
        [Description("Gets or sets whether the control is enabled.")]
        new bool IsEnabled      { get; set; }
        /// <summary>Gets or sets whether the control is visible.</summary>
        [DispId(DispIds.IsVisible)]
        [Description("Gets or sets whether the control is visible.")]
        new bool IsVisible      { get; set; }

        /// <inheritdoc/>
        new void Invalidate();

        /// <summary>Returns whether the control is pressed.</summary>
        [DispId(DispIds.IsPressed)]
        [Description("Returns whether the control is pressed.")]
        bool IsPressed          { get; }
        /// <summary>Callback for the Pressed event on the control.</summary>
        [DispId(DispIds.OnToggled)]
        [Description("Callback for the Pressed event on the control.")]
        void OnToggled(object sender, bool IsPressed);

        /// <summary>TODO</summary>
        bool         IsSizeable { get; }
        /// <summary>TODO</summary>
        [DispId(DispIds.Size)]
        RibbonControlSize Size  { get; set; }

        /// <summary>TODO</summary>
        bool        IsImageable { get; }
        /// <summary>Returns the current Image for the control as either a {string} naming an MsoImage or an {IPictureDisp}.</summary>
        [DispId(DispIds.Image)]
        [Description("Returns the current Image for the control as either a {string} naming an MsoImage or an {IPictureDisp}.")]
        new object Image        { get; }
        /// <summary>Gets or sets whether to show the control's image; ignored by Large controls.</summary>
        [DispId(DispIds.ShowImage)]
        [Description("Gets or sets whether to show the control's image; ignored by Large controls.")]
        new bool ShowImage      { get; set; }
        /// <summary>Gets or sets whether to show the control's label; ignored by Large controls.</summary>
        [DispId(DispIds.ShowLabel)]
        [Description("Gets or sets whether to show the control's label; ignored by Large controls.")]
        new bool ShowLabel      { get; set; }
        /// <summary>Sets the current Image for the control as an {IPictureDisp}.</summary>
        [DispId(DispIds.SetImageDisp)]
        [Description("Sets the current Image for the control as an {IPictureDisp}.")]
        new void SetImageDisp(IPictureDisp Image);
        /// <summary>Sets the current Image for the control as a {string} naming an MsoImage.</summary>
        [DispId(DispIds.SetImageMso)]
        [Description("Sets the current Image for the control as a {string} naming an MsoImage.")]
        new void SetImageMso(string ImageMso);
    }
}