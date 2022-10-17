using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using FluentValidation;
using NutritionTracker.Pages.Ingredients.Service;
using NutritionTracker.Pages.Users.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Blazored.Toast;

namespace NutritionTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddRazorPages();
            services.AddHttpClient();
            services.AddBlazoredToast();
            services.AddServerSideBlazor();
            services.AddAuthorizationCore();
            services.AddBlazoredLocalStorage();
            services.AddMediatR(typeof(Program));
            services.AddScoped<IngredCRUDservice>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
            services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddHttpClient("local", c =>{c.BaseAddress = new Uri(Configuration.GetValue<string>("IngredientApi"));});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
