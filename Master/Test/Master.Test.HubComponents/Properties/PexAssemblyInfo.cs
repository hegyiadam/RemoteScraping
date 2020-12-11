// <copyright file="PexAssemblyInfo.cs">Copyright ©  2020</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("HubComponents")]
[assembly: PexInstrumentAssembly("Microsoft.Owin.Hosting")]
[assembly: PexInstrumentAssembly("Owin")]
[assembly: PexInstrumentAssembly("Microsoft.Owin.Cors")]
[assembly: PexInstrumentAssembly("Microsoft.CSharp")]
[assembly: PexInstrumentAssembly("PythonComponents")]
[assembly: PexInstrumentAssembly("Microsoft.AspNet.SignalR.Core")]
[assembly: PexInstrumentAssembly("Microsoft.Owin")]
[assembly: PexInstrumentAssembly("System.Core")]
[assembly: PexInstrumentAssembly("ComponentInterfaces")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.Owin.Hosting")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Owin")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.Owin.Cors")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.CSharp")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "PythonComponents")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.AspNet.SignalR.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.Owin")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "ComponentInterfaces")]