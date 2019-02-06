﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Diagnostics.CodeAnalysis;

using PGSolutions.RibbonDispatcher.ComInterfaces;
using PGSolutions.RibbonDispatcher.ComClasses;

namespace PGSolutions.BetterRibbon {
    internal class LinksAnalysisViewModel : AbstractRibbonGroupViewModel {
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon)")]
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
        public LinksAnalysisViewModel(IRibbonFactory factory) : base(factory) {
            LinksAnalysisGroup    = Factory.NewRibbonGroup("LinksAnalysisGroup", true);
            AnalyzeCurrentButton  = Factory.NewRibbonButtonMso(itemId:"AnalyzeLinksCurrent",  imageMso:"Refresh");
            AnalyzeSelectedButton = Factory.NewRibbonButtonMso(itemId:"AnalyzeLinksSelected", imageMso:"RefreshAll");

            AnalyzeCurrentButton.Clicked += OnAnalyzeCurrentClicked;
            AnalyzeCurrentButton.Attach();

            AnalyzeSelectedButton.Clicked += OnAnalyzeSelectedClicked;
            AnalyzeSelectedButton.Attach();
        }

        public event ClickedEventHandler  AnalyzeCurrentClicked;
        public event ClickedEventHandler  AnalyzeSelectedClicked;

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public RibbonGroup  LinksAnalysisGroup    { get; }
        public RibbonButton AnalyzeCurrentButton  { get; }
        public RibbonButton AnalyzeSelectedButton { get; }

        public void Invalidate() => LinksAnalysisGroup.Invalidate();

        private void OnAnalyzeCurrentClicked(object sender) => AnalyzeCurrentClicked?.Invoke(sender);
        private void OnAnalyzeSelectedClicked(object sender) => AnalyzeSelectedClicked?.Invoke(sender);
    }
}
