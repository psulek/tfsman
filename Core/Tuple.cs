/*namespace TFSManager.Core
{
    #region class Tuple<TFirst, TSecond>

    /// <summary>
    /// Represents a functional tuple that can be used to store 
    /// two values of different types inside one object.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first element</typeparam>
    /// <typeparam name="TSecond">The type of the second element</typeparam>
    public class Tuple<TFirst, TSecond>
    {
        /// <summary>
        /// Returns the first element of the tuple
        /// </summary>
        public TFirst First { get; private set; }

        /// <summary>
        /// Returns the second element of the tuple
        /// </summary>
        public TSecond Second { get; private set; }

        /// <summary>
        /// Create a new tuple value
        /// </summary>
        /// <param name="first">First element of the tuple</param>
        /// <param name="second">Second element of the tuple</param>
        internal Tuple(TFirst first, TSecond second)
        {
            this.First = first;
            this.Second = second;
        }

        /// <summary>
        /// Returns a tuple with the first element set to the specified value.
        /// </summary>
        /// <param name="nsnd">A new value for the first element</param>
        /// <returns>A new tuple with modified first element</returns>
        public Tuple<TFirst, TSecond> WithFirst(TFirst nfst)
        {
            return Tuple.Create(nfst, this.Second);
        }

        /// <summary>
        /// Returns a tuple with the second element set to the specified value.
        /// </summary>
        /// <param name="nsnd">A new value for the second element</param>
        /// <returns>A new tuple with modified second element</returns>
        public Tuple<TFirst, TSecond> WithSecond(TSecond nsnd)
        {
            return Tuple.Create(this.First, nsnd);
        }
    }

    #endregion

    #region class Tuple<TFirst, TSecond, TThird>

    /// <summary>
    /// Represents a functional tuple that can be used to store
    /// two values of different types inside one object.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first element</typeparam>
    /// <typeparam name="TSecond">The type of the second element</typeparam>
    /// <typeparam name="TThird">The type of the third element.</typeparam>
    public class Tuple<TFirst, TSecond, TThird> : Tuple<TFirst, TSecond>
    {
        /// <summary>
        /// Returns the third element of the tuple
        /// </summary>
        public TThird Third { get; private set; }

        internal Tuple(TFirst first, TSecond second, TThird third)
            : base(first, second)
        {
            this.Third = third;
        }
    }

    #endregion

    #region class Tuple<TFirst, TSecond, TThird, TFourth>

    /// <summary>
    /// Represents a functional tuple that can be used to store
    /// two values of different types inside one object.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first element</typeparam>
    /// <typeparam name="TSecond">The type of the second element</typeparam>
    /// <typeparam name="TThird">The type of the third element.</typeparam>
    /// <typeparam name="TFourth">The type of the fourth element.</typeparam>
    public class Tuple<TFirst, TSecond, TThird, TFourth> : Tuple<TFirst, TSecond, TThird>
    {
        /// <summary>
        /// Returns the fourth element of the tuple
        /// </summary>
        public TFourth Fourth { get; private set; }

        internal Tuple(TFirst first, TSecond second, TThird third, TFourth fourth)
            : base(first, second, third)
        {
            this.Fourth = fourth;
        }
    }

    #endregion


    /// <summary>
    /// Utility class that simplifies cration of tuples by using 
    /// method calls instead of constructor calls
    /// </summary>
    public static class Tuple
    {
        /// <summary>
        /// Creates a new tuple value with the specified elements. The method 
        /// can be used without specifying the generic parameters, because C#
        /// compiler can usually infer the actual types.
        /// </summary>
        /// <param name="first">First element of the tuple</param>
        /// <param name="second">Second element of the tuple</param>
        /// <returns>A newly created tuple</returns>
        public static Tuple<TFirst, TSecond> Create<TFirst, TSecond>(TFirst first, TSecond second)
        {
            return new Tuple<TFirst, TSecond>(first, second);
        }

        /// <summary>
        /// Creates a new tuple value with the specified elements. The method
        /// can be used without specifying the generic parameters, because C#
        /// compiler can usually infer the actual types.
        /// </summary>
        /// <typeparam name="TFirst">The type of the first.</typeparam>
        /// <typeparam name="TSecond">The type of the second.</typeparam>
        /// <typeparam name="TThird">The type of the third.</typeparam>
        /// <param name="first">First element of the tuple</param>
        /// <param name="second">Second element of the tuple</param>
        /// <param name="third">Third element of the tupple.</param>
        /// <returns>A newly created tuple</returns>
        public static Tuple<TFirst, TSecond, TThird> Create<TFirst, TSecond, TThird>(TFirst first, TSecond second, TThird third)
        {
            return new Tuple<TFirst, TSecond, TThird>(first, second, third);
        }

        /// <summary>
        /// Creates a new tuple value with the specified elements. The method
        /// can be used without specifying the generic parameters, because C#
        /// compiler can usually infer the actual types.
        /// </summary>
        /// <typeparam name="TFirst">The type of the first.</typeparam>
        /// <typeparam name="TSecond">The type of the second.</typeparam>
        /// <typeparam name="TThird">The type of the third.</typeparam>
        /// <typeparam name="TFourth">The type of the fourth.</typeparam>
        /// <param name="first">First element of the tuple</param>
        /// <param name="second">Second element of the tuple</param>
        /// <param name="third">Third element of the tuple.</param>
        /// <param name="fourth">Fourth element of the tuple.</param>
        /// <returns>A newly created tuple</returns>
        public static Tuple<TFirst, TSecond, TThird, TFourth> Create<TFirst, TSecond, TThird, TFourth>(TFirst first,
            TSecond second, TThird third, TFourth fourth)
        {
            return new Tuple<TFirst, TSecond, TThird, TFourth>(first, second, third, fourth);
        }
    }
}*/