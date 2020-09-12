using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Entity.DbContextFactory;
using TodoList.Entity.Interface;
using TodoList.Entity.Repository;
using TodoList.Entity.UnitOfWork;

namespace TodoList.Web
{
    public class AutofacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //dbcontext
            string ConnectionString = ConfigurationManager.ConnectionStrings["TodoListDatabaseEntities"].ConnectionString;
            var SrcDirectory = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent;
            var Path = string.Format("{0}\\{1}", SrcDirectory.FullName, "TodoList.Entity");
            AppDomain.CurrentDomain.SetData("DataDirectory", Path);

            builder.RegisterType<DbContextFactory>()
                .WithParameter("connectionString", ConnectionString)
                .As<IDbContextFactory>()
                .InstancePerLifetimeScope();

            //repository
            builder.RegisterGeneric(typeof(GenericRepository<>))
                   .As(typeof(IGenericRepository<>))
                    .InstancePerLifetimeScope();

            //unit of work
            builder.RegisterType<EFUnitOfWork>()
                    .As<IUnitOfWork>()
                    .InstancePerLifetimeScope();

            ////services
            //var services = Assembly.Load("NEC.PA.Bussiness");
            //builder.RegisterAssemblyTypes(services)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces();



            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}