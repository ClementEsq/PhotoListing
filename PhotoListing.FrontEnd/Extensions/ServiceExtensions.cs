using Microsoft.Extensions.DependencyInjection;
using PhotoListing.DataAccess;
using PhotoListing.DataAccess.Interfaces;
using PhotoListing.DataAccess.Repository;
using PhotoListing.Models.ClientModels;
using PhotoListing.Services;
using PhotoListing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoListing.FrontEnd.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            RegisterHttpClients(services);
            RegisterRepositories(services);
            RegisterPhotoListingServices(services);
            return services;
        }

        private static void RegisterHttpClients(IServiceCollection services)
        {
            services.AddHttpClient("photo", c =>
            {
                c.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");

            })
           .AddTypedClient<IClient<Album>, AlbumClient>()
            .AddTypedClient<IClient<Photo>, PhotoClient>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<IPhotoRepository, PhotoRepository>();
        }

        private static void RegisterPhotoListingServices(IServiceCollection services)
        {
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<IPhotoListingService, PhotoListingService>();
        }
    }
}
