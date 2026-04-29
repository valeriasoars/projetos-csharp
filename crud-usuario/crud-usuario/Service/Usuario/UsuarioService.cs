using crud_usuario.Data;
using crud_usuario.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_usuario.Service.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int id)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    response.Mensagem = "Usuário não encontrado.";
                    return response;
                }

                response.Dados = usuario;
                response.Mensagem = "Usuário encontrado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Ocorreu um erro ao buscar o usuário: {ex.Message}";
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            ResponseModel<List<UsuarioModel>> response = new ResponseModel<List<UsuarioModel>>();

            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                if (usuarios.Count == 0)
                {
                    response.Mensagem = "Nenhum usuário encontrado.";
                    return response;
                }

                response.Dados = usuarios;
                response.Mensagem = "Usuários listados com sucesso.";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Ocorreu um erro ao listar os usuários: {ex.Message}";
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> RemoverUsuario(int id)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    response.Mensagem = "Usuário não encontrado.";
                    return response;
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                response.Dados = usuario;
                response.Mensagem = $"Usuário {usuario.Nome} removido com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Ocorreu um erro ao remover o usuário: {ex.Message}";
                response.Status = false;
                return response;
            }
        }
    }
}
