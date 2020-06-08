using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Cities
{
    /// <summary>
    /// It creates a host for the web application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Calls a CreateHostBuilder method to create and configure a builder object
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates a Generic Host using non-HTTP workload
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
