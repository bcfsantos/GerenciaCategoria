using AutoMapper;
using Cadastro.Application.ViewModel;
using Cadastro.Domain.Entities;

namespace Cadastro.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }


        protected override void Configure()
        {
            Mapper.CreateMap<CategoriaViewModel, Cadastro.Domain.Entities.Categoria>();
            Mapper.CreateMap<SubCategoriaViewModel, SubCategoria>();
            Mapper.CreateMap<SubCategoriaCampoViewModel, SubCategoriaCampo>();
            Mapper.CreateMap<CampoViewModel, Campo>();
            Mapper.CreateMap<TipoViewModel, Tipo>();
        }

    }
}
