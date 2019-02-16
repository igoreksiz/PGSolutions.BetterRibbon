﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Diagnostics.CodeAnalysis;

using PGSolutions.RibbonDispatcher.ComClasses;
using PGSolutions.RibbonDispatcher.ComInterfaces;
using stdole;

namespace PGSolutions.BetterRibbon {
    [CLSCompliant(false)]
    public abstract class AbstractRibbonGroupModel : IRibbonCommonSource {
        protected AbstractRibbonGroupModel(RibbonGroupViewModel viewModel, IRibbonControlStrings strings) {
            ViewModel = (viewModel as IActivatable<RibbonGroupViewModel, IRibbonCommonSource>)
                      ?.Attach(this);
            Strings = strings;
            Invalidate();
        }

        public bool IsEnabled    { get; set; } = true;
        public bool IsVisible    { get; set; } = true;
        public bool ShowInactive { get; private set; } = true;

        private RibbonGroupViewModel ViewModel { get; }

        public void Invalidate() => ViewModel.Invalidate();

        public void SetShowInactive(bool showInactive) {
            ShowInactive = showInactive;
            Invalidate();
        }

        public IRibbonControlStrings Strings { get; }

        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        protected RibbonButtonModel GetModel<T>(string id, ClickedEventHandler handler, bool isEnabled,
                bool isVisible, string imageMso)
        where T : RibbonButton {
            var model = new RibbonButtonModel(
                    ViewModel.Add<IRibbonButtonSource>(ViewModel.Factory.NewRibbonButton(id))
                            .GetControl<T>, GetStrings(id), isEnabled, isVisible);
            model.SetImageMso(imageMso);
            model?.Attach(id);
            model.Clicked += handler;
            return model;
        }

        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        protected RibbonButtonModel GetModel<T>(string id, ClickedEventHandler handler, bool isEnabled,
                bool isVisible, IPictureDisp image)
        where T : RibbonButton {
            var model = new RibbonButtonModel(
                    ViewModel.Add<IRibbonButtonSource>(ViewModel.Factory.NewRibbonButton(id))
                            .GetControl<T>, GetStrings(id), isEnabled, isVisible);
            model.SetImageDisp(image);
            model?.Attach(id);
            model.Clicked += handler;
            return model;
        }

        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        protected RibbonToggleModel GetModel<T>(string id, ToggledEventHandler handler, bool isEnabled,
                bool isVisible, string imageMso)
        where T : RibbonToggleButton {
            var model = new RibbonToggleModel(
                    ViewModel.Add<IRibbonToggleSource>(ViewModel.Factory.NewRibbonToggle(id))
                            .GetControl<T>, GetStrings(id), isEnabled, isVisible);
            model.SetImageMso(imageMso);
            model?.Attach(id);
            model.Toggled += handler;
            return model;
        }

        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        protected RibbonToggleModel GetModel<T>(string id, ToggledEventHandler handler, bool isEnabled,
                bool isVisible, IPictureDisp image)
        where T : RibbonToggleButton {
            var model = new RibbonToggleModel(
                    ViewModel.Add<IRibbonToggleSource>(ViewModel.Factory.NewRibbonToggle(id))
                            .GetControl<T>, GetStrings(id), isEnabled, isVisible);
            model.SetImageDisp(image);
            model?.Attach(id);
            model.Toggled += handler;
            return model;
        }

        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        protected RibbonDropDownModel GetModel<T>(string id, SelectedEventHandler handler, bool isEnabled,
                bool isVisible)
        where T : RibbonDropDown {
            var model = new RibbonDropDownModel(
                    ViewModel.Add<IRibbonDropDownSource>(ViewModel.Factory.NewRibbonDropDown(id))
                            .GetControl<T>, GetStrings(id), isEnabled, isVisible);
            model?.Attach(id);
            model.SelectionMade += handler;
            return model;
        }

        IRibbonControlStrings GetStrings(string id)
        => ViewModel.Factory.ResourceManager.GetControlStrings(id);
    }
}
