﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Linq.Extras.Internal;

namespace Linq.Extras
{
    partial class EnumerableEx
    {
        [Pure]
        public static bool None<TSource>([NotNull] this IEnumerable<TSource> source)
        {
            source.CheckArgumentNull("source");
            return !source.Any();
        }

        [Pure]
        public static bool None<TSource>(
            [NotNull] this IEnumerable<TSource> source,
            [NotNull] Func<TSource, bool> predicate)
        {
            source.CheckArgumentNull("source");
            predicate.CheckArgumentNull("predicate");
            return !source.Any(predicate);
        }

        /// <summary>
        /// Indicates whether a sequence is null or empty.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <c>source</c>.</typeparam>
        /// <param name="source">The sequence to check.</param>
        /// <returns>true if the source sequence is null or empty; otherwise, false.</returns>
        [Pure]
        [ContractAnnotation("source:null => true")]
        public static bool IsNullOrEmpty<TSource>(
            this IEnumerable<TSource> source)
        {
            if (source == null)
                return true;
            return !source.Any();
        }

        /// <summary>
        /// Indicates whether a sequence is null or empty.
        /// </summary>
        /// <param name="source">The sequence to check.</param>
        /// <returns>true if the source sequence is null or empty; otherwise, false.</returns>
        [Pure]
        [ContractAnnotation("source:null => true")]
        public static bool IsNullOrEmpty(
            this IEnumerable source)
        {
            if (source == null)
                return true;
            var collection = source as ICollection;
            if (collection != null)
                return collection.Count == 0;
            var enumerator = source.GetEnumerator();
            return !enumerator.MoveNext();
        }
    }
}
