// Copyright (c) 2021 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace Splat;

/// <summary>
/// Contains the default mode detector to detect if we are currently in a unit test.
/// </summary>
public class DefaultModeDetector : IModeDetector, IEnableLogger
{
    /// <inheritdoc />
    public bool? InUnitTestRunner()
    {
        var testAssemblies = new[]
        {
            "CSUNIT",
            "NUNIT",
            "XUNIT",
            "MBUNIT",
            "NBEHAVE",
            "VISUALSTUDIO.QUALITYTOOLS",
            "VISUALSTUDIO.TESTPLATFORM",
            "FIXIE",
            "NCRUNCH",
        };

        try
        {
            return SearchForAssembly(testAssemblies);
        }
        catch (Exception e)
        {
            this.Log().Debug(e, "Unable to find unit test runner value");
            return null;
        }
    }

    private static bool SearchForAssembly(IEnumerable<string> assemblyList) =>
        AppDomain.CurrentDomain.GetAssemblies()
            .Select(x => x.FullName?.ToUpperInvariant())
            .Where(x => x is not null)
            .Select(x => x!)
            .Any(x => assemblyList.Any(name => x.IndexOf(name, StringComparison.InvariantCultureIgnoreCase) != -1));
}
