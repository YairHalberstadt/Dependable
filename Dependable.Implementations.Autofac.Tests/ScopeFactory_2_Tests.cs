using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Dependable.Abstractions;
using System;
using Xunit;

namespace Dependable.Implementations.Autofac.Tests
{
	public class ScopeFactory_2_Tests
	{
		[Fact]
		public void CanResolveScopeFactoryAsParameter()
		{
			var builder = GetBuilder();
			using (var container = builder.Build())
			{
				var c = container.Resolve<C<D>>();
				Assert.NotNull(c.LifetimeScope);
			}
		}


		[Fact]
		public void CanCreateScopeFromScopeFactory()
		{
			var builder = GetBuilder();
			builder.RegisterType<D>().InstancePerLifetimeScope();
			using (var container = builder.Build())
			{
				var c = container.Resolve<C<D>>();
				Assert.Equal("", c.LifetimeScope.CreateScope("").Value.S);
			}
		}

		[Fact]
		public void CreateScopeThrowsIfValueNotRegistered()
		{
			var builder = GetBuilder();
			using (var container = builder.Build())
			{
				var c = container.Resolve<C<D>>();
				Assert.Throws<ComponentNotRegisteredException>(() => c.LifetimeScope.CreateScope(""));
			}
		}

		[Fact]
		public void UsesSameInstanceForSameScope()
		{
			var builder = GetBuilder();
			builder.RegisterType<D>().InstancePerLifetimeScope();
			using (var container = builder.Build())
			{
				var c = container.Resolve<C<Func<D>>>();
				using (var scope = c.LifetimeScope.CreateScope(""))
				{
					Assert.Equal(scope.Value(), scope.Value());
				}
			}
		}

		[Fact]
		public void UsesDifferentInstanceForDifferentScope()
		{
			var builder = GetBuilder();
			builder.RegisterType<D>().InstancePerLifetimeScope();
			using (var container = builder.Build())
			{
				var c = container.Resolve<C<Func<D>>>();
				using (var scope1 = c.LifetimeScope.CreateScope(""))
				using (var scope2 = c.LifetimeScope.CreateScope(""))
				{
					Assert.NotEqual(scope1.Value(), scope2.Value());
				}
			}
		}

		[Fact]
		public void UsesDifferentInstanceForDifferentScopeIfMatchingLifetimeScopeUsedWithTagOfParam()
		{
			var builder = GetBuilder();
			builder.RegisterType<D>().InstancePerMatchingLifetimeScope(Tag.GetTag<string>());
			using (var container = builder.Build())
			{
				var c = container.Resolve<C<Func<D>>>();
				using (var scope1 = c.LifetimeScope.CreateScope(""))
				using (var scope2 = c.LifetimeScope.CreateScope(""))
				{
					Assert.NotEqual(scope1.Value(), scope2.Value());
				}
			}
		}

		[Fact]
		public void ThrowsIfMatchingLifetimeScopeUsedWithTagOfDifferentParam()
		{
			var builder = GetBuilder();
			builder.RegisterType<D>().InstancePerMatchingLifetimeScope(Tag.GetTag<object>());
			using (var container = builder.Build())
			{
				var c = container.Resolve<C<D>>();
				Assert.Throws<DependencyResolutionException>(() => c.LifetimeScope.CreateScope(""));
			}
		}

		[Fact]
		public void ParamCanBeUsedByNestedDependency()
		{
			var builder = GetBuilder();
			builder.RegisterType<D>();
			builder.RegisterType<E>();
			using (var container = builder.Build())
			{
				var c = container.Resolve<C<E>>();
				Assert.Equal("", c.LifetimeScope.CreateScope("").Value.D.S);
			}
		}

		[Fact]
		public void CreateScopeParametersOverrideExistingRegistration()
		{
			var builder = GetBuilder();
			builder.RegisterInstance("Hello");
			using (var container = builder.Build())
			{
				var c = container.Resolve<C<string>>();
				Assert.Equal("World", c.LifetimeScope.CreateScope("World").Value);
			}
		}

		private ContainerBuilder GetBuilder()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule<Module>();
			builder.RegisterGeneric(typeof(C<>)).AsSelf();
			return builder;
		}

		private class C<T>
		{
			public C(IScopeFactory<string, T> scope)
			{
				LifetimeScope = scope;
			}

			public IScopeFactory<string, T> LifetimeScope { get; }
		}

		private class D
		{
			public D(string s)
			{
				S = s;
			}

			public string S { get; }
		}

		private class E
		{
			public E(D d)
			{
				D = d;
			}
			public D D { get; }
		}
	}
}
