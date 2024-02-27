using crud.BLL.Models;
using crud.API.ViewModels;
using AutoMapper;



namespace crud.API.Configuration
{
    public class AutoMapperConf : Profile //Herdando classe de perfil do AutoMapper
    {

        public AutoMapperConf()
        {
            //Relação De - Para                //Garante o mapping ao contrário
            CreateMap<Marca, MarcaViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
