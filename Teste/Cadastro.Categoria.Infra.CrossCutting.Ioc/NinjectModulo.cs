using Cadastro.Application;
using Cadastro.Application.Interface;
using Cadastro.Domain.Services;
using Cadastro.Domain.Interfaces.Repositories;
using Cadastro.Domain.Interfaces.Services;
using Cadastro.Infra.Repositories;
using Ninject.Modules;

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
            Bind<ITipoAppService>().To<TipoAppService>();

            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<ICategoriaService>().To<CategoriaService>();
            Bind<ISubCategoriaService>().To<SubCategoriaService>();
            Bind<ICampoService>().To<CampoService>();
            Bind<ITipoService>().To<TipoService>();

            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind<ICategoriaRepository>().To<CategoriaRepository>();
            Bind<ISubCategoriaRepository>().To<SubCategoriaRepository>();
            Bind<ICampoRepository>().To<CampoRepository>();
            Bind<ITipoRepository>().To<TipoRepository>();



        }
    }
}
