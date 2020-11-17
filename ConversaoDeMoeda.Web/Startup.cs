using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ConversaoDeMoeda.Aplicacao.Consultas;
using ConversaoDeMoeda.Aplicacao.Precos;
using ConversaoDeMoeda.Aplicacao.Precos.Moedas;
using ConversaoDeMoeda.Aplicacao.Produtos;
using ConversaoDeMoeda.Repositorio;

namespace ConversaoDeMoeda.Web
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
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IMoedaRepositorio, MoedaRepositorio>();
            services.AddScoped<IPrecoRepositorio, PrecoRepositorio>();
            services.AddScoped<CalculadoraDePrecosEmMoedasDisponiveis, CalculadoraDePrecosEmMoedasDisponiveis>();
            services.AddScoped<ConsultaDeProdutoComMoedasDisponiveis, ConsultaDeProdutoComMoedasDisponiveis>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
