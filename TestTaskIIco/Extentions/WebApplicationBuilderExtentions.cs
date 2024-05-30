using Microsoft.EntityFrameworkCore;
using PostgreDatabase.DAL.EntityFramework;

namespace TestTaskIIcoServer.Extentions
{
    public static class WebApplicationBuilderExtentions
    {
        public static WebApplicationBuilder AddApplicationContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationContext>(options
                    => options.UseNpgsql(connectionString));

            return builder;
        }
    }
}