using CocheraTp.Models;
using CocheraTp.Servicios.UsuarioServicio;
using Microsoft.AspNetCore.Mvc;

namespace ApiCocheras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<USUARIO>>> GetAllUsuario()
        {
            try
            {
                var usuarios = await _usuarioService.GetAllUsuario();
                if (usuarios == null || usuarios.Count == 0)
                {
                    return NotFound("No se encontraron usuarios.");
                }
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los usuarios: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, USUARIO usuario)
        {
            try
            {
                var actualizado = await _usuarioService.UpdateUsuario(id, usuario);
                if (!actualizado)
                {
                    return NotFound("No se pudo actualizar el usuario");
                }
                return Ok("Usuario actualizado con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar el usuario: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<ActionResult<USUARIO>> PostUsuario(USUARIO usuario)
        {
            try
            {
                var resultado = await _usuarioService.CreateUsuario(usuario);
                if (!resultado)
                {
                   return NotFound("No se pudo guardar el usuario");
                }
                return Ok("Usuario guardado con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al guardar el usuario: {ex.Message}");
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                var eliminado = await _usuarioService.DeleteUsuario(id);
                if (!eliminado)
                {
                    return NotFound("No se pudo eliminar el usuario");
                }
                return Ok("Usuario eliminado con éxito");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al guardar el usuario: {ex.Message}");
            }
        }
    }
}
