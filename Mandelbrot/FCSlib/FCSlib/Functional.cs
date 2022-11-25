#region Copyright
/* Copyright 2009 Oliver Sturm <oliver@sturmnet.org> All rights reserved. */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using FCSlib.Data;
using FCSColl = FCSlib.Data.Collections;

namespace FCSlib {
  public static class Functional {
    public static IEnumerable<R> Map<T, R>(Converter<T, R> function, IEnumerable<T> list) {
      foreach (T sourceVal in list)
        yield return function(sourceVal);
    }

    //public static IEnumerable<T> Filter<T>(Predicate<T> predicate, IEnumerable<T> list) {
    //  foreach (T val in list)
    //    if (predicate(val))
    //      yield return val;
    //}

    public static R FoldL<T, R>(Func<R, T, R> accumulator, R startVal, IEnumerable<T> list) {
      R result = startVal;
      foreach (T sourceVal in list)
        result = accumulator(result, sourceVal);
      return result;
    }

    public static T FoldL1<T>(Func<T, T, T> accumulator, IEnumerable<T> list) {
      return FoldL(accumulator, First(list), Skip(1, list));
    }

    //public static R FoldR<T, R>(Func<T, R, R> accumulator, R startVal, IEnumerable<T> list) {
    //  return FoldL((r, x) => accumulator(x, r), startVal, Functional.Reverse(list));
    //}

    //public static T FoldR1<T>(Func<T, T, T> accumulator, IEnumerable<T> list) {
    //  return FoldL1((r, x) => accumulator(x, r), Functional.Reverse(list));
    //}

    public static IEnumerable<T> Reverse<T>(IEnumerable<T> source) {
      FCSColl::List<T> stack = FCSColl::List<T>.Empty;
      foreach (T item in source)
        stack = stack.Cons(item);
      while (stack != FCSColl.List<T>.Empty) {
        yield return stack.Head;
        stack = stack.Tail;
      }
    }

    public static T First<T>(IEnumerable<T> source) {
      var enumerator = source.GetEnumerator( );
      enumerator.MoveNext( );
      return enumerator.Current;
    }

    public static IEnumerable<T> Take<T>(int count, IEnumerable<T> source) {
      int returned = 0;
      foreach (T item in source) {
        if (returned++ < count)
          yield return item;
        else
          yield break;
      }
    }

    public static IEnumerable<T> Skip<T>(int count, IEnumerable<T> source) {
      int skipped = 0;
      foreach (T item in source) {
        if (skipped < count) {
          skipped++;
          continue;
        }
        yield return item;
      }
    }
  }
}
