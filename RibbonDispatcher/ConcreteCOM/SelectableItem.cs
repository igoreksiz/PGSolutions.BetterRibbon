﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using stdole;

using PGSolutions.RibbonDispatcher.AbstractCOM;
using PGSolutions.RibbonDispatcher.ControlMixins;

namespace PGSolutions.RibbonDispatcher.ConcreteCOM {
    /// <summary>TODO</summary>
    [SuppressMessage("Microsoft.Interoperability", "CA1409:ComVisibleTypesShouldBeCreatable",
       Justification = "Public, Non-Creatable, class with exported Events.")]
    [Serializable]
    [CLSCompliant(true)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(ISelectableItem))]
    [Guid(Guids.SelectableItem)]
    public class SelectableItem : RibbonCommon, ISelectableItem, IImageableMixin {
        /// <summary>TODO</summary>
        internal SelectableItem(string ItemId, IResourceManager ResourceManager, ImageObject Image) 
            : base(ItemId, ResourceManager, true, true)
            => this.SetImage(Image);

        #region Publish IImageableMixin to class default interface
        /// <inheritdoc/>
        public object Image => this.GetImage();
        /// <summary>Gets or sets whether the image for this control should be displayed when its size is {rdRegular}.</summary>
        public bool ShowImage {
            get => this.GetShowImage();
            set => this.SetShowImage(value);
        }
        /// <summary>Gets or sets whether the label for this control should be displayed when its size is {rdRegular}.</summary>
        public bool ShowLabel {
            get => this.GetShowLabel();
            set => this.SetShowLabel(value);
        }

        /// <summary>Sets the displayable image for this control to the provided {IPictureDisp}</summary>
        public void SetImageDisp(IPictureDisp Image) => this.SetImage(Image);
        /// <summary>Sets the displayable image for this control to the named ImageMso image</summary>
        public void SetImageMso(string ImageMso)     => this.SetImage(ImageMso);
        #endregion
    }
}