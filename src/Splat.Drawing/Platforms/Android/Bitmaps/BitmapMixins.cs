﻿// Copyright (c) 2021 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace Splat;

/// <summary>
/// Extension methods to assist with dealing with Bitmaps.
/// </summary>
public static class BitmapMixins
{
    /// <summary>
    /// Converts <see cref="IBitmap"/> to a native type.
    /// </summary>
    /// <param name="value">The bitmap to convert.</param>
    /// <returns>A <see cref="Drawable"/> bitmap.</returns>
    public static Drawable ToNative(this IBitmap value)
    {
        switch (value)
        {
            case null:
                throw new System.ArgumentNullException(nameof(value));
            case AndroidBitmap androidBitmap:
                return new BitmapDrawable(Application.Context.Resources, androidBitmap.Inner);
            default:
                return ((DrawableBitmap)value).Inner;
        }
    }

    /// <summary>
    /// Converts a <see cref="Bitmap"/> to a splat <see cref="IBitmap"/>.
    /// </summary>
    /// <param name="value">The native bitmap to convert from.</param>
    /// <param name="copy">Whether to copy the android bitmap or not.</param>
    /// <returns>A <see cref="IBitmap"/> bitmap.</returns>
    public static IBitmap FromNative(this Bitmap value, bool copy = false)
    {
        if (value is null)
        {
            throw new System.ArgumentNullException(nameof(value));
        }

        if (copy)
        {
            var copiedBitmap = value.Copy(value.GetConfig(), true) ?? throw new InvalidOperationException("The bitmap does not have a valid reference.");
            return new AndroidBitmap(copiedBitmap);
        }

        return new AndroidBitmap(value);
    }

    /// <summary>
    /// Converts a <see cref="Drawable"/> to a splat <see cref="IBitmap"/>.
    /// </summary>
    /// <param name="value">The native bitmap to convert from.</param>
    /// <returns>A <see cref="IBitmap"/> bitmap.</returns>
    public static IBitmap FromNative(this Drawable value) => new DrawableBitmap(value);
}
