﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using stdole;

using PGSolutions.RibbonDispatcher.AbstractCOM;
using PGSolutions.RibbonDispatcher.Concrete;

namespace PGSolutions.RibbonDispatcher {
    using static RdControlSize;

    /// <summary>The factory interface for the Ribbon DIspatcher.</summary>
    [ComVisible(true)]
    [CLSCompliant(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid(Guids.IRibbonFactory)]
    public interface IRibbonFactory {
        /// <summary>Returns a new Ribbon Group ViewModel instance.</summary>
        [DispId(11)]
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification="Matches COM usage.")]
        RibbonGroup NewRibbonGroup(string ItemId, bool Visible = true, bool Enabled = true);

        /// <summary>Returns a new Ribbon ActionButton ViewModel instance that uses a custom Image (or none).</summary>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification="Matches COM usage.")]
        [DispId(12)]
        RibbonButton NewRibbonButton(string ItemId, bool Visible = true, bool Enabled = true,
            RdControlSize   Size            = rdLarge,
            IPictureDisp    Image           = null,
            bool            ShowImage       = false,
            bool            ShowLabel       = true
        );
        /// <summary>Returns a new Ribbon ActionButton ViewModel instance that uses an Office built-in Image.</summary>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification="Matches COM usage.")]
        [DispId(13)]
        RibbonButton NewRibbonButtonMso(string ItemId, bool Visible = true, bool Enabled = true,
            RdControlSize   Size            = rdLarge,
            string          ImageMso        = "MacroSecurity",  // This one get's peope's attention ;-)
            bool            ShowImage       = false,
            bool            ShowLabel       = true
        );

        /// <summary>Returns a new Ribbon ToggleButton ViewModel instance that uses a custom Image (or none).</summary>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification="Matches COM usage.")]
        [DispId(14)]
        RibbonToggleButton NewRibbonToggle(string ItemId, bool Visible = true, bool Enabled = true,
            RdControlSize   Size            = rdLarge,
            IPictureDisp    Image           = null,
            bool            ShowImage       = false,
            bool            ShowLabel       = true
        );
        /// <summary>Returns a new Ribbon ToggleButton ViewModel instance that uses an Office built-in Image.</summary>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification="Matches COM usage.")]
        [DispId(15)]
        RibbonToggleButton NewRibbonToggleMso(string ItemId, bool Visible = true, bool Enabled = true,
            RdControlSize   Size            = rdLarge,
            string          ImageMso        = "MacroSecurity",  // This one gets people's attention ;-)
            bool            ShowImage       = false,
            bool            ShowLabel       = true
        );

        /// <summary>Returns a new Ribbon CheckBox ViewModel instance.</summary>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification="Matches COM usage.")]
        [DispId(16)]
        RibbonCheckBox NewRibbonCheckBox(string ItemId, bool Visible = true, bool Enabled = true);

        /// <summary>Returns a new Ribbon DropDownViewModel instance.</summary>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification="Matches COM usage.")]
        [DispId(17)]
        RibbonDropDown NewRibbonDropDown(string ItemId, bool Visible = true, bool Enabled = true);

        /// <summary>Returns a new {SelectableItem} from a custom Image (or none).</summary>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        [DispId(18)]
        SelectableItem NewSelectableItem(string ItemId, IPictureDisp Image = null);

        /// <summary>Returns a new {SelectableItem} from an Office built-in Image.</summary>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        [DispId(19)]
        SelectableItem NewSelectableItemMso(string ItemId, string ImageMso = "MacroSecurity");
    }
}
