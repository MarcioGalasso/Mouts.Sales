using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;


namespace Mouts.Sale.Test
{
    public class ConfigureServiceFixure
    {
        public IServiceProvider Services;
        public HttpClient Client;

        public void Register(Action<IServiceCollection> configureMock)
        {
            var aplication = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    configureMock(services);
                });
            });

            Services = aplication.Services;
            Client = aplication.CreateClient();
            
        }
    }
}
