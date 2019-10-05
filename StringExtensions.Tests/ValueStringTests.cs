using FluentAssertions;
using Morts.StringExtensions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;

namespace StringExtensions.Tests
{
    public class ValueStringTests
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void ValueString_InputIsEmpty_ShouldThrow()
        {
            //ARRANGE
            var input = string.Empty;
            //ACT
            Action act = () => new ValueString(input);

            //ASSERT
            act.Should()
                .ThrowExactly<ArgumentException>()
                .And
                .Message
                .Should()
                .Contain("empty");
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void ValueString_InputIsNull_ShouldThrow()
        {
            //ARRANGE
            var input = (string)null;

            //ACT
            Action act = () => new ValueString(input);

            //ASSERT
            act.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .Message
                .Should()
                .Contain("null");
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void ValueString_InputIsWhitespace_ShouldThrow()
        {
            //ARRANGE
            var input = "   ";

            //ACT
            Action act = () => new ValueString(input);

            //ASSERT
            act.Should()
                .ThrowExactly<ArgumentException>()
                .And
                .Message
                .Should()
                .Contain("whitespace");
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void ValueString_InputIsNotNullEmptyOrWhitespace_ShouldNotThrow()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";

            //ACT
            Action act = () => new ValueString(input);

            //ASSERT
            act.Should()
                .NotThrow();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Equal_ComparedToString_ShouldBeEqual()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input);

            //ACT

            var result = valueString.Equals(input);

            //ASSERT
            result.Should().BeTrue();
        }

        [Theory]
        [Trait("Category", "Unit")]
        [InlineData(StringComparison.Ordinal)]
        [InlineData(StringComparison.OrdinalIgnoreCase)]
        [InlineData(StringComparison.CurrentCulture)]
        [InlineData(StringComparison.CurrentCultureIgnoreCase)]
        [InlineData(StringComparison.InvariantCulture)]
        [InlineData(StringComparison.InvariantCultureIgnoreCase)]
        public void Equal_ComparedToStringWithStringComparison_ShouldBeEqual(StringComparison comparison)
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input);

            //ACT

            var result = valueString.Equals(input, comparison);

            //ASSERT
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Equal_ComparedToString_ShouldNotBeEqual()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input + "123");

            //ACT

            var result = valueString.Equals(input);

            //ASSERT
            result.Should().BeFalse();
        }

        [Theory]
        [Trait("Category", "Unit")]
        [InlineData(StringComparison.Ordinal)]
        [InlineData(StringComparison.OrdinalIgnoreCase)]
        [InlineData(StringComparison.CurrentCulture)]
        [InlineData(StringComparison.CurrentCultureIgnoreCase)]
        [InlineData(StringComparison.InvariantCulture)]
        [InlineData(StringComparison.InvariantCultureIgnoreCase)]
        public void Equal_ComparedToStringWithStringComparison_ShouldNotBeEqual(StringComparison comparison)
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input + "123");

            //ACT

            var result = valueString.Equals(input, comparison);

            //ASSERT
            result.Should().BeFalse();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Equal_ComparedToValueString_ShouldBeEqual()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input);
            var otherValueString = new ValueString(input);

            //ACT

            var result = valueString.Equals(otherValueString);

            //ASSERT
            result.Should().BeTrue();
        }

        [Theory]
        [Trait("Category", "Unit")]
        [InlineData(StringComparison.Ordinal)]
        [InlineData(StringComparison.OrdinalIgnoreCase)]
        [InlineData(StringComparison.CurrentCulture)]
        [InlineData(StringComparison.CurrentCultureIgnoreCase)]
        [InlineData(StringComparison.InvariantCulture)]
        [InlineData(StringComparison.InvariantCultureIgnoreCase)]
        public void Equal_ComparedToValueStringWithStringComparison_ShouldBeEqual(StringComparison comparison)
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input);
            var otherValueString = new ValueString(input);

            //ACT

            var result = valueString.Equals(otherValueString, comparison);

            //ASSERT
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Equal_ComparedToValueString_ShouldBeNotEqual()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input);
            var otherValueString = new ValueString(input + "123");

            //ACT

            var result = valueString.Equals(otherValueString);

            //ASSERT
            result.Should().BeFalse();
        }

        [Theory]
        [Trait("Category", "Unit")]
        [InlineData(StringComparison.Ordinal)]
        [InlineData(StringComparison.OrdinalIgnoreCase)]
        [InlineData(StringComparison.CurrentCulture)]
        [InlineData(StringComparison.CurrentCultureIgnoreCase)]
        [InlineData(StringComparison.InvariantCulture)]
        [InlineData(StringComparison.InvariantCultureIgnoreCase)]
        public void Equal_ComparedToValueStringWithStringComparison_ShouldNotBeEqual(StringComparison comparison)
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input);
            var otherValueString = new ValueString(input + "123");

            //ACT

            var result = valueString.Equals(otherValueString, comparison);

            //ASSERT
            result.Should().BeFalse();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Equal_ComparedToValueStringAsObject_ShouldBeEqual()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input);
            var otherObject = (object)new ValueString(input);

            //ACT

            var result = valueString.Equals(otherObject);

            //ASSERT
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Equal_ComparedToStringAsObject_ShouldBeEqual()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input);

            //ACT

            var result = valueString.Equals((object)input);

            //ASSERT
            result.Should().BeTrue();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Equal_ComparedToValueStringAsObject_ShouldNotBeEqual()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input);
            var otherObject = (object)new ValueString(input + "123");

            //ACT

            var result = valueString.Equals(otherObject);

            //ASSERT
            result.Should().BeFalse();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Equal_ComparedToNullObject_ShouldNotBeEqual()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input);
            var otherObject = (string)null;

            //ACT

            var result = valueString.Equals(otherObject);

            //ASSERT
            result.Should().BeFalse();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetHashCode_ComparedToString_ShouldBeEqual()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input);

            //ACT

            var result = valueString.GetHashCode();

            //ASSERT
            input.GetHashCode().Should().Be(result);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void GetHashCode_ComparedToString_ShouldNotBeEqual()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input + "123");

            //ACT

            var result = valueString.GetHashCode();

            //ASSERT
            input.GetHashCode().Should().NotBe(result);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void ToString_StringsAreTheSame_ShouldBeEqual()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input);

            //ACT

            var result = valueString.ToString();

            //ASSERT
            result.Should().Be(input);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void ToString_StringsAreNotTheSame_ShouldNotBeEqual()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input + "123");

            //ACT

            var result = valueString.ToString();

            //ASSERT
            result.Should().NotBe(input);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Implicit_StringsAreTheSame_ShouldBeEqual()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var valueString = new ValueString(input);

            //ACT

            var result = GetString(valueString);

            //ASSERT
            result.Should().Be(input);

            static string GetString(ValueString value) => value;
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Implicit_StringsAreNotTheSame_ShouldNotBeEqual()
        {
            //ARRANGE
            var input = "Morts.StringExtensions";
            var expected = new ValueString(input);

            //ACT

            var result = GetValueString(input);

            //ASSERT
            result.Should().BeEquivalentTo(expected);

            static ValueString GetValueString(string value) => value;
        }


    }
}
