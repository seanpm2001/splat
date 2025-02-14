﻿// Copyright (c) 2021 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if !WINDOWS_UWP && !ANDROID

namespace Splat.Tests.ApplicationPerformanceMonitoring;

/// <summary>
/// Unit Tests for Exceptionless Feature Usage Tracking.
/// </summary>
public static class ExceptionlessFeatureUsageTrackingSessionTests
{
    /// <inheritdoc />>
    public sealed class ConstructorTests : BaseFeatureUsageTrackingTests.BaseConstructorTests<ExceptionlessFeatureUsageTrackingSession>
    {
        /// <inheritdoc/>
        protected override ExceptionlessFeatureUsageTrackingSession GetFeatureUsageTrackingSession(string featureName) => new(featureName);
    }

    /// <inheritdoc />>
    public sealed class SubFeatureMethodTests : BaseFeatureUsageTrackingTests.BaseSubFeatureMethodTests<ExceptionlessFeatureUsageTrackingSession>
    {
        /// <inheritdoc/>
        protected override ExceptionlessFeatureUsageTrackingSession GetFeatureUsageTrackingSession(string featureName) => new(featureName);
    }
}

#endif
