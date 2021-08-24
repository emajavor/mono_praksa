using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Repository.Common;
//

namespace Student.Repository
{
    class RepositoryDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>().As<IStudentRepository<StudentRepository>>();
            builder.RegisterType<UniversityRepository>().As<IUniversityRepository<UniversityRepository>>();
        }
    }
}
