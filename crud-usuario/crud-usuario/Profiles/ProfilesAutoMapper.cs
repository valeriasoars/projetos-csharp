using AutoMapper;
using crud_usuario.Dto.Usuario;
using crud_usuario.Models;

namespace crud_usuario.Profiles
{
    public class ProfilesAutoMapper: Profile
    {
        public ProfilesAutoMapper()
        {
            CreateMap<UsuarioCriacaoDto, UsuarioModel>().ReverseMap();
            
        }
    }
}
