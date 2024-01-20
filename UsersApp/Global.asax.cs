using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using AutoMapper;

namespace UsersApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Configure AutoMapper
            AutoMapperConfig.Configure();
        }
    }

    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LibrarieModele.USER, UsersApp.Models.User>();
            });

            IMapper mapper = config.CreateMapper();
            // You can use 'mapper' instance for mapping.
        }
    }
}
