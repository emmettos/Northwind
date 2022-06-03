using Autofac;
using EoSoftware.Northwind.Core.Interfaces;
using EoSoftware.Northwind.Core.Services;

namespace EoSoftware.Northwind.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
