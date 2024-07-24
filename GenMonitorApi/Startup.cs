using Microsoft.Net.Http.Headers;
using System.Net.Mime;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using GenMonitorApi.Config;


namespace GenMonitorApi
{
    public class Startup
    {
        public IConfiguration _configuracao;
        public IContainer ApplicationContainer { get; private set; }
        private readonly ContainerBuilder _builder;

        public Startup(IConfiguration config)
        {
            _configuracao = config;
            _builder = new ContainerBuilder();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwagerConfig(_configuracao);
            services.AddVersionedApiExplorer();
            //services.AddRepositorioBaseConfig(_configuracao);
            services.AddInjecaoDependenciaConfig();

            

            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                //options.InvalidModelStateResponseFactory = context =>
                //{
                //    var result = new ValidationFailedResult(context.ModelState);
                //    result.ContentTypes.Add(MediaTypeNames.Application.Json);
                //    return result;
                //};
            });
            
            var corsOrigin = _configuracao.GetSection("Seguranca:Politicas:Cors:OrigemRequisicao").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy(_configuracao["Seguranca:Politicas:Cors:Nome"], policy =>
                {
                    policy.WithOrigins(corsOrigin)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            
            //services.Configure<Settings>(options =>
            //{
            //    options.ConnectionString = _configuracao.GetSection("MongoConnection:ConnectionString").Value;
            //    options.Database = _configuracao.GetSection("MongoConnection:Database").Value;
            //});
            //services.AddScoped<IRepositorioKnight, RepositorioKnight>();
            
            services.AddHttpClient("EnvioApi", cliente =>
            {
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });
        }

        public IServiceProvider ConfigureContainer(IServiceCollection services)
        {
            ApplicationContainer = _builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseHttpsRedirection();

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseCors(_configuracao["Seguranca:Politicas:Cors:Nome"]);
            }

            app.UseRouting();
            app.UseSerilogRequestLogging();
            
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
