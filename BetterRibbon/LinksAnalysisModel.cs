﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using Microsoft.Office.Interop.Excel;

using PGSolutions.RibbonDispatcher.ComClasses;
using PGSolutions.RibbonUtilities.LinksAnalysis;
using PGSolutions.RibbonUtilities.LinksAnalysis.Interfaces;

namespace PGSolutions.BetterRibbon {
    /// <summary>The TabModel for the Links Aalysis Group on the BetterRibbon.</summary>
    internal sealed class LinksAnalysisModel : AbstractRibbonGroupModel {
        public LinksAnalysisModel(RibbonGroupViewModel viewModel, AbstractRibbonTabModel parent) : base(viewModel) {
            AnalyzeCurrentModel  = parent.NewRibbonButtonModel("AnalyzeLinksCurrent", AnalyzeCurrentClicked, true, true, "EditLinks");
            AnalyzeSelectedModel = parent.NewRibbonButtonModel("AnalyzeLinksSelected",AnalyzeSelectedClicked, true, true, "EditLinks");

            Invalidate();
        }

        public RibbonButtonModel AnalyzeCurrentModel  { get; }
        public RibbonButtonModel AnalyzeSelectedModel { get; }

        private void AnalyzeCurrentClicked(object sender, EventArgs e)
        => DisplayAnalysis(parser => parser.ParseWorkbook(Application.ActiveWorkbook));

        private void AnalyzeSelectedClicked(object sender, EventArgs e)
        => DisplayAnalysis(parser => parser.ParseWorkbookList(Application.Selection));

        private void DisplayAnalysis(Func<FormulaParser,ILinksAnalysis> func) {
            Application.Cursor = XlMousePointer.xlWait;
            try {
                var parser = new FormulaParser();
                parser.StatusAvailable += StatusAvailable;
                Application.ActiveWorkbook.WriteLinks(func(parser));
                parser.StatusAvailable -= StatusAvailable;
            }
            finally {
                Application.Cursor = XlMousePointer.xlDefault;
            }
        }

        private void StatusAvailable(object sender, RibbonUtilities.EventArgs<string> e)
        => Application.StatusBar = e.Value;

        private static Application Application => Globals.ThisAddIn.Application;
    }
}
