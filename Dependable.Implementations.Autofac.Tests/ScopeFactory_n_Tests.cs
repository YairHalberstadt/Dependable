using Autofac;
using Dependable.Abstractions;
using Xunit;

namespace Dependable.Implementations.Autofac.Tests
{
	public class ScopeFactory_n_Tests
	{
		[Fact]
		public void Test0()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires0>().InstancePerLifetimeScope();
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Requires0>>();
				using (var r = f.CreateScope())
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test1()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires1>().InstancePerMatchingLifetimeScope(Tag.Create<Type1>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Requires1>>();
				using (var r = f.CreateScope(new Type1()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test2_1()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires2>().InstancePerMatchingLifetimeScope(Tag.Create<Type1>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Requires2>>();
				using (var r = f.CreateScope(new Type1(), new Type2()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test2_2()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires2>().InstancePerMatchingLifetimeScope(Tag.Create<Type2>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Requires2>>();
				using (var r = f.CreateScope(new Type1(), new Type2()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test3_1()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires3>().InstancePerMatchingLifetimeScope(Tag.Create<Type1>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Requires3>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test3_2()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires3>().InstancePerMatchingLifetimeScope(Tag.Create<Type2>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Requires3>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test3_3()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires3>().InstancePerMatchingLifetimeScope(Tag.Create<Type3>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Requires3>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test4_1()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires4>().InstancePerMatchingLifetimeScope(Tag.Create<Type1>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Requires4>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test4_2()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires4>().InstancePerMatchingLifetimeScope(Tag.Create<Type2>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Requires4>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test4_3()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires4>().InstancePerMatchingLifetimeScope(Tag.Create<Type3>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Requires4>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test4_4()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires4>().InstancePerMatchingLifetimeScope(Tag.Create<Type4>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Requires4>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test5_1()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires5>().InstancePerMatchingLifetimeScope(Tag.Create<Type1>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Requires5>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test5_2()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires5>().InstancePerMatchingLifetimeScope(Tag.Create<Type2>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Requires5>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test5_3()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires5>().InstancePerMatchingLifetimeScope(Tag.Create<Type3>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Requires5>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test5_4()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires5>().InstancePerMatchingLifetimeScope(Tag.Create<Type4>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Requires5>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test5_5()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires5>().InstancePerMatchingLifetimeScope(Tag.Create<Type5>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Requires5>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test6_1()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires6>().InstancePerMatchingLifetimeScope(Tag.Create<Type1>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Requires6>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test6_2()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires6>().InstancePerMatchingLifetimeScope(Tag.Create<Type2>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Requires6>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test6_3()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires6>().InstancePerMatchingLifetimeScope(Tag.Create<Type3>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Requires6>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test6_4()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires6>().InstancePerMatchingLifetimeScope(Tag.Create<Type4>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Requires6>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test6_5()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires6>().InstancePerMatchingLifetimeScope(Tag.Create<Type5>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Requires6>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test6_6()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires6>().InstancePerMatchingLifetimeScope(Tag.Create<Type6>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Requires6>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test7_1()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires7>().InstancePerMatchingLifetimeScope(Tag.Create<Type1>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Requires7>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test7_2()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires7>().InstancePerMatchingLifetimeScope(Tag.Create<Type2>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Requires7>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test7_3()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires7>().InstancePerMatchingLifetimeScope(Tag.Create<Type3>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Requires7>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test7_4()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires7>().InstancePerMatchingLifetimeScope(Tag.Create<Type4>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Requires7>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test7_5()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires7>().InstancePerMatchingLifetimeScope(Tag.Create<Type5>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Requires7>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test7_6()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires7>().InstancePerMatchingLifetimeScope(Tag.Create<Type6>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Requires7>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test7_7()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires7>().InstancePerMatchingLifetimeScope(Tag.Create<Type7>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Requires7>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test8_1()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires8>().InstancePerMatchingLifetimeScope(Tag.Create<Type1>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Type8, Requires8>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7(), new Type8()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test8_2()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires8>().InstancePerMatchingLifetimeScope(Tag.Create<Type2>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Type8, Requires8>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7(), new Type8()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test8_3()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires8>().InstancePerMatchingLifetimeScope(Tag.Create<Type3>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Type8, Requires8>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7(), new Type8()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test8_4()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires8>().InstancePerMatchingLifetimeScope(Tag.Create<Type4>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Type8, Requires8>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7(), new Type8()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		[Fact]
		public void Test8_5()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires8>().InstancePerMatchingLifetimeScope(Tag.Create<Type5>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Type8, Requires8>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7(), new Type8()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}


		[Fact]
		public void Test8_6()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires8>().InstancePerMatchingLifetimeScope(Tag.Create<Type6>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Type8, Requires8>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7(), new Type8()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}


		[Fact]
		public void Test8_7()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires8>().InstancePerMatchingLifetimeScope(Tag.Create<Type7>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Type8, Requires8>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7(), new Type8()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}


		[Fact]
		public void Test8_8()
		{
			var builder = GetBuilder();
			builder.RegisterType<Requires8>().InstancePerMatchingLifetimeScope(Tag.Create<Type8>());
			using (var container = builder.Build())
			{
				var f = container.Resolve<IScopeFactory<Type1, Type2, Type3, Type4, Type5, Type6, Type7, Type8, Requires8>>();
				using (var r = f.CreateScope(new Type1(), new Type2(), new Type3(), new Type4(), new Type5(), new Type6(), new Type7(), new Type8()))
				{
					Assert.NotNull(r.Value);
				}
			}
		}

		private ContainerBuilder GetBuilder()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule<ScopeFactoryModule>();
			return builder;
		}

		private class Type1 { }
		private class Type2 { }
		private class Type3 { }
		private class Type4 { }
		private class Type5 { }
		private class Type6 { }
		private class Type7 { }
		private class Type8 { }

		private class Requires0 { }
		private class Requires1 { public Requires1(Type1 p1) { } }
		private class Requires2 { public Requires2(Type1 p1, Type2 p2) { } }
		private class Requires3 { public Requires3(Type1 p1, Type2 p2, Type3 p3) { } }
		private class Requires4 { public Requires4(Type1 p1, Type2 p2, Type3 p3, Type4 p4) { } }
		private class Requires5 { public Requires5(Type1 p1, Type2 p2, Type3 p3, Type4 p4, Type5 p5) { } }
		private class Requires6 { public Requires6(Type1 p1, Type2 p2, Type3 p3, Type4 p4, Type5 p5, Type6 p6) { } }
		private class Requires7 { public Requires7(Type1 p1, Type2 p2, Type3 p3, Type4 p4, Type5 p5, Type6 p6, Type7 p7) { } }
		private class Requires8 { public Requires8(Type1 p1, Type2 p2, Type3 p3, Type4 p4, Type5 p5, Type6 p6, Type7 p7, Type8 p8) { } }
	}
}
