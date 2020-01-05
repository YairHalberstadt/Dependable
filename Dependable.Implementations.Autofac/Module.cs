﻿using Autofac;
using Dependable.Abstractions;

namespace Dependable.Implementations.Autofac
{
	public class Module : global::Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterGeneric(typeof(AutofacImpl.AutofacScopeFactory<>))
				.As(typeof(IScopeFactory<>))
				.InstancePerDependency();
			builder.RegisterGeneric(typeof(AutofacImpl.AutofacScopeFactory<,>))
				.As(typeof(IScopeFactory<,>))
				.InstancePerDependency();
			builder.RegisterGeneric(typeof(AutofacImpl.AutofacScopeFactory<,,>))
				.As(typeof(IScopeFactory<,,>))
				.InstancePerDependency();
			builder.RegisterGeneric(typeof(AutofacImpl.AutofacScopeFactory<,,,>))
				.As(typeof(IScopeFactory<,,,>))
				.InstancePerDependency();
			builder.RegisterGeneric(typeof(AutofacImpl.AutofacScopeFactory<,,,,>))
				.As(typeof(IScopeFactory<,,,,>))
				.InstancePerDependency();
			builder.RegisterGeneric(typeof(AutofacImpl.AutofacScopeFactory<,,,,,>))
				.As(typeof(IScopeFactory<,,,,,>))
				.InstancePerDependency();
			builder.RegisterGeneric(typeof(AutofacImpl.AutofacScopeFactory<,,,,,,>))
				.As(typeof(IScopeFactory<,,,,,,>))
				.InstancePerDependency();
			builder.RegisterGeneric(typeof(AutofacImpl.AutofacScopeFactory<,,,,,,,>))
				.As(typeof(IScopeFactory<,,,,,,,>))
				.InstancePerDependency();
			builder.RegisterGeneric(typeof(AutofacImpl.AutofacScopeFactory<,,,,,,,,>))
				.As(typeof(IScopeFactory<,,,,,,,,>))
				.InstancePerDependency();
		}
	}
}
