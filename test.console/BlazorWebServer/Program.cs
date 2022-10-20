using BlazorWebServer.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Runtime.InteropServices;




using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;

namespace BlazorWebServer
{
    public class Program
    {

        static void Main(string[] args)
        {
            InitBlazorServer(args);
        }

        public static void InitBlazorServer(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            var app = builder.Build();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                app.Urls.Add("http://*:80");
            }
       
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}