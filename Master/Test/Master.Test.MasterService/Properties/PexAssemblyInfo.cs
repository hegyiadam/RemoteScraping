// <copyright file="PexAssemblyInfo.cs">Copyright ©  2020</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("MasterService")]
[assembly: PexInstrumentAssembly("Scheduler")]
[assembly: PexInstrumentAssembly("System.Configuration")]
[assembly: PexInstrumentAssembly("MongoDB.Driver")]
[assembly: PexInstrumentAssembly("System.Core")]
[assembly: PexInstrumentAssembly("PythonComponents")]
[assembly: PexInstrumentAssembly("System.Web.Http.Owin")]
[assembly: PexInstrumentAssembly("MongoDB.Driver.Core")]
[assembly: PexInstrumentAssembly("System.Net.Http")]
[assembly: PexInstrumentAssembly("Microsoft.Owin.Hosting")]
[assembly: PexInstrumentAssembly("Swashbuckle.Core")]
[assembly: PexInstrumentAssembly("System.Web.Http.Cors")]
[assembly: PexInstrumentAssembly("WebActivatorEx")]
[assembly: PexInstrumentAssembly("System.Web.Http")]
[assembly: PexInstrumentAssembly("Newtonsoft.Json")]
[assembly: PexInstrumentAssembly("HubComponents")]
[assembly: PexInstrumentAssembly("MongoDB.Bson")]
[assembly: PexInstrumentAssembly("ComponentInterfaces")]
[assembly: PexInstrumentAssembly("Owin")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Scheduler")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Configuration")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "MongoDB.Driver")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "PythonComponents")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Web.Http.Owin")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "MongoDB.Driver.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Net.Http")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Microsoft.Owin.Hosting")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Swashbuckle.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Web.Http.Cors")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "WebActivatorEx")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Web.Http")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Newtonsoft.Json")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "HubComponents")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "MongoDB.Bson")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "ComponentInterfaces")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "Owin")]