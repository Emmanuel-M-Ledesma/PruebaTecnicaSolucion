using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Server.Services;
using PruebaTecnica.Shared.Data;
using PruebaTecnica.Shared.Models;

namespace PruebaTecnica.Server.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    [Authorize]
    public class PedidosController : Controller
    {
        private readonly DataContext _Context;
        private readonly IUserService _userService;
        public PedidosController(DataContext context, IUserService userService)
        {
            _Context = context;
            _userService = userService;
        }


        //Crear pedido en base al usuario logueado
        [HttpPost]
        [Route("crear")]
        public async Task<ActionResult<Pedido>> Post(DateTime? Fecha, string? Descripcion, decimal Monto, string? Estado)
        {
            Pedido pedido = new Pedido();
            Usuario usr = new Usuario();
            usr = _userService.Obtain(User.Identity.Name);
            var user = await _Context.Proveedores.Include(x => x.ProvSucs).Where(x => x.IdProveedor == usr.IdProveedor).FirstOrDefaultAsync();

            if (Monto == null || Fecha == null || Descripcion == null || Estado == null)
            {
                return BadRequest("El pedido debe contener fecha, descripcion, monto y estado");
            }
            if (Monto <= 0)
            {
                return BadRequest("El monto del pedido debe ser mayor a 0");
            }
            switch (Estado.ToLower())
            {
                case "pendiente":
                    pedido.IdEstado = 1;
                    break;
                case "finalizado":
                    pedido.IdEstado = 2;
                    break;
                default:
                    return BadRequest("Estado incorrecto");
            }


            pedido.Fecha = Fecha;
            pedido.Descripcion = Descripcion;
            pedido.Monto = Monto;
            pedido.IdProveedor = user.IdProveedor;

            _Context.Pedidos.Add(pedido);
            await _Context.SaveChangesAsync();
            return Ok(pedido);
        }

        [HttpGet]
        [Route("pendiente")]
        public async Task<IActionResult> GetPen(DateTime? FechaDesde, DateTime? FechaHasta)
        {
            var pedido = await _Context.Pedidos.Where(x => x.IdEstado == 1).ToListAsync();
            Usuario usr = new Usuario();
            usr = _userService.Obtain(User.Identity.Name);
            List<Pedido> res = new List<Pedido>();


            if (FechaDesde != null && FechaHasta == null)
            {
                res = pedido.Where(x => x.IdProveedor == usr.IdProveedor && x.Fecha >= FechaDesde).ToList();
            }
            if (FechaDesde == null && FechaHasta != null)
            {
                res = pedido.Where(x => x.IdProveedor == usr.IdProveedor && x.Fecha <= FechaHasta).ToList();
            }
            if (FechaDesde == null && FechaHasta == null)
            {
                res = pedido.Where(x => x.IdProveedor == usr.IdProveedor).ToList();
            }
            else
            {
                if (FechaDesde <= FechaHasta)
                {
                    res = pedido.Where(x => x.IdProveedor == usr.IdProveedor && x.Fecha >= FechaDesde && x.Fecha <= FechaHasta).ToList();
                }
                if (FechaDesde > FechaHasta)
                {
                    return BadRequest("Inconsistencia en las fechas");
                }
            }

            if (res.Count > 0)
            {
                TotalModel total = new TotalModel
                {
                    pedidos = res,
                    SumaTotal = null,
                    ComisionProveedor = null,
                };
                return Ok(total);
            }
            else
            {
                return BadRequest("La busqueda no arrojo ningun resultado");
            }
        }


        [HttpGet]
        [Route("finalizado")]
        public async Task<IActionResult> GetFin(DateTime? FechaDesde, DateTime? FechaHasta)
        {
            var pedido = await _Context.Pedidos.Where(x => x.IdEstado == 2).ToListAsync();
            Usuario usr = new Usuario();
            usr = _userService.Obtain(User.Identity.Name);
            List<Pedido> res = new List<Pedido>();
            var user = await _Context.Proveedores.Where(x => x.IdProveedor == usr.IdProveedor).FirstOrDefaultAsync();

            if (FechaDesde != null && FechaHasta == null)
            {
                res = pedido.Where(x => x.IdProveedor == usr.IdProveedor && x.Fecha >= FechaDesde).ToList();
            }
            if (FechaDesde == null && FechaHasta != null)
            {
                res = pedido.Where(x => x.IdProveedor == usr.IdProveedor && x.Fecha <= FechaHasta).ToList();
            }
            if (FechaDesde == null && FechaHasta == null)
            {
                res = pedido.Where(x => x.IdProveedor == usr.IdProveedor).ToList();
            }
            else
            {
                if (FechaDesde <= FechaHasta)
                {
                    res = pedido.Where(x => x.IdProveedor == usr.IdProveedor && x.Fecha >= FechaDesde && x.Fecha <= FechaHasta).ToList();
                }
                if (FechaDesde > FechaHasta)
                {
                    return BadRequest("Inconsistencia en las fechas");
                }
            }

            if (res.Count > 0)
            {
                decimal? suma = 0;
                for (int i = 0; i < res.Count; i++)
                {
                    suma += res[i].Monto;
                }
                TotalModel total = new TotalModel
                {
                    pedidos = res,
                    SumaTotal = suma,
                    ComisionProveedor = suma * user.Comision / 100
                };
                return Ok(total);
            }
            else
            {
                return BadRequest("La busqueda no arrojo ningun resultado");
            }
        }
    }
}
