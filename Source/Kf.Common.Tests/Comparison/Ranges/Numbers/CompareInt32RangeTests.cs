﻿using Kf.Common.Comparison.Ranges;
using Kf.Common.Comparison.Ranges.Numbers;
using Kf.Common.Tests.Infrastructure;
using Xunit;

namespace Kf.Common.Tests.Comparison.Ranges.Numbers
{
    public class CompareInt32RangeTests
    {
        [Fact]
        public void Implements_IRange_interface()
            => AssertExtensions.ImplementsInterface<ICompareRange<int>>(
                new CompareInt32Range()
            );

        [Fact]
        public void IsInRange_With_Value_In_Range_Returns_True() {
            IRange<int> range = 0.ToRange(100);
            var sut = new CompareInt32Range();
            Assert.True(sut.IsInRange(10, range));
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_With_Minimum_Excluded_Returns_True()
        {
            IRange<int> range = 0.ToRange(100, RangeComparisonOptions.Create().WithMinimumExcluded());
            var sut = new CompareInt32Range();
            Assert.True(sut.IsInRange(1, range));            
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_With_Maximum_Excluded_Returns_True()
        {                        
            IRange<int> range = 0.ToRange(100, RangeComparisonOptions.Create().WithMaximumExcluded());
            var sut = new CompareInt32Range();
            Assert.True(sut.IsInRange(99, range));            
        }

        [Fact]
        public void IsInRange_With_Value_In_Range_On_Edge_Returns_True()
        {
            IRange<int> range = 0.ToRange(100);
            var sut = new CompareInt32Range();
            Assert.True(sut.IsInRange(0, range));                       
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_Returns_False()
        {
            IRange<int> range = 0.ToRange(100);
            var sut = new CompareInt32Range();
            Assert.False(sut.IsInRange(-5, range));            
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_With_Minimum_Excluded_Returns_False()
        {            
            IRange<int> range = 0.ToRange(100, RangeComparisonOptions.Create().WithMinimumExcluded());
            var sut = new CompareInt32Range();
            Assert.False(sut.IsInRange(0, range));
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_With_Maximum_Excluded_Returns_False()
        {
            IRange<int> range = 0.ToRange(100, RangeComparisonOptions.Create().WithMaximumExcluded());
            var sut = new CompareInt32Range();
            Assert.False(sut.IsInRange(100, range));            
        }

        [Fact]
        public void IsInRange_With_Value_Not_In_Range_On_Edge_Returns_False()
        {
            IRange<int> range = 0.ToRange(100);
            var sut = new CompareInt32Range();
            Assert.False(sut.IsInRange(-1, range));
        }
    }
}
