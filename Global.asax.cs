using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using HelloWebAPI.Configuration;
using HelloWebAPI.Controller;

namespace HelloWebAPI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(HelloWebAPIConfig.Register);

            Dictionary_students.students.Add(1, "Anna Winter");
            Dictionary_students.students.Add(2, "Mark Polo");
            Dictionary_students.students.Add(3, "Janet Janison");
            Dictionary_students.students.Add(4, "Luke Sky");
            Dictionary_students.students.Add(5, "Jack Perkinson");
            Dictionary_students.students.Add(6, "Lucy Luke");
            Dictionary_students.students.Add(7, "Betty Black");
            Dictionary_students.students.Add(8, "Max Jenkinson");
            Dictionary_students.students.Add(9, "Romeo Soares");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}