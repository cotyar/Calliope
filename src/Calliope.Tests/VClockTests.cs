﻿#region copyright
// -----------------------------------------------------------------------
//  <copyright file="VClockTests.cs" creator="Bartosz Sypytkowski">
//      Copyright (C) 2017 Bartosz Sypytkowski <b.sypytkowski@gmail.com>
//  </copyright>
// -----------------------------------------------------------------------
#endregion

using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Calliope.Tests
{
    public class VClockTests
    {
        public const int A = 1;

        public const int B = 2;

        public const int C = 3;

        [Fact]
        public void VectorTime_should_be_mergeable()
        {
            var t1 = new VClock(new KeyValuePair<int, long>(A, 1), new KeyValuePair<int, long>(B, 2), new KeyValuePair<int, long>(C, 2));
            var t2 = new VClock(new KeyValuePair<int, long>(A, 4), new KeyValuePair<int, long>(C, 1));

            t1.Merge(t2).Should().Be(new VClock(new KeyValuePair<int, long>(A, 4), new KeyValuePair<int, long>(B, 2), new KeyValuePair<int, long>(C, 2)));
            t2.Merge(t1).Should().Be(new VClock(new KeyValuePair<int, long>(A, 4), new KeyValuePair<int, long>(B, 2), new KeyValuePair<int, long>(C, 2)));
        }

        [Fact]
        public void VectorTime_should_conform_to_partial_ordering()
        {
            var t1 = new VClock(new KeyValuePair<int, long>(A, 1), new KeyValuePair<int, long>(B, 2));
            var t2 = new VClock(new KeyValuePair<int, long>(A, 1), new KeyValuePair<int, long>(B, 1));
            var t3 = new VClock(new KeyValuePair<int, long>(A, 2), new KeyValuePair<int, long>(B, 1));
            var t4 = new VClock(new KeyValuePair<int, long>(A, 1), new KeyValuePair<int, long>(B, 2), new KeyValuePair<int, long>(C, 2));
            var t5 = new VClock(new KeyValuePair<int, long>(A, 1), new KeyValuePair<int, long>(C, 2));
            var t6 = new VClock(new KeyValuePair<int, long>(A, 1), new KeyValuePair<int, long>(C, 0));

            Assert(t1, t1, eq: true, conc: false, lt: false, lteq: true, gt: false, gteq: true);
            Assert(t1, t2, eq: false, conc: false, lt: false, lteq: false, gt: true, gteq: true);
            Assert(t2, t1, eq: false, conc: false, lt: true, lteq: true, gt: false, gteq: false);
            Assert(t1, t3, eq: false, conc: true, lt: false, lteq: false, gt: false, gteq: false);
            Assert(t3, t1, eq: false, conc: true, lt: false, lteq: false, gt: false, gteq: false);
            Assert(t1, t4, eq: false, conc: false, lt: true, lteq: true, gt: false, gteq: false);
            Assert(t4, t1, eq: false, conc: false, lt: false, lteq: false, gt: true, gteq: true);
            Assert(t1, t5, eq: false, conc: true, lt: false, lteq: false, gt: false, gteq: false);
            Assert(t5, t1, eq: false, conc: true, lt: false, lteq: false, gt: false, gteq: false);
            Assert(t1, t6, eq: false, conc: false, lt: false, lteq: false, gt: true, gteq: true);
            Assert(t6, t1, eq: false, conc: false, lt: true, lteq: true, gt: false, gteq: false);
        }

        private void Assert(VClock t1, VClock t2, bool eq, bool conc, bool lt, bool lteq, bool gt, bool gteq)
        {
            (t1 == t2).Should().Be(eq, "{0} should be equal to {1}", t1, t2);
            (t1.IsConcurrent(t2)).Should().Be(conc, "{0} should be concurrent to {1}", t1, t2);
            (t1 < t2).Should().Be(lt, "{0} should be less than {1}", t1, t2);
            (t1 <= t2).Should().Be(lteq, "{0} should be less or equal to {1}", t1, t2);
            (t1 > t2).Should().Be(gt, "{0} should be greater than {1}", t1, t2);
            (t1 >= t2).Should().Be(gteq, "{0} should be greater or equal to {1}", t1, t2);
        }
    }
}