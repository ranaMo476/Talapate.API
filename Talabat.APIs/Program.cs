using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Talabat.Repositary.DataContext;

namespace Talabat.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region configure services Add Services to countiner

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            #endregion


            #region Update-database 
            // this is method to make any change updated in database immeditaly
            // StoreContext dbContext = new StoreContext();
            // await  dbContext.Database.MigrateAsync();
   using var Scope = app.Services.CreateScope();

                var Services = Scope.ServiceProvider;
            var LoggerFactory= Services.GetRequiredService<ILoggerFactory>();   
            try {
             
                var DbContext = Services.GetRequiredService<DbContext>();

                await DbContext.Database.MigrateAsync();
                //  Scope.Dispose();
            }
            catch (Exception ex) { 
            var logger =LoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An Error Occured");
            }
            #endregion


            #region  Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion

            app.Run();
        }
    }
}
