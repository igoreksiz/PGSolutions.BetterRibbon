﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using stdole;

using Microsoft.Office.Core;
using PGSolutions.RibbonDispatcher.ComClasses;
using PGSolutions.RibbonDispatcher.Utilities;
using PGSolutions.RibbonUtilities.LinksAnalyzer;
using PGSolutions.RibbonUtilities.VbaSourceExport;
using BetterRibbon.Properties;

namespace PGSolutions.BetterRibbon {
    /// <summary>The (top-level) ViewModel for the ribbon interface.</summary>
    /// <remarks>
    /// <a href=" https://go.microsoft.com/fwlink/?LinkID=271226">For more information about adding callback methods.</a>
    /// 
    /// Take care renaming this class, or its namespace; and coordinate any such with the content of the (hidden)
    /// ThisAddIn.Designer.xml file. Commit frequently. Excel is very tempermental on the naming of ribbon objects
    /// and provides poor, and very minimal, diagnostic information.
    /// 
    /// This class MUST be ComVisible for the ribbon to launch properly.
    /// </remarks>
    [Description("The (top-level) ViewModel for the ribbon interface.")]
    [ComVisible(true)]
    [CLSCompliant(true)]
    [SuppressMessage("Microsoft.Interoperability", "CA1409:ComVisibleTypesShouldBeCreatable",
        Justification = "Public, Non-Creatable, class with exported Events.")]
    [Guid("A8ED8DFB-C422-4F03-93BF-FB5453D8F213")]
    public sealed class BetterRibbonViewModel : AbstractRibbonViewModel, IRibbonExtensibility {
        const string _assemblyName  = "BetterRibbon";

        internal BetterRibbonViewModel() : base(new LocalResourceManager(_assemblyName)) {
            _id = "TabPGSolutions";    

            BrandingViewModel      = new BrandingViewModel(RibbonFactory, GetBrandingIcon);
            LinksAnalysisViewModel = new LinksAnalysisViewModel(RibbonFactory);
            VbaExportViewModel_PG  = new VbaSourceExportViewModel(RibbonFactory, "MS");
            VbaExportViewModel_MS  = new VbaSourceExportViewModel(RibbonFactory, "PG");
            CustomButtonsViewModel = new CustomizableButtonsViewModel(RibbonFactory);
            DemonstrationViewModel = new DemonstrationViewModel(RibbonFactory);
        }

        internal BrandingViewModel            BrandingViewModel      { get; private set; }
        internal LinksAnalysisViewModel       LinksAnalysisViewModel { get; private set; }
        internal VbaSourceExportViewModel     VbaExportViewModel_MS  { get; private set; }
        internal VbaSourceExportViewModel     VbaExportViewModel_PG  { get; private set; }
        internal DemonstrationViewModel       DemonstrationViewModel { get; private set; }
        internal CustomizableButtonsViewModel CustomButtonsViewModel { get; private set; }

        internal void DetachControls() => CustomButtonsViewModel.DetachControls();

        /// <summary>.</summary>
        public string GetCustomUI(string RibbonID) => Resources.Ribbon;

        /// <summary>.</summary>
        public event EventHandler Initialized;

         /// <summary>.</summary>
       public bool IsInitialized => RibbonUI != null;

        /// <summary>.</summary>
        [SuppressMessage("Microsoft.Design", "CA1061:DoNotHideBaseClassMethods",
                Justification="False positive - parameter types are identical.")]
        [CLSCompliant(false)]
        public sealed override void OnRibbonLoad(IRibbonUI ribbonUI) {
            base.OnRibbonLoad(ribbonUI);

            Initialized?.Invoke(this, EventArgs.Empty);

            Invalidate();
        }

        /// <summary>.</summary>
        protected override string Id => _id; private readonly string _id;

        private static IPictureDisp GetBrandingIcon() => Resources.PGeerkens.ImageToPictureDisp();

        /// <summary>.</summary>
        public static string MsgBoxTitle => Resources.ApplicationName;
    }
}
