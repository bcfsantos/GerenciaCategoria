using Cadastro.Application;
using Cadastro.Application.Interface;
using Cadastro.Domain.Services;
using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Domain.Services;
using Cadastro.Infra.Repositories;
using Ninject.Modules;
using Cadastro.Domain.Services;

namespace Cadastro.Infra.CrossCutting.Ioc
{
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            Bind<ICategoriaAppService>().To<CategoriaAppService>();
            Bind<ISubCategoriaAppService>().To<SubCategoriaAppService>();
            Bind<ICampoAppService>().To<CampoAppService>();

            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<ICategoriaService>().To<CategoriaService>();
            Bind<ISubCategoriaService>().To<SubCategoriaService>();
            Bind<ICampoService>().To<CampoService>();

            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind<ICategoriaRepository>().To<CategoriaRepository>();
            Bind<ISubCategoriaRepository>().To<SubCategoriaRepository>();
            Bind<ICampoRepository>().To<CampoRepository>();


        }
    }
}
