using crud_usuario.Dto.Usuario;
using crud_usuario.Service.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud_usuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            var response = await _usuarioInterface.ListarUsuarios();
            return Ok(response);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarUsuarioPorId(int id)
        {
            var response = await _usuarioInterface.BuscarUsuarioPorId(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto)
        {
            var response = await _usuarioInterface.EditarUsuario(usuarioEdicaoDto);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoverUsuario(int id)
        {
            var response = await _usuarioInterface.RemoverUsuario(id);
            return Ok(response);
        }
    }
}
