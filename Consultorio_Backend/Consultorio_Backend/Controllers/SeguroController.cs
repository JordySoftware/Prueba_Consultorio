using Consultorio_Backend.Data;
using Consultorio_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroController : ControllerBase
    {
        public readonly ConsultorioDBContext _dbcontext;

        public SeguroController(ConsultorioDBContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Seguro> lista = new List<Seguro>();

            try
            {
                lista = _dbcontext.Seguros.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }

        

        [HttpPost]
        [Route("Nuevo Registro")]
        public IActionResult Guardar([FromBody] Seguro objeto)
        {


            try
            {


                _dbcontext.Seguros.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });

            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al guardar cambios", detalle = innerException.Message });
                /*return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });*/
            }

        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Seguro objeto)
        {
            Seguro seg = _dbcontext.Seguros.Find(objeto.id_seguro);

            if (seg == null)
            {
                return BadRequest("Producto no encontrado");

            }

            try
            {

                seg.id_seguro = objeto.id_seguro is 0 ? seg.id_seguro : objeto.id_seguro;
                seg.nombre_del_seguro = objeto.nombre_del_seguro is null ? seg.nombre_del_seguro : objeto.nombre_del_seguro;
                seg.codigo_del_seguro = objeto.codigo_del_seguro is null ? seg.codigo_del_seguro : objeto.codigo_del_seguro;
                seg.suma_asegurada = objeto.suma_asegurada is 0 ? seg.suma_asegurada : objeto.suma_asegurada;
                seg.prima = objeto.prima is 0 ? seg.prima : objeto.prima;



                _dbcontext.Seguros.Update(seg);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al guardar cambios", detalle = innerException.Message });
            }

        }

        [HttpDelete]
        [Route("Eliminar por el id")]
        public IActionResult Eliminar(int id_seguro)
        {

            Seguro seg = _dbcontext.Seguros.Find(id_seguro);

            if (seg == null)
            {
                return BadRequest("Producto no encontrado");

            }

            try
            {


                _dbcontext.Seguros.Remove(seg);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al guardar cambios", detalle = innerException.Message });
            }
        }
    }
}
