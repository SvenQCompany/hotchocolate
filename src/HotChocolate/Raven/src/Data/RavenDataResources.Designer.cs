﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotChocolate.Data.Raven {
    using System;


    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class RavenDataResources {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RavenDataResources() {
        }

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("HotChocolate.Data.Raven.RavenDataResources", typeof(RavenDataResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to The provided value for filter `{0}` of type {1} is invalid. Null values are not supported..
        /// </summary>
        internal static string ErrorHelper_CreateNonNullError {
            get {
                return ResourceManager.GetString("ErrorHelper_CreateNonNullError", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to RavenQueryableCombinator {0} could not combine expression. {1} is an invalid combinator..
        /// </summary>
        internal static string Filtering_RavenQueryableCombinator_InvalidCombinator {
            get {
                return ResourceManager.GetString("Filtering_RavenQueryableCombinator_InvalidCombinator", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Sorting needs a expression with exactly one parameter of type {0}! This error occured on {1}.{2}: {3}.
        /// </summary>
        internal static string QueryableSorting_ExpressionParameterInvalid {
            get {
                return ResourceManager.GetString("QueryableSorting_ExpressionParameterInvalid", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Sorting needs a member of type PropertyInfo or MethodInfo but received {0}! This error occured on {1}.{2}: {3}.
        /// </summary>
        internal static string QueryableSorting_MemberInvalid {
            get {
                return ResourceManager.GetString("QueryableSorting_MemberInvalid", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Sorting needs a member of type PropertyInfo or MethodInfo no member was found! This error occured on {0}.{1}: {2}.
        /// </summary>
        internal static string QueryableSorting_NoMemberDeclared {
            get {
                return ResourceManager.GetString("QueryableSorting_NoMemberDeclared", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Sorting is in a invalid state. The parent was no sort field selector. This error occured on {0}.{1}: {2}.
        /// </summary>
        internal static string Sorting_InvalidState_ParentIsNoFieldSelector {
            get {
                return ResourceManager.GetString("Sorting_InvalidState_ParentIsNoFieldSelector", resourceCulture);
            }
        }
    }
}
