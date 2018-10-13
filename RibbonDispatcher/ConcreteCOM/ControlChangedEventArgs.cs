﻿using System;
using System.Runtime.InteropServices;

using PGSolutions.RibbonDispatcher.AbstractCOM;

namespace PGSolutions.RibbonDispatcher.ConcreteCOM {
    /// <summary>TODO</summary>
    [CLSCompliant(true)]
    internal delegate void ChangedEventHandler(object sender, ControlChangedEventArgs e);

    /// <summary>TODO</summary>
    [Serializable]
    [CLSCompliant(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IControlChangedEventArgs))]
    internal class ControlChangedEventArgs : EventArgs, IControlChangedEventArgs {
        /// <summary>TODO</summary>
        public ControlChangedEventArgs(string controlId) => ControlId = controlId;
        /// <summary>TODO</summary>
        public string ControlId { get; }
    }
}