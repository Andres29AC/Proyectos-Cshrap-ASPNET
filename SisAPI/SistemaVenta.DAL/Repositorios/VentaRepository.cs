using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVenta.DAL.DBContext;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.Model;
namespace SistemaVenta.DAL.Repositorios
{
    public class VentaRepository : GenericRepository<Venta>,IVentaRepository
    {
        private readonly DbsistventaContext _dbcontext;
        public VentaRepository(DbsistventaContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta saleGenerated = new Venta();
            //Utilizando transacciones:
            using (var transaction = _dbcontext.Database.BeginTransaction()){
                try {
                    //restando cada producto que esta involucrado dentro de la venta
                    foreach(DetalleVenta dv in modelo.DetalleVenta)
                    {
                        Producto product_found = _dbcontext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();
                        product_found.Stock = product_found.Stock - dv.Cantidad;
                        _dbcontext.Productos.Update(product_found);
                    }
                    await _dbcontext.SaveChangesAsync();
                    NumeroDocumento correlativo = _dbcontext.NumeroDocumentos.First();
                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaRegistro = DateTime.Now;
                    _dbcontext.NumeroDocumentos.Update(correlativo);
                    await _dbcontext.SaveChangesAsync();
                    //Especificando formato:
                    int quantityDigits = 4;
                    string zeros = String.Concat(Enumerable.Repeat("0", quantityDigits));
                    string numberSale = zeros + correlativo.UltimoNumero.ToString();
                    //-->Formato obtenido hasta aqui -->00001
                    numberSale = numberSale.Substring(numberSale.Length - quantityDigits,quantityDigits);
                    modelo.NumeroDocumento = numberSale;
                    await _dbcontext.Venta.AddAsync(modelo);
                    await _dbcontext.SaveChangesAsync();
                    saleGenerated = modelo;
                    //Aqui decimos que nuestra transaccion finalize sin ningun
                    //problema
                    transaction.Commit();
                } catch
                {
                    transaction.Rollback();
                    throw;
                }
                return saleGenerated;

            }
        }
    }
}