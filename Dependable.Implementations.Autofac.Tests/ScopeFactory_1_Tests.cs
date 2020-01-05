using Autofac;
using Autofac.Core.Registration;
using Dependable.Abstractions;
using System;
using Xunit;

namespace Dependable.Implementations.Autofac.Tests
{
	public class ScopeFactory_1_Tests
	{
		[Fact]
		public void CanResolveScopeFactoryAsParameter()
		{
			var builder = GetBuilder();
			using (var container = builder.Build())
			{
				var c = container.Resolve<C<object>>();
				Assert.NotNull(c.LifetimeScope);
			}
		}


		[Fact]
		public void CanCreateScopeFromScopeFactory()
		{
			var builder = GetBuilder();
			builder.RegisterType<object>();
			using (var container = builder.Build())
			{
				var c = container.Resolve<C<object>>();
				Assert.NotNull(c.LifetimeScope.CreateScope().Value);
			}
		}

		[Fact]
		public void CreateScopeThrowsIfValueNotRegistered()
		{
			var builder = GetBuilder();
			using (var container = builder.Build())
			{
				var c = container.Resolve<C<object>>();
				Assert.Throws<ComponentNotRegisteredException>(c.LifetimeScope.CreateScope);
			}
		}

		[Fact]
		public void UsesSameInstanceForSameScope()
		{
			var builder = GetBuilder();
			builder.RegisterType<object>().InstancePerLifetimeScope();
			using (var container = builder.Build())
			{
				var c = container.Resolve<C<Func<object>>>();
				using (var scope = c.LifetimeScope.CreateScope())
				{
					Assert.Equal(scope.Value(), scope.Value());
				}
			}
		}

		[Fact]
		public void UsesDifferentInstanceForDifferentScope()
		{
			var builder = GetBuilder();
			builder.RegisterType<object>().InstancePerLifetimeScope();
			using (var container = builder.Build())
			{
				var c = container.Resolve<C<Func<object>>>();
				using (var scope1 = c.LifetimeScope.CreateScope())
				using (var scope2 = c.LifetimeScope.CreateScope())
				{
					Assert.NotEqual(scope1.Value(), scope2.Value());
				}
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
			public C(IScopeFactory<T> scope)
			{
				LifetimeScope = scope;
			}

			public IScopeFactory<T> LifetimeScope { get; }
		}
	}
}
