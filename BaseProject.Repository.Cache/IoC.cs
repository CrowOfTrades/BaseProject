using BaseProject.Model.Interfaces;
using BaseProject.Repository.Cache;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Repository
{
    public static class IoC
    {
        public static IServiceCollection AddRepositoryCache(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
