using System;

namespace Morts.StringExtensions
{
    /// <summary>
    /// Represents a string that cannot be whitespace only, and must contain at least one char.
    /// </summary>
    public readonly struct ValueString : IEquatable<ValueString>, IEquatable<string>
    {
        private readonly string _value;

        /// <summary>
        /// Use the implicit operator instead.
        /// </summary>
        /// <param name="value"></param>
        public ValueString(string value)
        {
            _value = value.ReturnOrThrowIfNullEmptyOrWhitespace(nameof(value));
        }

        /// <summary>
        /// Converts the <see cref="ValueString"/> to a <see cref="string"/>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator string(ValueString value) => value.ToString();

        /// <summary>
        /// Converts the <see cref="string"/> to a <see cref="ValueString"/>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ValueString(string value) => new ValueString(value);

        /// <summary>
        /// Returns the value of the encapsulated <see cref="string"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _value;
        }

        /// <summary>
        /// Compare to <see cref="ValueString"/>
        /// </summary>
        public bool Equals(ValueString other) => Equals(other._value);

        /// <summary>
        /// Compare to <see cref="ValueString"/> using a <see cref="StringComparison"/>
        /// </summary>
        public bool Equals(ValueString other, StringComparison comparison) => Equals(other._value, comparison);

        /// <summary>
        /// Compare to <see cref="string"/>
        /// </summary>
        public bool Equals(string other) => _value.Equals(other);

        /// <summary>
        /// Compare to <see cref="string"/> using a <see cref="StringComparison"/>
        /// </summary>
        public bool Equals(string other, StringComparison comparison) => _value.Equals(other, comparison);

        /// <summary>
        /// Compare to <see cref="object"/>
        /// </summary>
        public override bool Equals(object other) => other is ValueString o ? Equals(o._value) : _value.Equals(other);

        /// <summary>
        /// Gets the hashcode from the encapsulated string
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => _value.GetHashCode();
    }
}
