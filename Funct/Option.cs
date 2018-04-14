using System;

namespace Option
{
    public static partial class F
    {
        public static Option.None None => Option.None.Default;
        public static Option.Some<T> Some<T>(T value) => new Option.Some<T>(value);
    }

    public struct Option<T>
    {
        private T _value;
        private bool _isSome;

        private Option(T value)
        {
            _value = value;
            _isSome = true;
        }

        public static implicit operator Option<T>(Option.None _) => new Option<T>();
        public static implicit operator Option<T>(Option.Some<T> some) => new Option<T>(some.Value);
        public static implicit operator Option<T>(T value) => value == null ? new Option<T>() : new Option<T>(value);

        public R Match<R>(Func<R> none, Func<T, R> some)
            => _isSome ? some(_value) : none();
    }

    namespace Option
    {
        public struct None
        {
            internal static readonly None Default = new None();
        }

        public struct Some<T>
        {
            internal T Value { get; }

            internal Some(T value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                Value = value;
            }
        }
    }
}
