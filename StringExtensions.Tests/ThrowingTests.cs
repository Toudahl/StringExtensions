using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Morts.StringExtensions;
using Xunit;

namespace StringExtensions.Tests
{
    public class ThrowingTests
    {
        [ExcludeFromCodeCoverage]
        public static IEnumerable<object[]> ParameterNames => new List<object[]>
        {
            new object[]{"something"},
            new object[]{" "},
            new object[]{null},
            new object[]{string.Empty},
        };

        [Theory]
        [Trait("Category", "Unit")]
        [MemberData(nameof(ParameterNames))]
        public void ThrowIfWhiteSpace_ExceptionIsThrown_ParamNameShouldBeSetCorrectly(string expectedParameterName)
        {
            //ARRANGE
            var input = " ";

            //ACT
            Action act = () => input.ThrowIfWhitespace(expectedParameterName);

            //ASSERT
            act.Should()
                .Throw<ArgumentException>()
                .And
                .ParamName
                .Should()
                .Be(expectedParameterName);
        }

        [Theory]
        [Trait("Category", "Unit")]
        [MemberData(nameof(ParameterNames))]
        public void ThrowIfNull_ExceptionIsThrown_ParamNameShouldBeSetCorrectly(string expectedParameterName)
        {
            //ARRANGE
            var input = (string)null;

            //ACT
            Action act = () => input.ThrowIfNull(expectedParameterName);

            //ASSERT
            act.Should()
                .Throw<ArgumentException>()
                .And
                .ParamName
                .Should()
                .Be(expectedParameterName);
        }

        [Theory]
        [Trait("Category", "Unit")]
        [MemberData(nameof(ParameterNames))]
        public void ThrowIfEmpty_ExceptionIsThrown_ParamNameShouldBeSetCorrectly(string expectedParameterName)
        {
            //ARRANGE
            var input = string.Empty;

            //ACT
            Action act = () => input.ThrowIfEmpty(expectedParameterName);

            //ASSERT
            act.Should()
                .Throw<ArgumentException>()
                .And
                .ParamName
                .Should()
                .Be(expectedParameterName);
        }

        [Theory]
        [Trait("Category", "Unit")]
        [MemberData(nameof(ParameterNames))]
        public void ThrowIfNullEmptyOrWhitespace_ExceptionIsThrown_ParamNameShouldBeSetCorrectly(string expectedParameterName)
        {
            //ARRANGE
            var input = " ";

            //ACT
            Action act = () => input.ThrowIfNullEmptyOrWhitespace(expectedParameterName);

            //ASSERT
            act.Should()
                .Throw<ArgumentException>()
                .And
                .ParamName
                .Should()
                .Be(expectedParameterName);
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
        public void ThrowIfWhitespace_OnlyWhitespace_ShouldThrow(string input)
        {
            //ACT
            Action act = () => input.ThrowIfWhitespace(input);

            //ASSERT
            act.Should()
                .ThrowExactly<ArgumentException>();
        }

        [ExcludeFromCodeCoverage]
        public static IEnumerable<object[]> NotOnlyWhitespace => new List<object[]>
        {
            new object[]{string.Empty},
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
        public void ThrowIfWhitespace_NotOnlyWhitespace_ShouldNotThrow(string input)
        {
            //ACT
            Action act = () => input.ThrowIfWhitespace(input);

            //ASSERT
            act.Should()
                .NotThrow();
        }

        [ExcludeFromCodeCoverage]
        public static IEnumerable<object[]> NullOrEmpty => new List<object[]>
        {
            new object[]{string.Empty},
            new object[]{null},
        };

        [Theory]
        [Trait("Category", "Unit")]
        [MemberData(nameof(NullOrEmpty))]
        public void ThrowIfWhitespace_NullOrEmpty_ShouldNotThrow(string input)
        {
            //ACT
            Action act = () => input.ThrowIfWhitespace(input);

            //ASSERT
            act.Should()
                .NotThrow();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void ThrowIfNull_InputIsNull_ShouldThrow()
        {
            //ARRANGE
            var input = (string) null;

            //ACT
            Action act = () => input.ThrowIfNull(null);

            //ASSERT
            act.Should()
                .ThrowExactly<ArgumentNullException>();
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
        public void ThrowIfNull_InputIsNotNull_ShouldNotThrow(string input)
        {
            //ACT
            Action act = () => input.ThrowIfNull(input);

            //ASSERT
            act.Should()
                .NotThrow();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void ThrowIfEmpty_InputIsEmpty_ShouldThrow()
        {
            //ARRANGE
            var input = string.Empty;

            //ACT
            Action act = () => input.ThrowIfEmpty(null);

            //ASSERT
            act.Should()
                .ThrowExactly<ArgumentException>();
        }

        [ExcludeFromCodeCoverage]
        public static IEnumerable<object[]> NotEmptyInput => new List<object[]>
        {
            new object[]{null},
            new object[]{" "},
            new object[]{"adfd"},
        };

        [Theory]
        [Trait("Category", "Unit")]
        [MemberData(nameof(NotEmptyInput))]
        public void ThrowIfEmpty_InputIsNotEmpty_ShouldNotThrow(string input)
        {
            //ACT
            Action act = () => input.ThrowIfEmpty(input);

            //ASSERT
            act.Should()
                .NotThrow();
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
        public void ThrowIfNullEmptyOrWhitespace_IsNotNullEmptyOrWhitespace_ShouldNotThrow(string input)
        {
            //ACT
            Action act = () => input.ThrowIfNullEmptyOrWhitespace(input);

            //ASSERT
            act.Should()
                .NotThrow();
        }

        [ExcludeFromCodeCoverage]
        public static IEnumerable<object[]> IsEmptyOrWhitespace => new List<object[]>
        {
            new object[]{string.Empty},
            new object[]{" "},
            new object[]{"  "},
            new object[]{"   "},
            new object[]{"             "},
        };

        [Theory]
        [Trait("Category", "Unit")]
        [MemberData(nameof(IsEmptyOrWhitespace))]
        public void ThrowIfNullEmptyOrWhitespace_IsEmptyOrWhitespace_ShouldThrow(string input)
        {
            //ACT
            Action act = () => input.ThrowIfNullEmptyOrWhitespace(input);

            //ASSERT
            act.Should()
                .ThrowExactly<ArgumentException>();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void ThrowIfNullEmptyOrWhitespace_IsNull_ShouldThrow()
        {
            //ARRANGE
            var input = (string) null;
            //ACT
            Action act = () => input.ThrowIfNullEmptyOrWhitespace(input);

            //ASSERT
            act.Should()
                .ThrowExactly<ArgumentNullException>();
        }
    }
}
