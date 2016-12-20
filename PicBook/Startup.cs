using Microsoft.Owin;
using Owin;
using PicBook.Migrations;
using PicBook.Models;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(PicBook.Startup))]
namespace PicBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BlogDbContext, Configuration>());
            ConfigureAuth(app);
        }
    }
}
