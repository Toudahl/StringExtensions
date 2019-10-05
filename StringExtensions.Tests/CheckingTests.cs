using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Morts.StringExtensions;
using Xunit;

namespace StringExtensions.Tests
{
    public class CheckingTests
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void IsEmpty_InputIsNull_ShouldThrow()
        {
            //ARRANGE
            var input = (string) null;

            //ACT
            Action act = () => input.IsEmpty();

            //ASSERT
            act.Should().ThrowExactly<NullReferenceException>();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void IsWhitespace_InputIsNull_ShouldThrow()
        {
            //ARRANGE
            var input = (string) null;

            //ACT
            Action act = () => input.IsWhitespace();

            //ASSERT
            act.Should().ThrowExactly<NullReferenceException>();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void IsWhitespace_InputIsEmpty_ShouldThrow()
        {
            //ARRANGE
            var input = string.Empty;

            //ACT
            Action act = () => input.IsWhitespace();

            //ASSERT
            act.Should().ThrowExactly<IndexOutOfRangeException>();
        }

        [ExcludeFromCodeCoverage]
        public static IEnumerable<object[]> OnlyWhiteSpace => new List<object[]>
        {
            new object[]{" "},
            new object[]{"  "},
            new object[]{"   "},
            new object[]{"             "},
        };

        [Theory]
        [Trait("Category", "Unit")]
        [MemberData(nameof(OnlyWhiteSpace))]
        public void IsWhitespace_OnlyWhitespace_ShouldBeTrue(string input)
        {
            //ACT
            var result = input.IsWhitespace();

            //ASSERT
            result.Should().BeTrue();
        }

        [ExcludeFromCodeCoverage]
        public static IEnumerable<object[]> NotOnlyWhitespace => new List<object[]>
        {
            new object[]{" a"},
            new object[]{" a "},
            new object[]{"adfdaf"},
            new object[]{"adfdaf "},
            new object[]{" adfdaf"},
            new object[]{" adfdaf "},
            new object[]{" adfdaf  "},
            new object[]{"  adfdaf "},
            new object[]{"          a"},
            new object[]{"a          "},
        };

        [Theory]
        [Trait("Category", "Unit")]
        [MemberData(nameof(NotOnlyWhitespace))]
        public void IsWhitespace_NotOnlyWhitespace_ShouldBeFalse(string input)
        {
            //ACT
            var result = input.IsWhitespace();

            //ASSERT
            result.Should().BeFalse();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void IsNull_InputIsNull_ShouldBeTrue()
        {
            //ARRANGE
            var input = (string)null;

            //ACT
            var result = input.IsNull();

            //ASSERT
            result.Should().BeTrue();
        }

        [ExcludeFromCodeCoverage]
        public static IEnumerable<object[]> NotNullInput => new List<object[]>
        {
            new object[]{string.Empty},
            new object[]{" "},
            new object[]{"adfd"},
        };

        [Theory]
        [Trait("Category", "Unit")]
        [MemberData(nameof(NotNullInput))]
        public void IsNull_InputIsNotNull_ShouldBeFalse(string input)
        {
            //ACT
            var result = input.IsNull();

            //ASSERT
            result.Should().BeFalse();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void IsEmpty_InputIsEmpty_ShouldBeTrue()
        {
            //ARRANGE
            var input = string.Empty;

            //ACT
            var result = input.IsEmpty();

            //ASSERT
            result.Should().BeTrue();
        }

        [ExcludeFromCodeCoverage]
        public static IEnumerable<object[]> NotEmptyInput => new List<object[]>
        {
            new object[]{" "},
            new object[]{"adfd"},
        };

        [Theory]
        [Trait("Category", "Unit")]
        [MemberData(nameof(NotEmptyInput))]
        public void IsEmpty_InputIsNotEmpty_ShouldBeFalse(string input)
        {
            //ACT
            var result = input.IsEmpty();

            //ASSERT
            result.Should().BeFalse();
        }

        [ExcludeFromCodeCoverage]
        public static IEnumerable<object[]> IsNotNullEmptyOrWhitespace => new List<object[]>
        {
            new object[]{" a"},
            new object[]{" a "},
            new object[]{"adfdaf"},
            new object[]{"adfdaf "},
            new object[]{" adfdaf"},
            new object[]{" adfdaf "},
            new object[]{" adfdaf  "},
            new object[]{"  adfdaf "},
            new object[]{"          a"},
            new object[]{"a          "},
        };

        [Theory]
        [Trait("Category", "Unit")]
        [MemberData(nameof(IsNotNullEmptyOrWhitespace))]
        public void IsNullEmptyOrWhitespace_IsNotNullEmptyOrWhitespace_ShouldBeFalse(string input)
        {
            //ACT
            var result = input.IsNullEmptyOrWhitespace();

            //ASSERT
            result.Should().BeFalse();
        }

        [ExcludeFromCodeCoverage]
        public static IEnumerable<object[]> IsEmptyOrWhitespace => new List<object[]>
        {
            new object[]{null},
            new object[]{string.Empty},
            new object[]{" "},
            new object[]{"  "},
            new object[]{"   "},
            new object[]{"             "},
        };

        [Theory]
        [Trait("Category", "Unit")]
        [MemberData(nameof(IsEmptyOrWhitespace))]
        public void IsNullEmptyOrWhitespace_InputIsNullEmptyOrWhitespace_ShouldBeTrue(string input)
        {
            //ACT
            var result = input.IsNullEmptyOrWhitespace();

            //ASSERT
            result.Should().BeTrue();
        }
    }
}
