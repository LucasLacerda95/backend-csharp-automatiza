using crud.BLL.Models;
using crud.API.ViewModels;
using AutoMapper;



namespace crud.API.Configuration
{
    public class AutoMapperConf : Profile
    {

        public AutoMapperConf()
        {
            CreateMap<Marca, MarcaViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
