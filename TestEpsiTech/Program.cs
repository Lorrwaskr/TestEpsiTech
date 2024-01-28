
using TestEpsiTech.Data.DbContexts;
using TestEpsiTech.Data.Repositories;
using TestEpsiTech.Mappings;
using TestEpsiTech.Services;
using TestEpsiTech.Services.Interfaces.Repositories;
using TestEpsiTech.Services.Interfaces.Services;

namespace TestEpsiTech
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ITasksRepository, TasksRepository>();
            builder.Services.AddScoped<ITasksService, TasksService>();
            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
