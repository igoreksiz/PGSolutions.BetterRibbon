﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

using PGSolutions.RibbonDispatcher.ComInterfaces;
using PGSolutions.RibbonDispatcher.ViewModels;

namespace PGSolutions.RibbonDispatcher.Models {
    using Microsoft.Office.Core;
    using IStrings = IControlStrings;

    /// <summary>The COM visible Model for Ribbon Split (Press) Button controls.</summary>
    [SuppressMessage("Microsoft.Interoperability", "CA1409:ComVisibleTypesShouldBeCreatable")]
    [Description("The COM visible Model for Ribbon Split (Press) Button controls.")]
    [CLSCompliant(true)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(IClickedEvent))]
    [ComDefaultInterface(typeof(ISplitPressButtonModel))]
    [Guid(Guids.SplitPressButtonModel)]
    public class SplitPressButtonModel: AbstractSplitButtonModel<IButtonSource,ISplitPressButtonVM>,
            ISplitPressButtonModel, IButtonSource {
        internal SplitPressButtonModel(Func<string,SplitPressButtonVM> funcViewModel,
                IStrings strings, ButtonModel button, MenuModel menu)
        : base(funcViewModel, strings, menu)
        => Button = button;

        public ISplitPressButtonModel Attach(string controlId) {
            ViewModel = AttachToViewModel(controlId, this);
            if (ViewModel != null) {
                Button.Attach(ViewModel.ButtonVM.Id);
                Menu.Attach(ViewModel.MenuVM.Id);

                Button.ViewModel.Clicked += OnClicked;
            }
            ViewModel?.Invalidate();
            return this;
        }

        public override void Detach() { Button.Detach(); base.Detach(); }

        #region Pressable implementation
        public event ClickedEventHandler Pressed;

        public ButtonModel Button { get; }

        private void OnClicked(IRibbonControl control) => Pressed?.Invoke(control);
        #endregion
    }
}