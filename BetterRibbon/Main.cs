﻿////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

using PGSolutions.RibbonDispatcher.ComClasses;
using PGSolutions.RibbonDispatcher.ComInterfaces;
using PGSolutions.RibbonUtilities.LinksAnalysis;

namespace PGSolutions.BetterRibbon {
    /// <summary>The publicly available entry points to the library.</summary>
    [SuppressMessage( "Microsoft.Interoperability", "CA1409:ComVisibleTypesShouldBeCreatable" )]
    [Serializable, CLSCompliant(true)]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IBetterRibbon))]
    [Guid(RibbonDispatcher.Guids.BetterRibbonMain)]
    [ProgId(ProgIds.RibbonDispatcherProgId)]
    public sealed class Main : IBetterRibbon {
        internal Main(Func<IResourceLoader,IModelFactory> funcFactory) => FuncFactory = funcFactory;

        Func<IResourceLoader,IModelFactory> FuncFactory { get; }

        /// <inheritdoc/>
        public IModelFactory NewBetterRibbon(IResourceLoader manager) => FuncFactory(manager);

        /// <inheritdoc/>
        public ILinksAnalyzer NewLinksAnalyzer() => new LinksAnalyzer();
    }
}
