﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Diagnostics.CodeAnalysis;
using stdole;

using PGSolutions.RibbonDispatcher.ComInterfaces;
using PGSolutions.RibbonDispatcher.ViewModels;

namespace PGSolutions.RibbonDispatcher.ComClasses {
    using IStrings = IControlStrings;
    using IStrings2 = IControlStrings2;

    /// <summary>COM-visible implementation of the interface <see cref="IModelFactory"/>.</summary>
    public class ModelFactory : AbstractModelFactory, IModelFactory {
        /// <summary>.</summary>
        internal ModelFactory(ViewModelFactory viewModelFactory, IResourceLoader manager)
        : base(viewModelFactory, manager) { }

        /// <inheritdoc/>
        public void DetachProxy(string controlId) => ViewModelFactory.GetControl<IControlVM>(controlId).Detach();

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        public IStrings NewControlStrings(string label, string screenTip, string superTip, string keyTip)
        => new ControlStrings(label, screenTip, superTip, keyTip);

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        public IStrings2 NewControlStrings2(string label, string screenTip, string superTip, string keyTip,
                string description)
        =>  new ControlStrings2(label, screenTip, superTip, keyTip, description);

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        public new IGroupModel NewGroupModel(string stringsId, bool isEnabled = true, bool isVisible = true)
        => base.NewGroupModel(stringsId, isEnabled, isVisible);

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        public IButtonModel NewButtonModel(string stringsId,
                IPictureDisp image = null, bool isEnabled = true, bool isVisible = true)
        => base.NewButtonModel(stringsId, new ImageObject(image), isEnabled, isVisible);

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        public IButtonModel NewButtonModelMso(string stringsId,
                string imageMso = "MacroSecurity", bool isEnabled = true, bool isVisible = true)
        => base.NewButtonModel(stringsId, new ImageObject(imageMso), isEnabled, isVisible);

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        public IToggleModel NewToggleModel(string stringsId,
                IPictureDisp image = null, bool isEnabled = true, bool isVisible = true)
        => base.NewToggleModel(stringsId, new ImageObject(image), isEnabled, isVisible);

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        public IToggleModel NewToggleModelMso(string stringsId,
                string imageMso = "MacroSecurity", bool isEnabled = true, bool isVisible = true)
        => base.NewToggleModel(stringsId, new ImageObject(imageMso), isEnabled, isVisible);

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        public new IComboBoxModel NewComboBoxModel(string stringsId, bool isEnabled = true, bool isVisible = true)
        => base.NewComboBoxModel(stringsId, isEnabled, isVisible);

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        public new IEditBoxModel NewEditBoxModel(string stringsId, bool isEnabled = true, bool isVisible = true)
        => base.NewEditBoxModel(stringsId, isEnabled, isVisible);

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        public new IDropDownModel NewDropDownModel(string stringsId, bool isEnabled = true, bool isVisible = true)
        => base.NewDropDownModel(stringsId, isEnabled, isVisible);

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        public new ILabelModel NewLabelModel(string stringsId, bool isEnabled = true, bool isVisible = true)
        => base.NewLabelModel(stringsId, isEnabled, isVisible);

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        public new IMenuModel NewMenuModel(string stringsId, bool isEnabled = true, bool isVisible = true)
        => base.NewMenuModel(stringsId, isEnabled, isVisible);

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        public new ISplitButtonModel NewSplitToggleButtonModel(string splitStringId, string menuStringId,
                string toggleStringId, bool isEnabled = true, bool isVisible = true)
        => base.NewSplitToggleButtonModel(splitStringId, menuStringId, toggleStringId, isEnabled, isVisible);

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Matches COM usage.")]
        public new ISplitButtonModel NewSplitPressButtonModel(string splitStringId, string menuStringId,
                string buttonStringId, bool isEnabled = true, bool isVisible = true)
        => base.NewSplitPressButtonModel(splitStringId, menuStringId, buttonStringId,  isEnabled, isVisible);

        /// <inheritdoc/>
        public new ISelectableItemModel NewSelectableModel(string controlID)
        => base.NewSelectableModel(controlID);
    }
}
