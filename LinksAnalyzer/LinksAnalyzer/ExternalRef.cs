﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                                Copyright (c) 2018 Pieter Geerkens                              //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Runtime.InteropServices;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

using PGSolutions.LinksAnalyzer.Interfaces;

namespace PGSolutions.LinksAnalyzer {
    /// <summary>TODO</summary>
    [Serializable]
    [CLSCompliant(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(ICellRef))]
    public class ExternalRef : ICellRef {
        internal ExternalRef(string formula, ISourceCellRef source, ISourceCellRef target) {
            Formula = formula;
            Source = source;
            Target = target;
        }

        public string Formula { get; }
        public string TargetPath => Target.FullPath;
        public string TargetFile => Target.FileName;
        public string TargetTab  => Target.TabName;
        public string TargetCell => Target.CellName;

        public string SourcePath => Source.FullPath;
        public string SourceFile => Source.FileName;
        public string SourceTab  => Source.TabName;
        public string SourceCell => Source.CellName;

        public ISourceCellRef Source { get; }
        public ISourceCellRef Target { get; }
    }
}
