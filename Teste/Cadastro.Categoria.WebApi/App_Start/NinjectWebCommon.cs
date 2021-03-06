[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Cadastro.WebApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Cadastro.WebApi.App_Start.NinjectWebCommon), "Stop")]

namespace Cadastro.WebApi.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Application.Interface;
    using Application;
    using Domain.Interfaces.Services;
    using Domain.Services;
    using Domain.Interfaces.Repositories;
    using Cadastro.Infra.Repositories;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<ICategoriaAppService>().To<CategoriaAppService>();
            kernel.Bind<ISubCategoriaAppService>().To<SubCategoriaAppService>();
            kernel.Bind<ISubCategoriaCampoAppService>().To<SubCategoriaCampoAppService>();
            kernel.Bind<ICampoAppService>().To<CampoAppService>();
            kernel.Bind<ITipoAppService>().To<TipoAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<ICategoriaService>().To<CategoriaService>();
            kernel.Bind<ISubCategoriaService>().To<SubCategoriaService>();
            kernel.Bind<ISubCategoriaCampoService>().To<SubCategoriaCampoService>();
            kernel.Bind<ICampoService>().To<CampoService>();
            kernel.Bind<ITipoService>().To<TipoService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<ICategoriaRepository>().To<CategoriaRepository>();
            kernel.Bind<ISubCategoriaRepository>().To<SubCategoriaRepository>();
            kernel.Bind<ISubCategoriaCampoRepository>().To<SubCategoriaCampoRepository>();
            kernel.Bind<ICampoRepository>().To<CampoRepository>();
            kernel.Bind<ITipoRepository>().To<TipoRepository>();
        }
    }
}
