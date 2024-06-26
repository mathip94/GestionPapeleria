using UsesCases;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace WebApiArticulos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DbContext, Contexto>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("StringConnection"));
            });

            builder.Services.AddScoped(typeof(IRepositoryUsuario), typeof(RepositoryUsuario));
            builder.Services.AddScoped(typeof(IServicioUsuario), typeof(ServicioUsuario));

            builder.Services.AddScoped(typeof(IRepositoryCliente), typeof(RepositoryCliente));
            builder.Services.AddScoped(typeof(IServicioCliente), typeof(ServicioCliente));

            builder.Services.AddScoped(typeof(IRepositoryDireccion), typeof(RepositoryDireccion));
            builder.Services.AddScoped(typeof(IServicioDireccion), typeof(ServicioDireccion));

            builder.Services.AddScoped(typeof(IRepositoryParametro), typeof(RepositoryParametro));
            builder.Services.AddScoped(typeof(IServicioParametro), typeof(ServicioParametro));

            builder.Services.AddScoped(typeof(IRepositoryArticulo), typeof(RepositoryArticulo));
            builder.Services.AddScoped(typeof(IServicioArticulo), typeof(ServicioArticulo));

            builder.Services.AddScoped(typeof(IRepositoryPedido), typeof(RepositoryPedido));
            builder.Services.AddScoped(typeof(IServicioPedido), typeof(ServicioPedido));

            builder.Services.AddScoped(typeof(IRepositoryPedidoComun), typeof(RepositoryPedidoComun));
            builder.Services.AddScoped(typeof(IServicioPedidoComun), typeof(ServicioPedidoComun));

            builder.Services.AddScoped(typeof(IRepositoryPedidoExpress), typeof(RepositoryPedidoExpress));
            builder.Services.AddScoped(typeof(IServicioPedidoExpress), typeof(ServicioPedidoExpress));


            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
