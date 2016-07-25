using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .ConfigureLogging(options => options.AddConsole())
                .ConfigureLogging(options => options.AddDebug())
                .Configure(app =>
                {
                    app.UseDefaultFiles(); // serve index.html by default
                    app.UseStaticFiles();
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseWebRoot(Directory.GetCurrentDirectory()) // serve without wwwroot
                .UseKestrel()
                .Build();

            host.Run();
        }
    }
}
