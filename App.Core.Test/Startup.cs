
using App.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;

namespace App.Core.Test {
    public class Startup {
        // Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMediatR ();

            // if you have handlers/events in other assemblies
            services.AddMediatR(typeof(AddHandler).Assembly);            
        }

    }
}