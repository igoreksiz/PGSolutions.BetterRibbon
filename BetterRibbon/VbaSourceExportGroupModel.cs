﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                                Copyright (c) 2017-8 Pieter Geerkens                              //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;

using PGSolutions.RibbonDispatcher.ComClasses;
using PGSolutions.RibbonDispatcher.ComInterfaces;
using PGSolutions.RibbonUtilities.LinksAnalysis;

namespace PGSolutions.BetterRibbon {
    internal sealed class VbaSourceExportGroupModel : AbstractRibbonGroupModel {
        public VbaSourceExportGroupModel(RibbonGroupViewModel viewModel, AbstractRibbonTabModel parent, string suffix)
        : base(viewModel) {
            Suffix = suffix;

            DestIsSrc      = parent.NewRibbonToggleModel($"UseSrcFolderToggle{suffix}", OnUseSrcFolderToggled, true, true, false.ToggleImage());
            ExportSelected = parent.NewRibbonButtonModel($"SelectedProjectButton{suffix}", OnExportSelected, true, true, "SaveAll");
            ExportCurrent  = parent.NewRibbonButtonModel($"CurrentProjectButton{suffix}", OnExportCurrent, true, true, "FileSaveAs");

            Invalidate();
        }

        public event EventHandler<EventArgs<bool>> UseSrcFolderToggled;
        public event EventHandler ExportSelectedClicked;
        public event EventHandler ExportCurrentClicked;

        public RibbonToggleModel DestIsSrc      { get; }

        public RibbonButtonModel ExportSelected { get; }

        public RibbonButtonModel ExportCurrent  { get; }

        public string            Suffix         { get; }

        private void OnUseSrcFolderToggled(object sender, bool isPressed)
        => UseSrcFolderToggled?.Invoke(sender, new EventArgs<bool>(isPressed));

        private void OnExportCurrent(object sender, EventArgs e)  => ExportCurrentClicked?.Invoke(sender,e);

        private void OnExportSelected(object sender, EventArgs e) => ExportSelectedClicked?.Invoke(sender,e);
    }
}
