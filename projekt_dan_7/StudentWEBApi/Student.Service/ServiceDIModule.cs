using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Service;
using Student.Service.Common;


namespace Student.Service
{
    public class ServiceDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>().As<IStudentService<StudentService>>();
            builder.RegisterType<UniversityService>().As<IuniversityService<UniversityService>>();
        }
    }
}
