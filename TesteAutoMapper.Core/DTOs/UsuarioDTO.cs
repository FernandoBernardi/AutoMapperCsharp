using Realms;
using System;

namespace TesteAutoMapper.Core.DTOs
{
    public class UsuarioDTO : RealmObject
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public PerfilDTO Perfil { get; }
        public UsuarioDTO()
        {

        }
        public UsuarioDTO(PerfilDTO perfil)
        {
            if (perfil != null)
                Perfil = perfil;
        }
    }
    public class PerfilDTO : RealmObject
    {
        public string Sexo { get; set; }
    }
}
