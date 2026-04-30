using crud_usuario.Dto.Usuario;
using crud_usuario.Service.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud_usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public LoginController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioCriacaoDto usuarioCriacaoDto)
        {
            var response = await _usuarioInterface.RegistrarUsuario(usuarioCriacaoDto);
            return Ok(response);
        }
    }
}
