#region Copyright
/* Copyright 2009 Oliver Sturm <oliver@sturmnet.org> All rights reserved. */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace FCSlib.Data {
  public class Option {
    protected Option( ) { }

    public static Option<T> Some<T>(T value) {
      return new Option<T>(value);
    }
    private static Option none = new Option( );
    public static Option None {
      get {
        return none;
      }
    }

    public static bool operator ==(Option a, Option b) {
      // here's what I should do:
      // check whether a is option<T>, if so - call
      // option<T>.op_equality (a, b)
      // otherwise, check whether b is option<T>, if so - 
      // call option<T>.op_equality(b,a)
      // otherwise, check equality on option basis only
      // there doesn't seem to be a more elegant way of 
      // getting to the right equality implementation, i.e.
      // one that doesn't use reflection

      // think about removing the untyped option type altogether

      Type btype = b.GetType( );
      if (btype.IsGenericType &&
        btype.GetGenericTypeDefinition( ) == typeof(Option<>))
        return b == a;

      // always true, since Option types (that are really 
      // *only* of type Option, not Option<T>) can 
      // only be None
      return true;
    }
    public static bool operator !=(Option a, Option b) {
      return !(a == b);
    }

    public override int GetHashCode( ) {
      return base.GetHashCode( );
    }

    public override bool Equals(object obj) {
      return base.Equals(obj);
    }

  }
  public sealed class Option<T> : Option {
    private T value;
    public T Value {
      get { return value; }
    }
    private bool hasValue;
    public bool HasValue {
      get { return hasValue; }
    }
    public bool IsSome {
      get { return hasValue; }
    }
    public bool IsNone {
      get { return !hasValue; }
    }

    public Option(T value) {
      this.value = value;
      this.hasValue = true;
    }

    public Option( ) {
    }

    private static Option<T> none = new Option<T>( );
    public new static Option<T> None {
      get {
        return none;
      }
    }

    public static bool operator ==(Option<T> a, Option b) {
      return false;
    }
    public static bool operator !=(Option<T> a, Option b) {
      return !(a == b);
    }

    public static bool operator ==(Option<T> a, Option<T> b) {
      return a.HasValue == b.HasValue &&
        EqualityComparer<T>.Default.Equals(a.Value, b.Value);
    }
    public static bool operator !=(Option<T> a, Option<T> b) {
      return !(a == b);
    }

    public override int GetHashCode( ) {
      int hashCode = hasValue.GetHashCode( );
      if (hasValue)
        hashCode ^= value.GetHashCode( );
      return hashCode;
    }

    public override bool Equals(object obj) {
      return base.Equals(obj);
    }
  }

}
