﻿#region copyright
// -----------------------------------------------------------------------
//  <copyright file="LSeq.cs" creator="Bartosz Sypytkowski">
//      Copyright (C) 2017 Bartosz Sypytkowski <b.sypytkowski@gmail.com>
//  </copyright>
// -----------------------------------------------------------------------
#endregion

using System.Collections.Immutable;

namespace Calliope.Collections
{
    public class LSeq<T> : ICommutative
    {
        #region operations

        

        #endregion

        public ImmutableArray<T> Value { get; }
    }
}