﻿#region copyright
// -----------------------------------------------------------------------
//  <copyright file="ISqlDialect.cs" creator="Bartosz Sypytkowski">
//      Copyright (C) 2017 Bartosz Sypytkowski <b.sypytkowski@gmail.com>
//  </copyright>
// -----------------------------------------------------------------------
#endregion
namespace Calliope.Sql
{
    public interface ISqlDialect<TRow> where TRow : IEventRow
    {
        
    }
}