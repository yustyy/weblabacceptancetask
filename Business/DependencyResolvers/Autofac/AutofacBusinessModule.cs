using System;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Reflection;
using Business.Concrete;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Module = Autofac.Module;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {          

            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

            builder.RegisterType<OperationClaimDal>().As<IOperationClaimDal>().SingleInstance();
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();

            builder.RegisterType<UserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();
            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}