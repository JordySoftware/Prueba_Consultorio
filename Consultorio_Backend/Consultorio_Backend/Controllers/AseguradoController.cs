using Consultorio_Backend.Data;
using Consultorio_Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Consultorio_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AseguradoController : ControllerBase
    {
        public readonly ConsultorioDBContext _dbcontext;

        public AseguradoController(ConsultorioDBContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Asegurado> lista = new List<Asegurado>();

            try
            {
                lista = _dbcontext.Asegurados.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }

        [HttpGet]
        [Route("Lista Completa")]
        public IActionResult ListaC()
        {
            List<Asegurado> lista = new List<Asegurado>();

            try
            {
                lista = _dbcontext.Asegurados.Include(i => i.Seguro).ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }

        }


        [HttpPost]
        [Route("Nuevo Registro")]
        public IActionResult Guardar([FromBody] Asegurado objeto)
        {


            try
            {
                
               
                    _dbcontext.Asegurados.Add(objeto);
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
        public IActionResult Editar([FromBody] Asegurado objeto)
        {
            Asegurado ase = _dbcontext.Asegurados.Find(objeto.id_asegurado);

            if (ase == null)
            {
                return BadRequest("Producto no encontrado");

            }

            try
            {

                ase.id_asegurado = objeto.id_asegurado is 0 ? ase.id_asegurado : objeto.id_asegurado;
                ase.id_seguro = objeto.id_seguro is 0 ? ase.id_seguro : objeto.id_seguro;
                ase.cedula = objeto.cedula is null ? ase.cedula : objeto.cedula;
                ase.nombre_del_cliente = objeto.nombre_del_cliente is null ? ase.nombre_del_cliente : objeto.nombre_del_cliente;
                ase.telefono = objeto.telefono is null ? ase.telefono : objeto.telefono;
                ase.edad= objeto.edad is 0 ? ase.edad : objeto.edad;



                _dbcontext.Asegurados.Update(ase);
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
        public IActionResult Eliminar(int id_asegurado)
        {

            Asegurado ase = _dbcontext.Asegurados.Find(id_asegurado);

            if (ase == null)
            {
                return BadRequest("Producto no encontrado");

            }

            try
            {


                _dbcontext.Asegurados.Remove(ase);
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
    

