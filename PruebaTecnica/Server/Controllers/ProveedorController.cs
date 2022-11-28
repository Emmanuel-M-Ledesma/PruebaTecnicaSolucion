using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Shared.Data;
using PruebaTecnica.Shared.Models;

namespace PruebaTecnica.Server.Controllers
{
    [ApiController]
    [Route("api/proveedores")]

    public class ProveedorController : ControllerBase
    {
        private readonly DataContext _Context;

        public ProveedorController(DataContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Proveedor>>> GetAll()
        {
            var proveedor = await _Context.Proveedores.ToListAsync();
            return Ok(proveedor);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var user = await _Context.Usuarios.Where(x => x.IdProveedor == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound("No existe usuario relacionado al proveedor");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<Proveedor>> Post(string Usuario, string Contraseña, string Nombre, int Comision)
        {
            Proveedor proveedorModel = new Proveedor();
            Usuario usuarioModel = new Usuario();
            if (Comision >= 100 || Comision <= 0)
            {
                return BadRequest("la comision debe estar en un rango entre 1 y 99");
            }
            try
            {
                proveedorModel.Nombre = Nombre;
                proveedorModel.Comision = Comision;
                _Context.Proveedores.Add(proveedorModel);
                await _Context.SaveChangesAsync();
                usuarioModel.User = Usuario;
                usuarioModel.Pass = Contraseña;
                usuarioModel.IdProveedor = proveedorModel.IdProveedor;
                _Context.Usuarios.Add(usuarioModel);
                await _Context.SaveChangesAsync();
                return Ok(proveedorModel);
            }
            catch (Exception)
            {
                _Context.Usuarios.Remove(usuarioModel);
                _Context.Proveedores.Remove(proveedorModel);
                await _Context.SaveChangesAsync();
                return BadRequest("Error al crear el proveedor - Usuario existente");
            }
        }
    }
}
