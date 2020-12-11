using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// <copyright file="BoolToVisibilityCustomConverterTest.cs">Copyright ©  2020</copyright>

using System;
using System.Globalization;
using WPFBrowserClient.Tests;

namespace WPFBrowserClient.ViewModel.Tests
{
    /// <summary>This class contains parameterized unit tests for BoolToVisibilityCustomConverter</summary>
    [TestClass]
    [PexClass(typeof(BoolToVisibilityCustomConverter))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class BoolToVisibilityCustomConverterTest : TestClassBase
    {
        /// <summary>Test stub for ConvertBack(Object, Type, Object, CultureInfo)</summary>
        [PexMethod]
        public object ConvertBackTest(
            [PexAssumeUnderTest] BoolToVisibilityCustomConverter target,
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture
        )
        {
            object result = target.ConvertBack(value, targetType, parameter, culture);
            return result;
        }

        /// <summary>Test stub for Convert(Object, Type, Object, CultureInfo)</summary>
        [PexMethod]
        public object ConvertTest(
            [PexAssumeUnderTest] BoolToVisibilityCustomConverter target,
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture
        )
        {
            object result = target.Convert(value, targetType, parameter, culture);
            return result;
        }
    }
}