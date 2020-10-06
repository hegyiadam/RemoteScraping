﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserManagement.Wrappers.CefSharpWrapper.JavaScripts
{
    public static class JavaScriptFile
    {
        public const string BasePath = @"Wrappers\CefSharpWrapper\JavaScripts\";
        public const string AutoHighlightControl = BasePath + "AutoHighlightControl.js";
        public const string HighlightControl = BasePath + "HighlightControl.js";
        public const string RemoveHighlightControl = BasePath + "RemoveHighlightControl.js";
        public const string RemoveAutoHighlightControl = BasePath + "RemoveAutoHighlightControl.js";
        public const string GetControlOnMousePosition = BasePath + "GetControlOnMousePosition.js";
        public const string GetSiblingsOnMousePosition = BasePath + "GetSiblingsOnMousePosition.js";
        public const string ImportJQuery = BasePath + "ImportJQuery.js";
    }
}
