﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Deployment.Application;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;

using PGSolutions.RibbonDispatcher;
using PGSolutions.RibbonDispatcher.Models;

namespace PGSolutions.BetterRibbon {

    /// <summary>.</summary>
    /// <remarks>
    /// <a href=" https://go.microsoft.com/fwlink/?LinkID=271226"> For more information about adding callback methods.</a>
    /// 
    /// Take care renaming this class, or its namespace; and coordinate any such with the content
    /// of the (hidden) ThisAddIn.Designer.xml file. Commit frequently. Excel is very tempermental
    /// on the naming of ribbon objects and provides poor, and very minimal, diagnostic information.
    /// </remarks>
    [CLSCompliant(false)]
    public partial class ThisAddIn {
        private void ThisAddIn_Startup(object sender, EventArgs e) {
            Dispatcher.Initialized += ViewModel_Initialized;

            Application.WorkbookActivate    += Workbook_Activate;
            Application.WorkbookBeforeSave  += Workbook_BeforeSave;
            Application.WorkbookAfterSave   += Workbook_AfterSave;
            Application.WorkbookBeforeClose += Workbook_Close;
        }

        internal Dispatcher      Dispatcher { get; private set; } = new Dispatcher();
        internal RibbonViewModel ViewModel  { get; private set; }
        internal RibbonModel     Model      { get; private set; }
        private  ComEntry        ComEntry   => new ComEntry(Dispatcher.NewModelFactory);

        /// <inheritdoc/>
        protected override IRibbonExtensibility CreateRibbonExtensibilityObject() => Dispatcher;

        /// <inheritdoc/>
        protected override object RequestComAddInAutomationService() => ComEntry as IComEntry;

        private void ViewModel_Initialized(object sender, EventArgs e) {
            Dispatcher.Initialized -= ViewModel_Initialized;

            Dispatcher.RegisterWorkbook(":");
            ViewModel = new RibbonViewModel(Dispatcher);
            Model = new RibbonModel(ViewModel, new MyResourceManager().GetControlStrings);

            ViewModel.RibbonUI?.InvalidateControl(ViewModel.ControlId);
        }

        internal void RegisterWorkbook(string workbookName)
        => Dispatcher.RegisterWorkbook(workbookName);

        private void Workbook_Activate(Workbook wb)
        => Dispatcher.RegisterWorkbook(wb.Name);

        private void Workbook_BeforeSave(Workbook wb, bool SaveAsUI, ref bool Cancel)
        => Dispatcher.FloatCurrent();

        private void Workbook_AfterSave(Workbook wb, bool Success)
        => Dispatcher.SaveCurrent(wb.Name);

        private void Workbook_Close(Workbook wb, ref bool Cancel) {
            Dispatcher.FloatCurrent();
//            Dispatcher.RegisterWorkbook(":");
        }

        private void ThisAddIn_Shutdown(object sender, EventArgs e) { }

        /// <summary>.</summary>
        public static string VersionNo => ApplicationDeployment.IsNetworkDeployed
            ? ApplicationDeployment.CurrentDeployment.CurrentVersion?.Format()
            : new Version(0,0,0,0).Format();

        /// <summary>.</summary>
        public static string VersionNo2 => System.Windows.Forms.Application.ProductVersion;

        /// <summary>.</summary>
        public static string VersionNo3 => typeof(ThisAddIn).Assembly.GetName().Version?.Format();

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
