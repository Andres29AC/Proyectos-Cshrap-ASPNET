using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DTO;
using SistemaVenta.Model;
namespace SistemaVenta.BLL.Servicios
{
    public class ProductoService:IProductoService
    {
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;

        public ProductoService(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductoDTO>> Lista()
        {
            try
            {
                var queryProducto = await _productoRepository.Consultar();
                var listaProductos = queryProducto.Include(cat => cat.IdCategoriaNavigation).ToList();
                return _mapper.Map<List<ProductoDTO>>(listaProductos.ToList());
            }
            catch
            {
                throw;
            }
        }

        public Task<ProductoDTO> Crear(ProductoDTO modelo)
        {
            try
            {

            }
            catch
            {
                
            }
        }

        public Task<bool> Editar(ProductoDTO modelo)
        {
            try
            {

            }
            catch
            {

            }
        }

        public Task<bool> Eliminar(int id)
        {
            try
            {

            }
            catch
            {

            }
        }
    }
}
