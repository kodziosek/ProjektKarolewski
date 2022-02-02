using BlazorFront.Data;
using BlazorFront.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Syncfusion.Blazor;
using System;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using BlazorFront.Shared;
using System.Net.Http;
using Blazored.LocalStorage;
using BlazorFront.AuthProviders;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorFront
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
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor();
            services.AddLocalization();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddBlazoredLocalStorage();
            services.AddAuthenticationCore();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
            services.AddSingleton<HttpClient>();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                // Define the list of cultures your app will support
                var supportedCultures = new List<CultureInfo>()
                {                   
                    new CultureInfo("pl"),
                    new CultureInfo("en-US")

                };
                // Set the default culture
                options.DefaultRequestCulture = new RequestCulture("pl-PL");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
                services.AddHttpClient<IDeviceService, DeviceService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
            });
            services.AddHttpClient<IWardService, WardService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
            });
            services.AddHttpClient<IProducerService, ProducerService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
            });
            services.AddHttpClient<IAuthenticationService, AuthenticationService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTQ1NDYxQDMxMzkyZTMzMmUzMFJyWTFWL1lGajJKU0hnZGdudEpWZ3oxNE82dFBzeE5HODN6L0dHTUZtek09");
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
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            
        }
    }
}
