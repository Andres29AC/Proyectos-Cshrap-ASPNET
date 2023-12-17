using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVenta.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DAL.Repositorios;
using SistemaVenta.Utility;
using SistemaVenta.BLL.Servicios.Contrato;
using SistemaVenta.BLL.Servicios;

namespace SistemaVenta.IOC
{
    public static class Dependencia
    {
        //TODO Metodo de Extension
        public static void InyectarDependencias(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DbsistventaContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("cadenaSL"));
            });
            //Inyectando dependencia de repositorios
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IVentaRepository, VentaRepository>();
            //ingles-->try iy out -->pruebalo
            services.AddAutoMapper(typeof(AutoMapperProfile));
            //TODO: Servicios
            services.AddScoped<IROLServices,RolService>();
            services.AddScoped<IUsuarioService,UsuarioService>();
            services.AddScoped<ICategoriaService,CategoriaService>();
            services.AddScoped<IProductoService,ProductoService>();
            services.AddScoped<IVentaService,VentaService>();
            services.AddScoped<IDashBoardService,DashBoardService>();
            services.AddScoped<IMenuService,MenuService>();
        }
    }
}        