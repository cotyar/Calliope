﻿#region copyright
//-----------------------------------------------------------------------
// <copyright file="IPartiallyComparable.cs" creator="Bartosz Sypytkowski">
//     Copyright (C) 2017 Bartosz Sypytkowski <b.sypytkowski@gmail.com>
// </copyright>
//-----------------------------------------------------------------------
#endregion
namespace Calliope
{
    /// <summary>
    /// Interface for types, that implements partial comparison. 
    /// Those types can contain a state, that is not always valid to compare.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPartiallyComparable<in T>
    {
        int? PartiallyCompareTo(T other);
    }

    /// <summary>
    /// Interface for comparer type, that can be used to implement partial comparison of types.
    /// Those types can contain a state, that is not always valid to compare.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPartialComparer<in T>
    {
        int? PartiallyCompare(T x, T y);
    }
}