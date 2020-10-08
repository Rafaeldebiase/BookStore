using AutoMapper;
using bookstore.data;
using bookstore.interfaces;
using bookstore.repository;
using bookstore.service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace bookstore.extensions
{
    public static class IocConfig
    {
        public static void AddSetup(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<ILivroService, LivroService>();

        }
    }
}