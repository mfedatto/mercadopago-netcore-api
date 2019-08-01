using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace MFedatto.MercadoPago.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v01_0", new Swashbuckle.AspNetCore.Swagger.Info
				{
					Version = "v01_0",
					Title = "Mercado Pago API Client",
					Description = "Mercado Pago .Net Core API Client",
					TermsOfService = ""
				});
				options.CustomSchemaIds(i => i.FullName);
				//options.OperationFilter<OperationFilter>();
			});

			services.AddMvc()
				.AddJsonOptions(x => x.SerializerSettings
					.ContractResolver = new DefaultContractResolver {
						NamingStrategy = new SnakeCaseNamingStrategy()
					});
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("v01_0/swagger.json", "Mercado Pago API Client");
			});

			app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
