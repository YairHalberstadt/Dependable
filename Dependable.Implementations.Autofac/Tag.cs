using System;
using System.Collections.Generic;

namespace Dependable.Implementations.Autofac
{
	public abstract class Tag : IEquatable<Tag>
	{
		public static Tag Create<T>() => new SingleTag(typeof(T));
		public static Tag Create<T1, T2>() => new CombinedTag(typeof(T1), typeof(T2));
		public static Tag Create<T1, T2, T3>() => new CombinedTag(typeof(T1), typeof(T2), typeof(T3));
		public static Tag Create<T1, T2, T3, T4>() => new CombinedTag(typeof(T1), typeof(T2), typeof(T3), typeof(T4));
		public static Tag Create<T1, T2, T3, T4, T5>() => new CombinedTag(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5));
		public static Tag Create<T1, T2, T3, T4, T5, T6>() => new CombinedTag(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6));
		public static Tag Create<T1, T2, T3, T4, T5, T6, T7>() => new CombinedTag(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7));
		public static Tag Create<T1, T2, T3, T4, T5, T6, T7, T8>() => new CombinedTag(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8));
		private Tag() { }
		private sealed class SingleTag : Tag
		{
			public SingleTag(Type type)
			{
				Type = type;
			}

			public Type Type { get; }

			public override bool Equals(Tag other)
			{
				if (other is SingleTag singleTag)
					return singleTag.Type.Equals(Type);
				else if (other is CombinedTag combinedTag)
				{
					return combinedTag.Types.Contains(Type);
				}
				throw new InvalidOperationException("Unreachable");
			}
		}

		private sealed class CombinedTag : Tag
		{
			public CombinedTag(params Type[] types)
			{
				Types = new HashSet<Type>(types);
			}

			public HashSet<Type> Types { get; }

			public override bool Equals(Tag other)
			{
				if (other is SingleTag singleTag)
					return Types.Contains(singleTag.Type);
				else if (other is CombinedTag combinedTag)
				{
					var iterateThis = Types.Count <= combinedTag.Types.Count;
					var set = iterateThis ? combinedTag.Types : Types;
					foreach (var type in iterateThis ? Types : combinedTag.Types)
					{
						if (set.Contains(type))
							return true;
					}
					return false;
				}
				throw new InvalidOperationException("Unreachable");
			}
		}
		public abstract bool Equals(Tag other);

		public override bool Equals(object obj)
		{
			if (obj is Tag tag)
				return Equals(tag);
			return false;
		}

		/// randomly generated constant. 
		/// Since it possible that a == b, b == c, a != c, we cannot do better.
		public override int GetHashCode() => 797900084;
	}
}