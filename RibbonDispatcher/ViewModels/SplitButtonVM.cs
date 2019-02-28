﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using Microsoft.Office.Core;

namespace PGSolutions.RibbonDispatcher.ViewModels {
    internal abstract class SplitButtonVM<TSource,TVM>: AbstractContainerVM<TSource,TVM>, ISplitButtonVM,
            IActivatable<TSource,TVM>, ISizeableVM, IImageableVM
        where TSource: IImageSizeSource where TVM:class,ISplitButtonVM {
        public SplitButtonVM(ViewModelFactory factory, string itemId, IMenuVM menu)
        : base(factory,itemId)
        => MenuVM = menu;

        public IMenuVM   MenuVM   { get; }

        public override void Invalidate() { MenuVM?.Invalidate(); base.Invalidate(); }

        /// <inheritdoc/>
        public override void Detach() { MenuVM.Detach(); base.Detach(); }

        #region ISizeable implementation
        /// <inheritdoc/>
        public bool IsLarge => Source?.IsLarge ?? false;
        #endregion

        #region IImageable implementation
        /// <inheritdoc/>
        public ImageObject Image => Source?.Image ?? "MacroSecurity";

        /// <inheritdoc/>
        public bool ShowImage => Source?.ShowImage ?? (Source?.Image != null);

        /// <inheritdoc/>
        public bool ShowLabel => Source?.ShowLabel ?? true;
        #endregion
    }

    internal class SplitToggleButtonVM: SplitButtonVM<IToggleSource,ISplitToggleButtonVM>, ISplitToggleButtonVM,
            IActivatable<IToggleSource,ISplitToggleButtonVM>, IToggleableVM {
        public SplitToggleButtonVM(ViewModelFactory factory, string itemId, IMenuVM menu, IToggleVM toggle)
        : base(factory, itemId, menu)
        => ToggleVM = toggle;

        #region IActivatable implementation
        /// <inheritdoc/>
        public override ISplitToggleButtonVM Attach(IToggleSource source) => Attach<SplitToggleButtonVM>(source);

        /// <inheritdoc/>
        public override void Invalidate() { ToggleVM?.Invalidate(); base.Invalidate(); }

        /// <inheritdoc/>
        public override void Detach() { Toggled = null; ToggleVM.Detach(); base.Detach(); }
        #endregion

        #region IToggleable implementation
        /// <inheritdoc/>
        public event ToggledEventHandler Toggled;

        /// <inheritdoc/>
        public IToggleVM ToggleVM { get; }

        /// <inheritdoc/>>
        public bool IsPressed => Source?.IsPressed ?? false;

        /// <inheritdoc/>>
        public void OnToggled(IRibbonControl control, bool isPressed)
        => Toggled?.Invoke(control,isPressed);
        #endregion
    }

    internal class SplitPressButtonVM: SplitButtonVM<IButtonSource,ISplitPressButtonVM>, ISplitPressButtonVM,
            IActivatable<IButtonSource,ISplitPressButtonVM>, IClickableVM {
        public SplitPressButtonVM(ViewModelFactory factory, string itemId, IMenuVM menu, IButtonVM button)
        : base(factory, itemId, menu)
        => ButtonVM = button;

        #region IActivatable implementation
        /// <inheritdoc/>
        public override ISplitPressButtonVM Attach(IButtonSource source) => Attach<SplitPressButtonVM>(source);

        /// <inheritdoc/>
        public override void Invalidate() { ButtonVM?.Invalidate(); base.Invalidate(); }

        /// <inheritdoc/>
        public override void Detach() { Clicked = null; ButtonVM.Detach(); base.Detach(); }
        #endregion

        #region IClickable implementation
        /// <inheritdoc/>
        public event ClickedEventHandler Clicked;

        public IButtonVM ButtonVM { get; }

        /// <inheritdoc/>
        public virtual void OnClicked(IRibbonControl control) => Clicked?.Invoke(control);
        #endregion
    }
}