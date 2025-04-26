using Autofac;
using PointOfSale.Application.Services;
using PointOfSale.Domain.RepositoryInterfaces;
using PointOfSale.Domain.UnitOfWorkInterfaces;
using PointOfSale.Infrastructure.ApplicationDB;
using PointOfSale.Infrastructure.RepositoryClasses;
using PointOfSale.Infrastructure.UnitOfWorkClasses;

namespace PointOfSale.API
{
    public class WebModule(string connectionString, string migrationAssembly) : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                       .WithParameter("connectionString", connectionString)
                       .WithParameter("migrationAssembly", migrationAssembly)
                       .InstancePerLifetimeScope();

            builder.RegisterType<POSUnitOfWork>()
                     .As<IPOSUnitOfWork>()
                     .InstancePerLifetimeScope();

            builder.RegisterType<ProductService>()
                   .As<IProductService>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerLifetimeScope();


        }
    }
}
