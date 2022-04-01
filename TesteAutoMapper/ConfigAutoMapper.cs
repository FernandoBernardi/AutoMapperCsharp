using AutoMapper;
using TesteAutoMapper.Core.DTOs;
using TesteAutoMapper.Models;

namespace TesteAutoMapper
{
    public class ConfigAutoMapper
    {
        private IMapper _mapper;
        private MapperConfiguration _config;
        private PerfilDTO ConverterPerfilUsuario(PerfilModel perfil)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PerfilModel, PerfilDTO>();
                cfg.CreateMap<PerfilDTO, PerfilModel>();
            }).CreateMapper();
            return configuration.Map<PerfilDTO>(perfil);
        }
        public ConfigAutoMapper GetConfig()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioModel, UsuarioDTO>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ConstructUsing(x => new UsuarioDTO(ConverterPerfilUsuario(x.Perfil)));
                cfg.CreateMap<UsuarioDTO, UsuarioModel>();
                cfg.CreateMap<PerfilModel, PerfilDTO>();
                cfg.CreateMap<PerfilDTO, PerfilModel>();
            });
            _config = configuration;
            return this;
        }
        public ConfigAutoMapper CreateMapper()
        {
            if (_config == null) throw new System.Exception("A configuração do mapper não pode ser nula");
            _mapper = _config.CreateMapper();
            return this;
        }
        public IMapper Build()
        {
            return _mapper;
        }
    }
}
