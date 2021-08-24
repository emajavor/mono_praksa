using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StudentWEBApi.Controllers;
using Autofac;
using Autofac.Integration.WebApi;
using Student.Model.Common;
using Student.Model;
using Student.Repository.Common;
using Student.Repository;
using Student.Service.Common;
using Student.Service;


namespace StudentWEBApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            //GlobalConfiguration.Configure(WebApiConfig.Register);
            builder.RegisterType<Students>().As<IStudent>();
            builder.RegisterType<University>().As<Iuniversity>();

            builder.RegisterType<StudentRepository>().As<IStudentRepository<Students>>();
            builder.RegisterType<UniversityRepository>().As<IUniversityRepository<University>>();

            builder.RegisterType<StudentService>().As<IStudentService<Students>>();
            builder.RegisterType<UniversityService>().As<IuniversityService<University>>();
            builder.RegisterModule<RepositoryDIModule>();
            builder.RegisterModule<ServiceDIModule>();



            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
