﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using stdole;
using System;

namespace PGSolutions.RibbonDispatcher.ComClasses {
    /// <summary>TODO</summary>
    [Serializable]
    internal class ImageObject {
        /// <summary>TODO</summary>
        public ImageObject(string imageMso)    => Image = imageMso;
        /// <summary>TODO</summary>
        public ImageObject(IPictureDisp image) => Image = image;

        /// <summary>TODO</summary>
        public object Image { get; }
    }
}
