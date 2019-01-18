using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()      //serilog do logowania do pliku
                .MinimumLevel.Debug()
                .WriteTo.File(AppDomain.CurrentDomain.BaseDirectory + "\\logs\\log-{Date}.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Debug("Logging now!");

            CreateWebHostBuilder(args).Build().Run();


            Log.CloseAndFlush();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
           
                .UseStartup<Startup>();
    }
}
