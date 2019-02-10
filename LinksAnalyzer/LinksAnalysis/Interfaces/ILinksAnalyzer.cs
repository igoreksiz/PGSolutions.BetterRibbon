﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;
using Workbook  = Microsoft.Office.Interop.Excel.Workbook;
using Worksheet = Microsoft.Office.Interop.Excel.Worksheet;

using PGSolutions.RibbonUtilities.LinksAnalysis.Interfaces;

namespace PGSolutions.RibbonUtilities.LinksAnalysis {
    /// <summary>TODO</summary>
    [ComVisible(true)]
    [CLSCompliant(false)]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid(Guids.ILinksAnalyzer)]
    public interface ILinksAnalyzer {
        /// <summary>Attaches an {IIntegerSource} to the specified DropDown control.</summary>
        /// <param name="controlId">The ID of the control to be attached to the specified data source.</param>
        /// <param name="strings">The text strings to be displayed for this control.</param>
        /// <returns></returns>
        [Description( "Attaches an {IIntegerSource} to the specified DropDown control." )]
        [DispId(1)]
        ILinksLexer NewLinksLexer(ISourceCellRef cellRef, string formula);

        /// <summary>.</summary>
        /// <param name="excel"></param>
        /// <param name="nameList"></param>
        IExternalLinks NewExternalLinks(Excel.Application excel, INameList nameList);

        /// <summary>.</summary>
        /// <param name="excel"></param>
        /// <param name="nameList"></param>
        IExternalLinks NewExternalLinksWB(Workbook wb, string excludedName);

        /// <summary>.</summary>
        /// <param name="excel"></param>
        /// <param name="nameList"></param>
        IExternalLinks NewExternalLinksWS(Worksheet ws);

        /// <summary>.</summary>
        /// <param name="excel"></param>
        /// <param name="nameList"></param>
        IExternalLinks Parse(ISourceCellRef cellRef, string formula);

        /// <summary></summary>
        /// <param name="wb"></param>
        void WriteLinksAnalysisWB(Workbook wb);

        /// <summary></summary>
        /// <param name="wb"></param>
        /// <param name="nameList"></param>
        void WriteLinksAnalysisFiles(Workbook wb, Range range);
    }
}