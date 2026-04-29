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
            catch (Exception ex) { 
                response.Mensagem = $"Ocorreu um erro ao listar os usuários: {ex.Message}";
                response.Status = false;
                return response;
            }
        }
    }
}
