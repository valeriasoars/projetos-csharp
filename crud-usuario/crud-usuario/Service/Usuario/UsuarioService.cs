using AutoMapper;
using crud_usuario.Data;
using crud_usuario.Dto.Usuario;
using crud_usuario.Models;
using crud_usuario.Service.Senha;
using Microsoft.EntityFrameworkCore;

namespace crud_usuario.Service.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        private readonly ISenhaInterface _senhaInterface;
        private readonly IMapper _mapper;
        public UsuarioService(AppDbContext context, ISenhaInterface senhaInterface, IMapper mapper) 
        {
            _context = context;
            _senhaInterface = senhaInterface;
            _mapper = mapper;
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

        public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                if (!VerificaSeExisteEmailUsuarioRepetidos(usuarioCriacaoDto))
                {
                    response.Mensagem = "O email ou nome de usuário já estão em uso.";
                    return response;
                }


                _senhaInterface.CriarSenhaHash(usuarioCriacaoDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);


                UsuarioModel usuario = _mapper.Map<UsuarioModel>(usuarioCriacaoDto);
                usuario.SenhaHash = senhaHash;
                usuario.SenhaSalt = senhaSalt;

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                response.Dados = usuario;
                response.Mensagem = "Usuário registrado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Ocorreu um erro ao registrar o usuário: {ex.Message}";
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



        private bool VerificaSeExisteEmailUsuarioRepetidos(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == usuarioCriacaoDto.Email || u.Usuario == usuarioCriacaoDto.Usuario);
            if(usuario != null)
            {
                return false;
            }

            return true;
        }
    }

}
