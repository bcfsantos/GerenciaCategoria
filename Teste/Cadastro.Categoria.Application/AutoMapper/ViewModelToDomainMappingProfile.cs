using AutoMapper;
using Cadastro.Application.ViewModel;
using Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Categoria, CategoriaViewModel>();
            Mapper.CreateMap<SubCategoria, SubCategoriaViewModel>();
            Mapper.CreateMap<SubCategoriaCampo, SubCategoriaCampoViewModel>();
            Mapper.CreateMap<Campo, CampoViewModel>();
            Mapper.CreateMap<Tipo, TipoViewModel>();
        }
     
     
    }
}
