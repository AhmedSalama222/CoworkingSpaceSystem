using AutoMapper;
using CoworkingSpaceSystem.BLL.Helpers;
using CoworkingSpaceSystem.BLL.Mapping;
using CoworkingSpaceSystem.BLL.Services.Implementaions;
using CoworkingSpaceSystem.DAL.Context;
using CoworkingSpaceSystem.DAL.Repositories.Implementations;
using CoworkingSpaceSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace CoworkingSpaceSystem.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            builder.Services.AddScoped<IDocumentSettings, DocumentSettings>();
            builder.Services.AddScoped<ISpaceService, SpaceService>();
            //builder.Services.AddScoped<IGenericRepository, GenericRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
