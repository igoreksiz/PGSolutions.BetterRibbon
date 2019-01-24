////////////////////////////////////////////////////////////////////////////////////////////////////
//                             Copyright (c) 2017-2019 Pieter Geerkens                            //
////////////////////////////////////////////////////////////////////////////////////////////////////

// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider",
        MessageId = "System.String.Format(System.String,System.Object)", Scope = "member",
        Target = "PGSolutions.RibbonDispatcher.Concrete.AbstractRibbonViewModel.#Unknown(Microsoft.Office.Core.IRibbonControl)",
        Justification = "False positive.")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider",
        MessageId = "System.String.Format(System.String,System.Object)", Scope = "member",
        Target = "PGSolutions.RibbonDispatcher.Concrete.RibbonCommon.#GetLanguageStrings(System.String,PGSolutions.RibbonDispatcher.ComInterfaces.IResourceManager)",
        Justification = "False positive.")]

[assembly: SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Scope = "type",
        Target = "PGSolutions.RibbonDispatcher.ComInterfaces.IRibbonViewModel",
        Justification = "False positive - used by Mixin.")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type",
        Target = "PGSolutions.RibbonDispatcher.ControlMixins.SizeableMixin+Fields",
        Justification = "False positive - used by Mixin.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Scope = "type",
        Target = "PGSolutions.RibbonDispatcher.ControlMixins.IImageable",
        Justification = "False positive - used by Mixin.")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type",
        Target = "PGSolutions.RibbonDispatcher.ControlMixins.ImageableMixin+Fields",
        Justification = "False positive - used by Mixin.")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type",
        Target = "PGSolutions.RibbonDispatcher.ControlMixins.ToggleableMixin+Fields",
        Justification = "False positive - used by Mixin.")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type",
        Target = "PGSolutions.RibbonDispatcher.ControlMixins.ClickableMixin+Fields",
        Justification = "False positive - used by Mixin.")]
[assembly: SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "mixin", Scope = "member",
        Target = "PGSolutions.RibbonDispatcher.ControlMixins.ClickableMixin.#OnAction(PGSolutions.RibbonDispatcher.ControlMixins.IClickable,System.Action)")]
[assembly: SuppressMessage( "Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "PGSolutions.RibbonDispatcher.ComClasses.RibbonToggleModel.#PGSolutions.RibbonDispatcher.ComInterfaces.IBooleanSource.Getter()" )]

