using crud_usuario.Models;

namespace crud_usuario.Service.Usuario
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();
    }
}
