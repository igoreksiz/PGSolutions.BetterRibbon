﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using Microsoft.Office.Interop.Excel;

using PGSolutions.RibbonDispatcher.ComClasses;
using PGSolutions.RibbonUtilities;
using PGSolutions.RibbonUtilities.LinksAnalysis;
using PGSolutions.RibbonUtilities.LinksAnalysis.Interfaces;

namespace PGSolutions.BetterRibbon {
    using IRibbonControlStrings = RibbonDispatcher.ComInterfaces.IRibbonControlStrings;

    internal sealed class LinksAnalysisModel : AbstractRibbonGroupModel {
        public LinksAnalysisModel(RibbonGroupViewModel viewModel) : this(viewModel,null) { }
        public LinksAnalysisModel(RibbonGroupViewModel viewModel, IRibbonControlStrings strings)
        : base(viewModel,strings) {
            AnalyzeCurrentModel  = NewButtonModel("AnalyzeLinksCurrent", AnalyzeCurrentClicked, true, true, "EditLinks");
            AnalyzeSelectedModel = NewButtonModel("AnalyzeLinksSelected",AnalyzeSelectedClicked, true, true, "EditLinks");
            EnableBackgroundMode = NewToggleModel("BackgroundModeToggle", BackgroundModeToggled, true, true, "EditLinks");

            Invalidate();
        }

        public RibbonToggleModel EnableBackgroundMode { get; }
        public RibbonButtonModel AnalyzeCurrentModel  { get; }
        public RibbonButtonModel AnalyzeSelectedModel { get; }

        public override void Invalidate() {
            EnableBackgroundMode?.SetImageMso(EnableBackgroundMode?.IsPressed.ToggleImage());
            base.Invalidate();
        }

        private void BackgroundModeToggled(object sender, bool isPressed) => Invalidate();

        private void AnalyzeCurrentClicked(object sender)
        => DisplayAnalysis(parser => parser.ParseWorkbook(Application.ActiveWorkbook));

        private void AnalyzeSelectedClicked(object sender)
        => DisplayAnalysis(parser => parser.ParseWorkbookList(Application.Selection, EnableBackgroundMode.IsPressed));

        private void DisplayAnalysis(Func<FormulaParser,ILinksAnalysis> func) {
            var parser = new FormulaParser();
            parser.StatusAvailable += StatusAvailable;
            Application.ActiveWorkbook.WriteLinks(func(parser));
            parser.StatusAvailable -= StatusAvailable;
        }

        private void StatusAvailable(object sender, EventArgs<string> e)
        => Application.StatusBar = e.Value;

        private static Application Application => Globals.ThisAddIn.Application;
    }
}
