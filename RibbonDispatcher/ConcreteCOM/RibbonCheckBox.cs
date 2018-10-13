﻿using System;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

using PGSolutions.RibbonDispatcher.ControlMixins;
using PGSolutions.RibbonDispatcher.AbstractCOM;

namespace PGSolutions.RibbonDispatcher.ConcreteCOM {
    /// <summary>The ViewModel for Ribbon CheckBox objects.</summary>
    [SuppressMessage("Microsoft.Interoperability", "CA1409:ComVisibleTypesShouldBeCreatable",
        Justification = "Public, Non-Creatable, class with exported Events.")]
    [Serializable]
    [CLSCompliant(true)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IToggledEvents))]
    [ComDefaultInterface(typeof(IRibbonCheckBox))]
    [Guid(Guids.RibbonCheckBox)]
    public class RibbonCheckBox : RibbonCommon, IRibbonCheckBox, IToggleableMixin {
        internal RibbonCheckBox(string itemId, IResourceManager mgr, bool visible, bool enabled)
            : base(itemId, mgr, visible, enabled) {
        }

        #region Publish IToggleableMixin to class default interface
        /// <summary>TODO</summary>
        public event ToggledEventHandler Toggled;

        /// <summary>TODO</summary>
        public          bool   IsPressed => this.GetPressed();

        /// <summary>TODO</summary>
        public override string Label     => this.GetLabel();

        /// <summary>TODO</summary>
        public void OnToggled(bool IsPressed) => Toggled?.Invoke(IsPressed);

        /// <summary>TODO</summary>
        IRibbonTextLanguageControl IToggleableMixin.LanguageStrings => LanguageStrings;
        #endregion
    }
}