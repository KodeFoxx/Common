﻿using System;
using System.Collections.Generic;
using System.Linq;
using Kf.Common.Comparison.Ranges;
using Kf.Common.Comparison.Ranges.Numbers;
using Kf.Common.Tests.Infrastructure;
using Xunit;

namespace Kf.Common.Tests.Comparison.Ranges.Numbers
{
    public class Int32RangeTests
    {
        [Fact]
        public void Implements_IRange_interface()
            => AssertExtensions.ImplementsInterface<IRange<int>>(
                0.ToRange(1)
            );

        private static IEnumerable<object[]> AsEnumerableTestData() {            
            return new List<object[]> {

                new object[] {
                    0.ToRange(0), new [] { 0 }
                },
                new object[] {
                    (-60).ToRange(-60), new [] { -60 }
                },

                new object[] {
                    0.ToRange(10),
                    new [] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
                },

                new object[] {
                    (-5).ToRange(5),
                    new [] { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 }
                },                
            };            
        }

        [Theory,
         MemberData(nameof(AsEnumerableTestData))]
        public void AsEnumerable_returns_correct_values(IRange<int> sut, IEnumerable<int> expected) {            
            Assert.NotNull(sut.AsEnumerable());
            Assert.Equal(expected.Count(), sut.AsEnumerable().Count());
            Assert.Equal(expected, sut.AsEnumerable());
        }
    }
}
