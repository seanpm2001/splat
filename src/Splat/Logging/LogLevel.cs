﻿// Copyright (c) 2021 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace Splat;

/// <summary>
/// Represents the minimum log level a <see cref="ILogger"/> will start emitting from.
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// The log message is for debuging purposes.
    /// </summary>
    Debug = 1,

    /// <summary>
    /// The log message is for information purposes.
    /// </summary>
    Info,

    /// <summary>
    /// The log message is for warning purposes.
    /// </summary>
    Warn,

    /// <summary>
    /// The log message is for error purposes.
    /// </summary>
    Error,

    /// <summary>
    /// The log message is for fatal purposes.
    /// </summary>
    Fatal,
}
