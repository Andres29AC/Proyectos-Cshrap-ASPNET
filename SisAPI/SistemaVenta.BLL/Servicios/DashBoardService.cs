using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.Model;
namespace SistemaVenta.BLL.Servicios
{
    public class DashBoardService:IDashBoardService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;

        public DashBoardService(IVentaRepository ventaRepository, IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _productoRepository = productoRepository;
            _mapper = mapper;
        }
        //TODO: Este metodo no ayudara a obtener el resumen de las ventas
        private IQueryable<Venta> retornarVentas(IQueryable<Venta> tablaVenta, int restarCantidadDias)
        {
            //TODO: Permitiremos nulos
            DateTime? ultimaFecha = tablaVenta.OrderByDescending(v =>
            v.FechaRegistro).Select(v => v.FechaRegistro).First(); //-->Obtendremos el primero encontrado
            ultimaFecha = ultimaFecha.Value.AddDays(restarCantidadDias);
            return tablaVenta.Where(v => v.FechaRegistro >= ultimaFecha);
        }
        private async Task<int> TotalVentasUltimasSemanas()
        {
            int total = 0;
            IQueryable<Venta> _ventaQuery = await _ventaRepository.Consultar();
            if (_ventaQuery.Count() > 0)
            {
                //TODO: Obtendremos el total de ventas de la ultima semana
                var tablaVenta = retornarVentas(_ventaQuery, -7);
                total = tablaVenta.Count();
            }
            return total;
        }
        private async Task<string> TotalIngresosUltimasSemanas()
        {
            decimal resultado = 0;
            IQueryable<Venta> _ventaQuery = await _ventaRepository.Consultar();
            if (_ventaQuery.Count() > 0)
            {
                var tablaVenta = retornarVentas(_ventaQuery, -7);
                //TODO: actualizando el resultado
                resultado = tablaVenta.Select(v => v.Total).Sum(v => v.Value);
            }
            return Convert.ToString(resultado,new CultureInfo("es-PE"));
        }
        private async Task<int> TotalProductos()
        {
            IQueryable<Producto> _productoQuery = await _productoRepository.Consultar();
            int total = _productoQuery.Count();
            return total;
        }
        private async Task<Dictionary<string,int>> VentasUltimaSemana()
        {
            Dictionary<string,int> resultado = new Dictionary<string, int>();
            IQueryable<Venta> _ventaQuery = await _ventaRepository.Consultar();
            if (_ventaQuery.Count() > 0)
            {
                var tablaVenta = retornarVentas(_ventaQuery, -7);
                resultado = tablaVenta
                    .GroupBy(v => v.FechaRegistro.Value.Date).OrderBy(g => g.Key)
                    .Select(dv => new { fecha = dv.Key.ToString("dd/MM/yyyy"), total = dv.Count() })
                    .ToDictionary(keySelector: r => r.fecha, elementSelector: r => r.total);
            }
            return resultado;
        }
            
        public async Task<DashBoardDTO> Resumen()
        {
            DashBoardDTO vmDashboard = new DashBoardDTO();
            try {
                vmDashboard.TotalVentas =  await TotalVentasUltimasSemanas();
                vmDashboard.TotalIngresos = await TotalIngresosUltimasSemanas();
                vmDashboard.TotalProductos = await TotalProductos();
                List<VentaSemanaDTO> listaVentaSemana = new List<VentaSemanaDTO>();
                foreach (KeyValuePair<string,int> item in await VentasUltimaSemana())
                {
                    listaVentaSemana.Add(new VentaSemanaDTO { Fecha = item.Key, Total = item.Value });
                }
                vmDashboard.VentasUltimaSemana = listaVentaSemana;
            } 
            catch {
                throw;
            }
            return vmDashboard;
        }
    }
}
