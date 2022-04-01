namespace TesteAutoMapper.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PerfilModel Perfil { get; set; }
    }
    public class PerfilModel
    {
        public string Sexo { get; set; }
    }
}
