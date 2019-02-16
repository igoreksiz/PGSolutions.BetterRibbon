﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Text;
using stdole;

using PGSolutions.RibbonDispatcher.ComClasses;
using PGSolutions.RibbonDispatcher.ComInterfaces;
using PGSolutions.RibbonUtilities.VbaSourceExport;

namespace PGSolutions.BetterRibbon {
    internal sealed class BrandingModel : AbstractRibbonGroupModel {
        public BrandingModel(RibbonGroupViewModel viewModel, IPictureDisp image)
        : this(viewModel, image, null) { }

        public BrandingModel(RibbonGroupViewModel viewModel, IPictureDisp image,
                IRibbonControlStrings strings)
        : base(viewModel,strings) {
            BrandingButtonModel = GetModel<RibbonButton>("BrandingButton", ButtonClicked, true, true, image);

            Invalidate();
        }

        private RibbonButtonModel BrandingButtonModel { get; }

        private void ButtonClicked(object sender) => new StringBuilder()
            .AppendLine($"PGSolutions Better Ribbon")
            .AppendLine()
            .AppendLine($"Better Ribbon V {Globals.ThisAddIn.VersionNo3}")
            .AppendLine($"Ribbon Utilities V {UtilitiesVersion.Format2()}")
            .AppendLine($"Ribbon Dispatcher V {DispatcherVersion.Format2()}")
            .AppendLine()
            .AppendLine($"{BrandingButtonModel.ViewModel.SuperTip}")
            .ToString().MsgBoxShow();

        static Version DispatcherVersion => new RibbonFactory().GetType().Assembly.GetName().Version;
        static Version UtilitiesVersion  => new VbaExportEventArgs(null).GetType().Assembly.GetName().Version;
    }
}
