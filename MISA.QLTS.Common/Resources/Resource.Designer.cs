﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISA.QLTS.Common.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MISA.QLTS.Common.Resources.Resource", typeof(Resource).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tên tài sản không được để trống.
        /// </summary>
        public static string EmptyAssetName {
            get {
                return ResourceManager.GetString("EmptyAssetName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã tài sản không được để trống.
        /// </summary>
        public static string EmptyCode {
            get {
                return ResourceManager.GetString("EmptyCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã tài sản đã tồn tại.
        /// </summary>
        public static string ErrorDuplicate {
            get {
                return ResourceManager.GetString("ErrorDuplicate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Lỗi khi gọi vào DL.
        /// </summary>
        public static string ErrorToDL {
            get {
                return ResourceManager.GetString("ErrorToDL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ngày không được vượt quá ngày hiện tại.
        /// </summary>
        public static string FormatDate {
            get {
                return ResourceManager.GetString("FormatDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp.
        /// </summary>
        public static string SystemError {
            get {
                return ResourceManager.GetString("SystemError", resourceCulture);
            }
        }
    }
}
